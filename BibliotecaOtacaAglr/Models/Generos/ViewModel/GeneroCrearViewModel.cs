using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Generos.ViewModel
{
    public class GeneroCrearViewModel
    {
        [Required(ErrorMessage = "El genero debe tener un nombre")]
        public string Nombre { get; set; }
    }
}
