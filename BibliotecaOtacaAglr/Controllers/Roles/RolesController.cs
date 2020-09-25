using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.Entity.Permisos;
using BibliotecaOtacaAglr.Models.Permisos.Entity;
using BibliotecaOtacaAglr.Models.Roles.ViewModel;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOtacaAglr.Controllers.Roles
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;

        public RolesController(BibliotecaOtakaBDContext context, RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: api/Roles
        [HttpGet("Listar")]
        public async Task<ActionResult> ListarRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = roles });
        }

        // GET: api/Roles/Agregar
        [HttpPost("Agregar")]
        public async Task<ActionResult> AgregarRol([FromBody] IdentityRole rol)
        {
            if (string.IsNullOrEmpty(rol.Name))
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "El rol debe de tener nombre" });
            }

            IdentityRole existe = await _roleManager.FindByNameAsync(rol.Name);

            if (existe != null)
            {
                return Conflict(new ApiResponseFormat() { Estado = StatusCodes.Status409Conflict, Mensaje = $"El rol {rol.Name} ya existe" });
            }

            IdentityResult result = await _roleManager.CreateAsync(rol);

            if (result.Succeeded)
            {
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Rol {rol.Name} agregado" });
            }
            else
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Dato = result.Errors });
            }
        }

        // GET: api/Roles/8e8ddcce-fe93-4563-be09-de9620c7e5e3
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerRol(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Rol invalido" });
            }

            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<Usuario> members = new List<Usuario>();
            List<Usuario> nonMembers = new List<Usuario>();

            foreach (Usuario user in _userManager.Users.ToList())
            {
                List<Usuario> list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var rolyusuarios = new RolViewModel { Rol = role, Asignados = members, NoAsignados = nonMembers, Permisos = await _roleManager.GetClaimsAsync(role) };

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = rolyusuarios });
        }

        // PUT: api/Roles/Gestionar-Usuarios
        [HttpPut("Gestionar-Usuarios")]
        public async Task<ActionResult> AsignarUsuariosAlRol([FromBody] RolAdministrarUsuariosViewModel model)
        {
            if (string.IsNullOrEmpty(model.Rol_Id) || string.IsNullOrEmpty(model.Rol_Nombre))
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Rol invalido" });
            }

            IdentityResult result;

            foreach (string userId in model.AniadirUsuariosIds ?? new string[] { })
            {
                Usuario user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await _userManager.AddToRoleAsync(user, model.Rol_Nombre);

                    if (!result.Succeeded)
                    {
                        return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Uno o varios errores", Dato = result.Errors });
                    }
                }
            }

            foreach (string userId in model.EliminarUsuariosIds ?? new string[] { })
            {
                Usuario user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await _userManager.RemoveFromRoleAsync(user, model.Rol_Nombre);

                    if (!result.Succeeded)
                    {
                        return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Uno o varios errores", Dato = result.Errors });
                    }
                }
            }

            var rol = await _roleManager.FindByIdAsync(model.Rol_Id);

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Usuarios asignados con exito", Dato = rol });
        }

        // GET: api/Roles/OntenerPermisos/5
        [HttpGet("Ontener-Permisos/{id}")]
        public async Task<ActionResult> GestionarPermisos(string id)
        {
            IdentityRole rol = await _roleManager.FindByIdAsync(id);

            if (rol == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Rol invalido" });
            }

            var permisos_activos = await _roleManager.GetClaimsAsync(rol);

            RolPermisoVerViewModel rolConPermisos = new RolPermisoVerViewModel()
            {
                IdRol = rol.Id
            };

            foreach (Permiso permiso in await _context.Permisos.ToListAsync())
            {
                PermisoAsignado permisos = new PermisoAsignado()
                {
                    Type = permiso.Tipo,
                    Value = permiso.Valor
                };

                if (permisos_activos.Any(p => p.Type == permiso.Tipo))
                {
                    permisos.Activo = true;
                }

                rolConPermisos.Permisos.Add(permisos);
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = rolConPermisos });
        }

        // PUT: api/Roles/Administrar-Permisos
        [HttpPut("Administrar-Permisos")]
        public async Task<IActionResult> GestionarPermisos([FromBody] RolPermisoVerViewModel model)
        {
            IdentityRole rol = await _roleManager.FindByIdAsync(model.IdRol);

            if (rol == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Rol invalido" });
            }

            var permisos_activos = await _roleManager.GetClaimsAsync(rol);

            try
            {
                foreach (Claim claim in permisos_activos)
                {
                    await _roleManager.RemoveClaimAsync(rol, claim);
                }

                var permisos_seleccionado = model.Permisos.Where(p => p.Activo).Select(p => new Claim(p.Type, p.Value)).ToList();

                foreach (Claim claim in permisos_seleccionado)
                {
                    await _roleManager.AddClaimAsync(rol, claim);
                }

                var rolmodificado = await _roleManager.FindByIdAsync(model.IdRol);

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Rol modificado con exito", Dato = rolmodificado });
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult, new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }

        // DELETE: api/Roles/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Rol invalido" });
            }

            IdentityRole rol = await _roleManager.FindByIdAsync(id);

            if (rol == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Rol no encontrado" });
            }

            try
            {
                IdentityResult result = await _roleManager.DeleteAsync(rol);

                if (result.Succeeded)
                {
                    return Ok(new ApiResponseFormat() { Estado = -StatusCodes.Status200OK, Mensaje = "Rol eliminado con exito", Dato = rol });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = $"No se pudo eliminar el rol {rol.Name}" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = ex.Message });
            }
        }
    }
}
