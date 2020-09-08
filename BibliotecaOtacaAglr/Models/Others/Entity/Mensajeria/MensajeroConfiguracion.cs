namespace BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria
{
    /// <summary>
    /// Instancia con la informacion del servidor smtp
    /// </summary>
    public class MensajeroConfiguracion
    {
        /// <summary>
        /// Correo electronico emisor de correos
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Servidor SMTP
        /// </summary>
        public string SmtpServer { get; set; }
        /// <summary>
        /// Puerto por el que se enviaran los correos
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// IUsuario/Correo electronico de la cuenta que enviara coreos
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Contrasenia electronico de la cuenta que enviara coreos
        /// </summary>
        public string Password { get; set; }
    }
}
