using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.UsuarioTokens
{
    public class UsuarioToken
    {
        [Key]
        public int TokenID { get; set; }
        public string UsuarioId { get; set; }
        public bool Valido { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Expiracion { get; set; }
        public string Token { get; set; }

        public UsuarioToken()
        {
            Fecha_Creacion = DateTime.Now;
        }
    }
}
