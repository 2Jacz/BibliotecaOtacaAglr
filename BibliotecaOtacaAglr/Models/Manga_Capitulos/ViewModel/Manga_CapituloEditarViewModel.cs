using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulos.ViewModel
{
    /// <summary>
    /// Modelo para editar capitulos de manga en la base de datos
    /// </summary>
    public class Manga_CapituloEditarViewModel
    {
        /// <summary>
        /// Nombre del capitulo
        /// </summary>
        [Required]
        public string Nombre { get; set; }
        /// <summary>
        /// Numero de capitulo
        /// </summary>
        [Display(Name = "Numero del capitulo")]
        [Required]
        public double Num_capitulo { get; set; }
    }
}
