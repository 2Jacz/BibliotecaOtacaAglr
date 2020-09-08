using MailKit.Net.Smtp;
using MimeKit;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria
{
    /// <summary>
    /// Instancia con la funcionalidad de envio de correos
    /// </summary>
    public class Mensajero : IMensajero
    {
        private readonly MensajeroConfiguracion _emailConfig;

        public Mensajero(MensajeroConfiguracion emailConfig)
        {
            _emailConfig = emailConfig;
        }

        /// <summary>
        /// Ejecuta el envio de correo de forma asincrona
        /// </summary>
        /// <param name="message">contenido del correo electronico</param>
        public void EnviarCorreo(Mensaje message)
        {
            var emailMessage = CreateEmailMessage(message);

            Enviar(emailMessage);
        }

        /// <summary>
        /// Ejecuta el envio de correo de forma asincrona
        /// </summary>
        /// <param name="message">contenido del correo electronico</param>
        /// <returns>An asyncrhonous task context</returns>
        public async Task EnviarCorreoAsync(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);

            await EnviarAsync(mailMessage);
        }

        /// <summary>
        /// Se encarga de armar el correo electgronico
        /// </summary>
        /// <param name="message">Contenido del correo electronico</param>
        /// <returns>Contenido del correo en formato de correo electronico</returns>
        private MimeMessage CreateEmailMessage(Mensaje message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From, _emailConfig.UserName));
            emailMessage.To.AddRange(message.Para);
            emailMessage.Subject = message.Asunto;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Contenido) };

            if (message.DocumentosAdjuntos != null && message.DocumentosAdjuntos.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.DocumentosAdjuntos)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }

        /// <summary>
        /// Se encarga de enviar el correo
        /// </summary>
        /// <param name="mailMessage">Contenido del correo en formato de correo electronico</param>
        private void Enviar(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {

                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// Se encarga de enviar el correo de forma asincrona
        /// </summary>
        /// <param name="mailMessage">Contenido del correo en formato de correo electronico</param>
        /// <returns>An asyncrhonous task context</returns>
        private async Task EnviarAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
