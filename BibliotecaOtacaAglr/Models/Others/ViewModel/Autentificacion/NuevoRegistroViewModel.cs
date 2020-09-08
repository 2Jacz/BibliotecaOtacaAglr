using BibliotecaOtacaAglr.Models.Others.Entity.Validadores;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Others.ViewModel.Autentificacion
{
    /// <summary>
    /// Modelo para el registro de usuario
    /// </summary>
    public class NuevoRegistroViewModel
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        [Display(Name = "Nombre de usuario")]
        [Remote(action: "ValidarNickCorrecto", controller: "Auth")]
        [ValidarNickUsuario(ErrorMessage = "Nick no permitido")]
        [StringLength(12, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 4)]
        public string Nick { get; set; }

        /// <summary>
        /// Correo de usuario
        /// </summary>
        [Required(ErrorMessage = "Correo electronico requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        [Display(Name = "Correo")]
        [Remote(action: "ValidarCorreoExistente", controller: "Auth")]
        public string Correo { get; set; }

        /// <summary>
        /// Contrasenia de usuario
        /// </summary>
        [Required(ErrorMessage = "Contrasenia requerida")]
        [StringLength(10, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasenia")]
        public string Contrasenia { get; set; }

        /// <summary>
        /// Confirmar la contrasenia establecida
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contrasenia")]
        [Compare("Contrasenia", ErrorMessage = "Las contrasenias no son iguales")]
        public string ConfirmarContrasenia { get; set; }
    }
}
