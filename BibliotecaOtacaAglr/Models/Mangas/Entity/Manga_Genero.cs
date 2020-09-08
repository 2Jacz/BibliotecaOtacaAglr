using BibliotecaOtacaAglr.Models.Generos.Entity;

namespace BibliotecaOtacaAglr.Models.Mangas.Entity
{
    /// <summary>
    /// Instancia para aniar generos a un manga
    /// </summary>
    public class Manga_Genero
    {
        /// <summary>
        /// Identificadoe del manga
        /// </summary>
        public int MangaId { get; set; }
        /// <summary>
        /// Instancia del manga al que se aniadira el genero
        /// </summary>
        public Manga Manga { get; set; }

        /// <summary>
        /// Identificador del genero
        /// </summary>
        public int GeneroId { get; set; }
        /// <summary>
        /// Instacia del genero al que se le agregara el manga
        /// </summary>
        public Genero Genero { get; set; }
    }
}
