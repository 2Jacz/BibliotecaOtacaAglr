using BibliotecaOtacaAglr.Models.Others.Entity.Permisos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    /// <summary>
    /// Clase para mostrar los permisos de un usuario
    /// </summary>
    public class UsuarioVerPermisosViewModel
    {
        /// <summary>
        /// Usuario a administrar permisos
        /// </summary>
        [Required(ErrorMessage = "Usuario requerido")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Lista con los permisos activos/inactivos para asignar al usuario
        /// </summary>
        public List<PermisoAsignado> Permisos { get; set; }

        public UsuarioVerPermisosViewModel()
        {
            Permisos = new List<PermisoAsignado>();
        }
    }
}
