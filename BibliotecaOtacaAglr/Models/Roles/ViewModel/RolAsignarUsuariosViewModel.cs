using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    public class RolAsignarUsuariosViewModel
    {
        [Required]
        public string Rol_Nombre { get; set; }
        public string Rol_Id { get; set; }
        public string[] AniadirUsuariosIds { get; set; }
        public string[] EliminarUsuariosIds { get; set; }
    }
}
