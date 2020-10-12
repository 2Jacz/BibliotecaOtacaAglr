using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    /// <summary>
    /// Modelo para mostrar agregar/quitar permisos a un rol
    /// </summary>
    public class RolAdministrarPermisosViewModel
    {
        [Required(ErrorMessage = "Rol requerido")]
        public string Id { get; set; }

        public string Nombre { get; set; }

        /// <summary>
        /// Lista con los permisos a mostrar
        /// </summary>
        public IList<Claim> Permisos { get; set; }

        public RolAdministrarPermisosViewModel()
        {
            Permisos = new List<Claim>();
        }
    }
}
