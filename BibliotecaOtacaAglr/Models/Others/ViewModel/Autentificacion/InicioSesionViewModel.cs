using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Others.ViewModel.Autentificacion
{
    /// <summary>
    /// Modelo con los datos para poder auntentificarse en la aplicacion
    /// </summary>
    public class InicioSesionViewModel
    {
        /// <summary>
        /// Correo con el que se a registrado el usuario
        /// </summary>
        [EmailAddress(ErrorMessage = "Formato de correo electronico invalido")]
        [Required(ErrorMessage = "Ingrese un correo.")]
        public string Correo { get; set; }
        /// <summary>
        /// Contrasenia con la que se a registrado el usuario
        /// </summary>
        [DataType(DataType.Password, ErrorMessage = "Formato invalido.")]
        [Required(ErrorMessage = "Ingrese una contasenia")]
        public string Contrasenia { get; set; }

        /// <summary>
        /// Mantener la sesion iniciada (el tiempo de la sesion se especifica en startup.cs)
        /// </summary>
        [Display(Name = "Recordar en esta computadora")]
        public bool Recordar { get; set; }

        /// <summary>
        /// Si fue mandado de una pagina al registro de usuario, aqui se guardara la direccion para regresarlo al registrarse
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Si el usuario usa un inicio de sesion externo (google, facebook,etc...)
        /// </summary>
        public IList<AuthenticationScheme> LoginExternos { get; set; }
    }
}
