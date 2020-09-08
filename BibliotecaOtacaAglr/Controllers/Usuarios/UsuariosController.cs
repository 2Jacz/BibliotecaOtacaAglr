using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaOtacaAglr.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly IPasswordValidator<Usuario> _passwordValidator;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuariosController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IPasswordHasher<Usuario> passwordHasher, IPasswordValidator<Usuario> passwordValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _passwordValidator = passwordValidator;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListaUsuarios()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        // GET api/Usuarios/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> ObtenerUsuario(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "IUsuario invalido" });
            }

            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "IUsuario no encontrado" });
            }

            return Ok(usuario);
        }

        // PUT api/Usuarios/Editar/example@example.net
        [HttpPut("Editar/{Correo}")]
        public async Task<ActionResult> ModificarUsuario(string Correo, [FromBody] UsuarioEditarViewModel usuario)
        {
            var correo_usuario_logeado = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;

            if (!correo_usuario_logeado.Equals(Correo))
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Ocurrio un error, verifique que su sesion este activa o que esten bien sus datos" });
            }

            try
            {
                Usuario useredit = await _userManager.FindByEmailAsync(correo_usuario_logeado);

                if (useredit != null)
                {
                    useredit.UserName = usuario.Nick;
                    if (usuario.Correo != useredit.Email)
                    {
                        useredit.Email = usuario.Correo;
                        var claim = User.Claims.FirstOrDefault(c => c.Type == "Email");
                        IdentityResult claimresult = await _userManager.ReplaceClaimAsync(useredit, claim, new Claim("Email", useredit.Email));
                    }

                    if (!string.IsNullOrEmpty(usuario.Contrasenia))
                    {
                        IdentityResult passresult = await _passwordValidator.ValidateAsync(_userManager, useredit, usuario.Contrasenia);
                        if (passresult.Succeeded)
                        {
                            useredit.PasswordHash = _passwordHasher.HashPassword(useredit, usuario.Contrasenia);
                        }
                    }

                    IdentityResult result = await _userManager.UpdateAsync(useredit);

                    if (result.Succeeded)
                    {
                        return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Datos modificados con exito", Dato = useredit });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status304NotModified, new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Dato = result.Errors });
                    }
                }

                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "IUsuario invalido" });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(ex.HResult, new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }

        // DELETE api/IUsuario/Eliminar/example@example.net
        [HttpDelete("Eliminar/{Correo}")]
        public async Task<ActionResult> EliminarUsuario(string Correo)
        {
            Usuario usuario = await _userManager.FindByEmailAsync(Correo);

            if (usuario != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(usuario);

                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"IUsuario {usuario.Email} eliminado con exito", Dato = usuario });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Error al eliminar el usuario", Dato = result.Errors });
                }
            }

            return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = $"Correo {Correo} invalido" });
        }

        [HttpPost("CambiarContrasenia")]
        public async Task<IActionResult> CambiarContrasenia([FromForm][Bind("ContraseniaActual,ContraseniaNueva,ConfirmarContraseniaNueva")] UsuarioEditarContrasenia model)
        {
            Usuario usuarioACambiarContrasenia = await _userManager.GetUserAsync(User);

            if (usuarioACambiarContrasenia != null)
            {
                var passresult = await _passwordValidator.ValidateAsync(_userManager, usuarioACambiarContrasenia, model.ContraseniaNueva);

                if (passresult.Succeeded)
                {
                    var result = await _userManager.ChangePasswordAsync(usuarioACambiarContrasenia, model.ContraseniaActual, model.ContraseniaNueva);

                    if (result.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(usuarioACambiarContrasenia);
                        return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Contrasenia cambiada con exito" });
                    }

                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Contrasenia invalida", Dato = result.Errors });
                }

                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Contrasenia no permitida" });
            }

            return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "IUsuario invalido" });
        }
    }
}