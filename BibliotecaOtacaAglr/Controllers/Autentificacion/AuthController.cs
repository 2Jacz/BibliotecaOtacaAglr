using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria;
using BibliotecaOtacaAglr.Models.Others.ViewModel.Autentificacion;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.ViewModel;
using BibliotecaOtacaAglr.Models.UsuarioTokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaOtacaAglr.Controllers.Autentificacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IPasswordValidator<Usuario> _passwordValidator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMensajero _emailSender;
        private readonly IConfiguration _configuration;
        private readonly BibliotecaOtakaBDContext _context;

        public AuthController(SignInManager<Usuario> signinMgr, UserManager<Usuario> userManager, IPasswordValidator<Usuario> passwordValidator, RoleManager<IdentityRole> roleManager, IMensajero emailSender, IConfiguration configuration, BibliotecaOtakaBDContext context)
        {
            _signInManager = signinMgr;
            _passwordValidator = passwordValidator;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<InicioSesionViewModel>> InicioSesion([FromBody][Bind("Correo,Contrasenia,Recordar,ReturnUrl")] InicioSesionViewModel model)
        {
            try
            {
                model.LoginExternos = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                Usuario usuario = await _userManager.FindByEmailAsync(model.Correo);

                if (usuario != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(usuario, model.Contrasenia, model.Recordar, false);

                    if (result.Succeeded)
                    {
                        var userinfo = await CrearToken(usuario, model.ReturnUrl);
                        await GuardarToken(userinfo);

                        string mensaje = string.Empty;
                        if (usuario != null && !usuario.EmailConfirmed)
                        {
                            mensaje = ", confirme su correo para hacer uso de todas nuestras funciones";
                        }

                        return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Inicio exitoso{mensaje}.", Dato = userinfo });
                    }
                }

                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Credenciales incorrectas" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        [HttpPost("Registro")]
        public async Task<ActionResult<NuevoRegistroViewModel>> Registro([FromBody][Bind("Nick,Correo,Contrasenia,ConfirmarContrasenia")] NuevoRegistroViewModel model)
        {
            try
            {
                Usuario nuevousuario = new Usuario()
                {
                    Email = model.Correo,
                    UserName = model.Nick
                };

                IdentityResult passresult = await _passwordValidator.ValidateAsync(_userManager, nuevousuario, model.Contrasenia);
                if (!passresult.Succeeded) return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Error al registrace", Dato = passresult.Errors });
                IdentityResult result = await _userManager.CreateAsync(nuevousuario, model.Contrasenia);

                if (result.Succeeded)
                {
                    await EnviarTokenConfirmacionAsync(nuevousuario);
                    IdentityResult claimresult = await _userManager.AddClaimAsync(nuevousuario, new Claim("Email", nuevousuario.Email));
                    bool rol = await _roleManager.RoleExistsAsync("Usuario");
                    string x = string.Empty;

                    if (rol)
                    {
                        IdentityResult rolresult = await _userManager.AddToRoleAsync(nuevousuario, "Usuario");
                        if (rolresult.Succeeded)
                        {
                            x = " como usuario";
                        }
                    }

                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Registrado exitosamente{x}" });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Error al registrarce", Dato = result.Errors });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK });
        }

        [HttpPost]
        public async Task<ActionResult> RecuperarContrasenia([FromBody] UsuarioRecuperarContraseniaViewModel model)
        {
            Usuario usuarioARecuperarContrasenia = await _userManager.FindByEmailAsync(model.Correo);

            if (usuarioARecuperarContrasenia != null && usuarioARecuperarContrasenia.EmailConfirmed)
            {
                try
                {
                    await EnviarTokenContraseniaAsync(usuarioARecuperarContrasenia);
                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Se envio un enlace a su correo para recuperar su contrasenia." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
                }
            }

            return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Para recuperar su contrasenia ingrese un correo valido y asegurese que halla sido confirmado" });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarReseteoContrasenia([FromBody] UsuarioRecuperarContraseniaViewModel model)
        {
            Usuario usuarioAResetearPassword = await _userManager.FindByEmailAsync(model.Correo);

            if (usuarioAResetearPassword != null)
            {
                var result = await _userManager.ResetPasswordAsync(usuarioAResetearPassword, model.TokenRecuperacion, model.ConfirmarContrasenia);

                if (result.Succeeded)
                {
                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Contrasenia modificada con exito, puede iniciar sesion con su nueva contrasenia" });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Ocurrio uno o varios errores al cambiar la contrasenia", Dato = result.Errors });
                }
            }

            return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Correo invalido" });
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            // direccion a retornar si el inicio de sesion due forzado
            returnUrl = returnUrl ?? Url.Content("~/");

            // instancia de loginviewmodel por si falla el inicio de sesion
            InicioSesionViewModel login = new InicioSesionViewModel()
            {
                ReturnUrl = returnUrl,
                LoginExternos = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            // remoteError es un error que manda el callback de la api si algo falla
            if (!string.IsNullOrEmpty(remoteError))
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status419AuthenticationTimeout, Mensaje = remoteError });
            }

            // obtener la informacion de la api de login
            var info = await _signInManager.GetExternalLoginInfoAsync();

            // si no hay respuesta, mostramos un error
            if (info == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Error al recopilar la informacion del usuario, intente de nuevo.", Dato = login });
            }

            string email = info.Principal.FindFirstValue(ClaimTypes.Email);
            Usuario usuario;
            string Mensaje = string.Empty;

            if (!string.IsNullOrEmpty(email))
            {
                usuario = await _userManager.FindByEmailAsync(email);

                if (usuario != null && !usuario.EmailConfirmed)
                {
                    Mensaje = "Para hacer uso de todas nuestras caracteristicas debe confirmar el mensaje que enviamos a su correo.";
                }
            }

            // si hay informacion, tratamos de iniciar sesion con la informacion de la api en nuestro siste con nuestros datos
            var loginStatus = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, false);

            // si el usuario pudo loguearse exitosamente lo regresamos a la url de antes de iniciar sesion, si no lo enviamos alhome/ index
            if (loginStatus.Succeeded)
            {
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = Mensaje, Dato = returnUrl });
            }
            // si el usuario no se pudo loguear es porque no esta registrado
            else
            {
                // si el usuario esta registrado externamente, nos aseguramos de que tambien lo este en nuestro sistema
                if (!string.IsNullOrEmpty(email))
                {
                    // buscamos si exite en nuestro sistema
                    usuario = await _userManager.FindByEmailAsync(email);

                    // si no, lo creamos
                    if (usuario == null)
                    {
                        // informacion provisional
                        usuario = new Usuario()
                        {
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Name)
                        };

                        // lo creamos
                        var nuevo = await _userManager.CreateAsync(usuario);

                        if (nuevo.Succeeded)
                        {
                            await EnviarTokenConfirmacionAsync(usuario);
                            await _userManager.AddClaimAsync(usuario, new Claim("Email", usuario.Email));
                            bool rol = await _roleManager.RoleExistsAsync("IUsuario");

                            if (rol)
                            {
                                await _userManager.AddToRoleAsync(usuario, "IUsuario");
                            }
                        }
                        else
                        {
                            return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Ocurrio uno o vario errores al momento de registrarce", Dato = nuevo.Errors });
                        }
                    }

                    // creamos registramos el login externo del usuario
                    await _userManager.AddLoginAsync(usuario, info);

                    //inicioamos sesion con el usuario
                    await _signInManager.SignInAsync(usuario, true);

                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = Mensaje, Dato = returnUrl });
                }
            }

            return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Ocurrio un error con el inicio de sesion externo, intentelo de nuevo mas tarde", Dato = loginStatus });
        }

        public IActionResult LoginExterno(string proveedor, string returnUrl)
        {
            var redirecturl = Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(proveedor, redirecturl);

            return new ChallengeResult(proveedor, properties);
        }

        /// <summary>
        /// Activa las cuentas de usuario
        /// </summary>
        /// <param name="token">Token activador de cuentas</param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IActionResult> ConfirmarCorreo(string token, string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Correo no registrado" });
            }

            var result = await _userManager.ConfirmEmailAsync(usuario, token);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, true);
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "IUsuario activado, ya puede disfrutar todas las funciones de la biblioteca otaca." });
            }
            else
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Dato = result.Errors });
            }
        }

        /// <summary>
        /// Envia por correo el enlace con el token para confimar la cuenta recien registrada
        /// </summary>
        /// <param name="nuevousuario">Instacia con la informacion del usuario a resetear contrasenia</param>
        /// <returns></returns>
        private async Task EnviarTokenConfirmacionAsync(Usuario nuevousuario)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(nuevousuario);
            var confirmationLink = Url.Action(nameof(ConfirmarCorreo), "Login", new { token, email = nuevousuario.Email }, Request.Scheme);

            var message = new Mensaje(new string[] { nuevousuario.Email }, "Confirmation email link", "Para hacer uso de todas nustras caracteristicas acceda a este enlace para confirmar su registro \n" + confirmationLink, null);
            await _emailSender.EnviarCorreoAsync(message);
        }

        /// <summary>
        /// Envia por correo el enlace con el token para resetear la contrasenia olvidada
        /// </summary>
        /// <param name="nuevousuario">Instacia con la informacion del usuario a resetear contrasenia</param>
        /// <returns></returns>
        private async Task EnviarTokenContraseniaAsync(Usuario nuevousuario)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(nuevousuario);
            var confirmationLink = Url.Action(nameof(ConfirmarReseteoContrasenia), "Auth", new { TokenRecuperacion = token, Correo = nuevousuario.Email }, Request.Scheme);

            var message = new Mensaje(new string[] { nuevousuario.Email }, "Olvido su contrasenia?", "Este correo se envio porque ikvido su contrasenia o alguien solicito un cambio de la misma, si no fue usted borre este mensaje, si hizo la solicitud entonces acceda al siguiente enlace \n" + confirmationLink, null);
            await _emailSender.EnviarCorreoAsync(message);
        }


        private async Task<LoginUserToken> CrearToken(Usuario usuario, string ReturnURL)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // instancia de configuracion de; jwt
            var key = Encoding.ASCII.GetBytes(_configuration["SecretTokenKey:Key"]); // clave ultra secreta encriptadora

            var userClaims = await _userManager.GetClaimsAsync(usuario); // claims del usuario
            var roles = await _userManager.GetRolesAsync(usuario); // roles del usuario
            var roleClaims = new List<Claim>(); // intancia para convertir los roles en claims
            for (int i = 0; i < roles.Count; i++) // asignamos cada rol a un claim
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, usuario.Id.ToString()) }.Concat(roleClaims).Concat(userClaims).ToList();

            var tokenDescriptor = new SecurityTokenDescriptor // intancia con la informacion del hwt
            {
                Subject = new ClaimsIdentity(claims), // asignamos la lista con todos los claims del usuario
                Expires = DateTime.UtcNow.AddDays(7), // agregamos un vida util del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // ponemos nuestra super clave encriptadora
            };

            var tokenString = "";
            do
            {
                var token = tokenHandler.CreateToken(tokenDescriptor); // creacion del token
                tokenString = tokenHandler.WriteToken(token); // serializacion del token
            } while (await _context.UsuariosTokens.AnyAsync(ut => ut.Token.Equals(tokenString)));

            LoginUserToken userinfo = new LoginUserToken() // instancia con la informacion que regresara en el login
            {
                Email = usuario.Email,
                Id = usuario.Id,
                Name = usuario.UserName,
                ReturnURL = ReturnURL,
                Token = tokenString
            };

            return userinfo;
        }

        private async Task GuardarToken(LoginUserToken userinfo)
        {
            var Fecha_Creacion = DateTime.UtcNow;
            var Fecha_Expiracion = Fecha_Creacion.AddDays(7);
            UsuarioToken guardartoken = new UsuarioToken()
            {
                Fecha_Creacion = Fecha_Creacion,
                Fecha_Expiracion = Fecha_Expiracion,
                Token = userinfo.Token,
                UsuarioId = userinfo.Id,
                Valido = true
            };
            await _context.UsuariosTokens.AddAsync(guardartoken);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Valida si el correo ya esta en registrado
        /// </summary>
        /// <param name="Correo">correo a registrar</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("ValidarCorreo")]
        public async Task<IActionResult> ValidarCorreoExistente(string Correo)
        {
            Usuario usuario = await _userManager.FindByEmailAsync(Correo);

            if (usuario == null)
            {
                return Ok(true);
            }
            else
            {
                return Ok($"El correo {usuario.Email} ya esta en uso.");
            }
        }

        /// <summary>
        /// BlackList de nimbres de usuario
        /// </summary>
        /// <param name="Nick">nombre de usuario</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("ValidarNick")]
        public IActionResult ValidarNickCorrecto(string Nick)
        {
            string[] BlackList = new string[] {
            "puto",
            "culo",
            "pepa",
            "cola",
            "cagada",
            "cerote",
            "cuacha",
            "puta",
            "panocha",
            "panochon",
            "verga",
            "pene",
            "vagina",
            "mierda",
            "culear"
        };

            if (BlackList.Any(nick => nick == Nick.ToString().ToLower()))
            {
                return Ok("Nombre de usuario no permitido");
            }

            return Ok(true);
        }
    }
}
