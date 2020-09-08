using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Usuarios.ViewModel
{
    public class UsuarioEditarContrasenia
    {
        [Required(ErrorMessage = "Contrasenia requerida")]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        public string ContraseniaActual { get; set; }

        [Required(ErrorMessage = "nueva contrasenia requerida")]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        public string ContraseniaNueva { get; set; }

        [Required(ErrorMessage = "Requere confirmar nueva contrasenia")]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        [Compare("ContraseniaNueva", ErrorMessage = "Las contrasenias no son iguales")]
        public string ConfirmarContraseniaNueva { get; set; }
    }
}
