using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Others.Entity.RecuperarContrasenias
{
    /// <summary>
    /// Instancia para recuperar una contrasenia de usuario
    /// </summary>
    public class RecuperarContrasenia
    {
        /// <summary>
        /// Correo del usuario a recuperar contrasenia
        /// </summary>
        [Required(ErrorMessage = "Correo electronico requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
    }
}
