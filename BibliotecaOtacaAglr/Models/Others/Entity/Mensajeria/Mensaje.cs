using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Mensajeria
{
    /// <summary>
    /// Modelo con la informacion a enviar por correo electronico
    /// </summary>
    public class Mensaje
    {
        /// <summary>
        /// Receptor, a quien va dirigido el mensaje
        /// </summary>
        public List<MailboxAddress> Para { get; set; }

        /// <summary>
        /// Por que, para que fue enviado el mensale...o que es
        /// </summary>
        public string Asunto { get; set; }

        /// <summary>
        /// Contenido del mensaje
        /// </summary>
        public string Contenido { get; set; }

        /// <summary>
        /// Archivos que se enviaran junto al mensaje
        /// </summary>
        public IFormFileCollection DocumentosAdjuntos { get; set; }

        /// <summary>
        /// Instancia para crear un correo electronico
        /// </summary>
        /// <param name="para">A quien va dirigido</param>
        /// <param name="asunto">Asunto del correo</param>
        /// <param name="contenido">Mensaje o cointenidos del correo</param>
        /// <param name="documentosAdjuntos">Documentos adjuntos</param>
        public Mensaje(IEnumerable<string> para, string asunto, string contenido, IFormFileCollection documentosAdjuntos)
        {
            Para = new List<MailboxAddress>();

            Para.AddRange(para.Select(x => new MailboxAddress(x)));
            Asunto = asunto;
            Contenido = contenido;
            DocumentosAdjuntos = documentosAdjuntos;
        }
    }
}
