using BibliotecaOtacaAglr.Models.Permisos.Entity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    /// <summary>
    /// Instancia para modificar a un usuario
    /// </summary>
    public class UsuarioEditarPermisosViewModel
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Correo del usuario
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// Lista con los permisos a mostrar
        /// </summary>
        public IList<Permiso> Permisos { get; set; }

        /// <summary>
        /// Instancia para modificar un usuario
        /// </summary>
        public UsuarioEditarPermisosViewModel()
        {
            Permisos = new List<Permiso>();
        }
    }
}
