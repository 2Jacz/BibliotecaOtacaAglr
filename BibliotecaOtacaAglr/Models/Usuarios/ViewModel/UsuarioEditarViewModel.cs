using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    public class UsuarioEditarViewModel
    {
        [Required(ErrorMessage = "Ocurrio un error al localizar el usuario.")]
        [Display(Name = "Clave")]
        public string Id { get; set; }

        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Debe de tener un nombre de usuario")]
        public string Nick { get; set; }

        [EmailAddress(ErrorMessage = "Formato de correo invalido.")]
        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Llene con un correo valido")]
        public string Correo { get; set; }

        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        [Display(Name = "Contrasenia")]
        public string Contrasenia { get; set; }
    }
}
