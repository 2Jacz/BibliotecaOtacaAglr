using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.Entity.EmailConfirmationTokenProviders;
using BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria;
using BibliotecaOtacaAglr.Models.Others.Entity.Validadores;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using BibliotecaOtacaAglr.Servicios.IUsuario;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<Usuario>, ValidarContrasenia>();
            services.AddDbContext<BibliotecaOtakaBDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BibliotecaOtakaAglr")), ServiceLifetime.Transient);

            services.AddCors();

            services.AddIdentity<Usuario, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = " ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_*";

                options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            })
                .AddEntityFrameworkStores<BibliotecaOtakaBDContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailConfirmationTokenProvider<Usuario>>("emailconfirmation");

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));
            services.Configure<EmailConfirmationTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromDays(3));

            services.AddSingleton(Configuration.GetSection("EmailConfiguration").Get<MensajeroConfiguracion>());
            services.AddScoped<IMensajero, Mensajero>();

            services.AddControllers();
            services.AddMvcCore()
                .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    IDictionary<string, string[]> Errors = new Dictionary<string, string[]>();

                    foreach (var keyModelStatePair in context.ModelState)
                    {
                        var campo = keyModelStatePair.Key;
                        var errors = keyModelStatePair.Value.Errors;
                        if (errors != null && errors.Count > 0)
                        {
                            if (errors.Count == 1)
                            {
                                var errorMessage = string.IsNullOrEmpty(errors[0].ErrorMessage) ? "Valor invalido." : errors[0].ErrorMessage;
                                Errors.Add(campo, new[] { errorMessage });
                            }
                            else
                            {
                                var errorMessages = new string[errors.Count];
                                for (var i = 0; i < errors.Count; i++)
                                {
                                    errorMessages[i] = string.IsNullOrEmpty(errors[0].ErrorMessage) ? "Valor invalido." : errors[0].ErrorMessage;
                                }

                                Errors.Add(campo, errorMessages);
                            }
                        }
                    }

                    var result = new ApiResponseFormat
                    {
                        Dato = Errors,
                        Estado = (int)HttpStatusCode.BadRequest,
                        Mensaje = "Uno o varios errores detectados",

                    };
                    return new BadRequestObjectResult(result);
                };
            })
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<IUserService, UserService>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    options.AccessDeniedPath = new PathString("/uwu");
                })
                .AddFacebook(options =>
                {
                    options.ClientId = Configuration["Authentication:Facebook:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Facebook:ClientSecret"];
                    options.AccessDeniedPath = new PathString("/uwu");
                })
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var userName = context.Principal.Identity.Name;
                            var user = userService.GetByName(userName);
                            var validtoken = userService.ValidateToken(userName).Result;
                            if (user == null)
                            {
                                // return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }
                            else if (validtoken == false)
                            {
                                // return message if token is not longer valid
                                context.Fail("Sesion expirada, inicie sesion de nuevo");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretTokenKey:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Inicio-sesion");
                options.AccessDeniedPath = new PathString("/uwu");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.Cookie.Name = "Pranamix";
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.Options.StartupTimeout = new TimeSpan(0, 0, 360);
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
