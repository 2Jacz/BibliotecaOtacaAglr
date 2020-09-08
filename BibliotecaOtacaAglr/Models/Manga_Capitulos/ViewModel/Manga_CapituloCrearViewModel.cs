using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulos.ViewModel
{
    /// <summary>
    /// Modelo con los datos para crear un capitulo de manga
    /// </summary>
    public class Manga_CapituloCrearViewModel
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
        public double Num_capitulo { get; set; }
        /// <summary>
        /// Relacion con las paginas que contiene el capitulo
        /// </summary>
        public List<Manga_Capitulo_Pagina> Paginas { get; set; }
        /// <summary>
        /// Relacion con el manga al que pertenece el capitulo
        /// </summary>
        [ForeignKey("Manga")]
        public int MangaId { get; set; }
        /// <summary>
        /// Instancia del manga al que pertenece el capitulo (o navegacion)
        /// </summary>
        public Manga Manga { get; set; }
        /// <summary>
        /// Instancia para crear un capitulo de manga
        /// </summary>
        public Manga_CapituloCrearViewModel()
        {
            Paginas = new List<Manga_Capitulo_Pagina>();
        }
    }
}
