using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria
{
    /// <summary>
    /// Interfaz con la funcionalidad de envio de correos electronicos
    /// </summary>
    public interface IMensajero
    {
        /// <summary>
        /// enviar correo
        /// </summary>
        /// <param name="mensaje">Correo con informacion</param>
        void EnviarCorreo(Mensaje mensaje);

        /// <summary>
        /// enviar correo de forma asincrona
        /// </summary>
        /// <param name="mensaje">Correo con informacion</param>
        /// <returns></returns>
        Task EnviarCorreoAsync(Mensaje mensaje);
    }
}
