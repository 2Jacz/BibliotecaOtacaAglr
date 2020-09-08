using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Validadores
{
    /// <summary>
    /// Valida que el nombre de usuario cumpla con ciertos criterios
    /// *No sea una palabra prohibida
    /// *Tenga al menos 4 caracteres
    /// </summary>
    public class ValidarNickUsuario : ValidationAttribute
    {
        private readonly string[] BlackList = new string[] {
            "puto",
            "culo",
            "pepa",
            "cola",
            "cagada",
            "cerote",
            "cuacha",
            "puta",
            "panocha",
            "panochon",
            "verga",
            "pene",
            "vagina",
            "mierda",
            "culear"
        };

        public override bool IsValid(object value)
        {
            if (BlackList.Any(nick => nick == value.ToString().ToLower()))
            {
                return false;
            }

            if (value.ToString().Trim().Length < 4)
            {
                return false;
            }

            return true;
        }
    }
}