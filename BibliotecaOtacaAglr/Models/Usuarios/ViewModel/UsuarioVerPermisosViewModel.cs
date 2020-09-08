using BibliotecaOtacaAglr.Models.Others.Entity.Permisos;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    public class UsuarioVerPermisosViewModel
    {
        /// <summary>
        /// IUsuario a administrar permisos
        /// </summary>
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
