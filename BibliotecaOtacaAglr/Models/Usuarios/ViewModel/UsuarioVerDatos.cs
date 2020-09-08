using BibliotecaOtacaAglr.Models.Usuarios.Entity;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    public class UsuarioVerDatos
    {
        public Usuario UserInfo { get; set; }

        public bool SoyYo { get; set; }

        public UsuarioVerDatos()
        {
            SoyYo = false;
        }
    }
}
