using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.UsuarioTokens
{
    /// <summary>
    /// Modelo para regresar la informacion de usuario y su token
    /// </summary>
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
