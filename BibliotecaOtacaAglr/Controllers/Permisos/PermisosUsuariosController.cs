using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.Entity.Permisos;
using BibliotecaOtacaAglr.Models.Permisos.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOtacaAglr.Controllers.Permisos
{
    [Route("api/Gestionar/Permisos")]
    [Authorize]
    [ApiController]
    public class PermisosUsuariosController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly BibliotecaOtakaBDContext _context;

        public PermisosUsuariosController(UserManager<Usuario> userManager, BibliotecaOtakaBDContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuarios(string filtro)
        {
            List<Usuario> usuarios_filtrados;

            if (string.IsNullOrEmpty(filtro))
            {
                usuarios_filtrados = await _userManager.Users.ToListAsync();
            }
            else
            {
                usuarios_filtrados = await _userManager.Users.Where(u => u.UserName == filtro).ToListAsync();
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = usuarios_filtrados });
        }

        [HttpGet("Usuario/{id}")]
        public async Task<ActionResult<IEnumerable<UsuarioVerPermisosViewModel>>> GestionarPermisos(string id)
        {
            Usuario user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "IUsuario invalido" });
            }

            var permisos_activos = await _userManager.GetClaimsAsync(user);

            UsuarioVerPermisosViewModel permisos_agregar = new UsuarioVerPermisosViewModel()
            {
                IdUsuario = user.Id
            };

            foreach (Permiso permiso in await _context.Permisos.ToListAsync())
            {
                PermisoAsignado permisos = new PermisoAsignado()
                {
                    Type = permiso.Tipo,
                    Value = permiso.Valor
                };

                if (permisos_activos.Any(p => p.Type == permiso.Tipo && p.Value.Equals("true")))
                {
                    permisos.Activo = true;
                }

                permisos_agregar.Permisos.Add(permisos);
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = permisos_agregar });
        }

        [HttpPost("Usuario")]
        public async Task<ActionResult<IEnumerable<UsuarioVerPermisosViewModel>>> GestionarPermisos([FromBody] UsuarioVerPermisosViewModel model)
        {
            Usuario usuario = await _userManager.FindByIdAsync(model.IdUsuario);

            if (usuario == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "IUsuario invalido" });
            }

            var permisos_activos = await _userManager.GetClaimsAsync(usuario);
            var email_claim = permisos_activos.Where(p => p.Type == "Email").Select(p => p).FirstOrDefault();

            var result = await _userManager.RemoveClaimsAsync(usuario, permisos_activos);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "No se pueden modificar los permisos del usuario" });
            }

            var permisos_seleccionado = model.Permisos.Select(p => new Claim(p.Type, p.Activo ? "true" : "false")).ToList();

            if (email_claim != null)
            {
                permisos_seleccionado.Add(email_claim);
            }
            else
            {
                permisos_seleccionado.Add(new Claim("Email", usuario.Email));
            }

            result = await _userManager.AddClaimsAsync(usuario, permisos_seleccionado);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "No se pueden agregar permisos al usuario" });
            }

            return StatusCode(StatusCodes.Status201Created, new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Mensaje = "Permisos editados con exito", Dato = usuario });
        }
    }
}
