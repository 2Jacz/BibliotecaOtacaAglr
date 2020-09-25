using BibliotecaOtacaAglr.Models.Generos.Entity;
using System.Text.Json.Serialization;

namespace BibliotecaOtacaAglr.Models.Animes.Entity
{
    /// <summary>
    /// Instancia para agregar un genero a un anime
    /// </summary>
    public class Anime_Genero
    {
        /// <summary>
        /// Id del anime a agregar el genero
        /// </summary>
        public int AnimeId { get; set; }
        /// <summary>
        /// Instancia de anime a agregar el genero o navegador
        /// </summary>
        public Anime Anime { get; set; }

        /// <summary>
        /// Id del genero a agregar al anime
        /// </summary>
        public int GeneroId { get; set; }
        /// <summary>
        /// Instancia del genero a agregar al anime o navegador
        /// </summary>
        public Genero Genero { get; set; }
    }
}
