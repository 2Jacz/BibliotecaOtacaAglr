using BibliotecaOtacaAglr.Models.Others.Entity.Permisos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    /// <summary>
    /// Rol y su lista de permisos activos e inactivos
    /// </summary>
    public class RolPermisoVerViewModel
    {
        /// <summary>
        /// Rol a administrar permisos
        /// </summary>
        [Required(ErrorMessage = " requerido")]
        public string IdRol { get; set; }

        /// <summary>
        /// Lista con los permisos activos/inactivos para asignar al rol
        /// </summary>
        public List<PermisoAsignado> Permisos { get; set; }

        public RolPermisoVerViewModel()
        {
            Permisos = new List<PermisoAsignado>();
        }
    }
}
