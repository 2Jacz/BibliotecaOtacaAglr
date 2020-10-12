using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    /// <summary>
    /// Modelo con la informacion de un rol
    /// </summary>
    public class RolViewModel
    {
        /// <summary>
        /// Rol o permiso
        /// </summary>
        [Required(ErrorMessage = "Rol requerido")]
        public IdentityRole Rol { get; set; }

        /// <summary>
        /// Lista de usuarios pertenecientes al rol
        /// </summary>
        public IEnumerable<Usuario> Asignados { get; set; }

        /// <summary>
        /// Lista de usuarios no pertenecientes al rol
        /// </summary>
        public IEnumerable<Usuario> NoAsignados { get; set; }

        /// <summary>
        /// Permisos que puede hacer el rol 
        /// </summary>
        public IList<Claim> Permisos { get; set; }

        public RolViewModel()
        {
            Permisos = new List<Claim>();
        }
    }
}
