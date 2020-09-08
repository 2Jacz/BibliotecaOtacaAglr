using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    public class UsuarioRecuperarContraseniaViewModel
    {
        [Required(ErrorMessage = "Correo electronico requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Contrasenia requerida")]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasenia")]
        public string Contrasenia { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contrasenia")]
        [Compare("Contrasenia", ErrorMessage = "Las contrasenias no son iguales")]
        public string ConfirmarContrasenia { get; set; }


        public string TokenRecuperacion { get; set; }
    }
}
