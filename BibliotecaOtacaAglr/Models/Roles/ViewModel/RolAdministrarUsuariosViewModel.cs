using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    public class RolAdministrarUsuariosViewModel
    {
        [Required]
        public string Rol_Nombre { get; set; }
        [Required]
        public string Rol_Id { get; set; }
        public string[] AniadirUsuariosIds { get; set; }
        public string[] EliminarUsuariosIds { get; set; }
    }
}
