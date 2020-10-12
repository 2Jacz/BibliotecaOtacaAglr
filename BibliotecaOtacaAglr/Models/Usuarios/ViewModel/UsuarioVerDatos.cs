using BibliotecaOtacaAglr.Models.Usuarios.Entity;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    /// <summary>
    /// Clase para ver la informacion de un usuario
    /// </summary>
    public class UsuarioVerDatos
    {
        /// <summary>
        /// Informacion del usuario
        /// </summary>
        public Usuario UserInfo { get; set; }

        /// <summary>
        /// seniala si es el usuario en sesion para mostrar otras opciones
        /// </summary>
        public bool SoyYo { get; set; }

        public UsuarioVerDatos()
        {
            SoyYo = false;
        }
    }
}
