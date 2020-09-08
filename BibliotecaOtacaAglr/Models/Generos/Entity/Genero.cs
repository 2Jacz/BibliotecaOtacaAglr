using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Generos.Entity
{
    /// <summary>
    /// Modelo con los datos que tendra un genero en la base de datos
    /// </summary>
    public class Genero
    {
        /// <summary>
        /// Identificador del genero
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Nombre del genero
        /// </summary>
        [Required]
        public string Nombre { get; set; }
        /// <summary>
        /// Relacion con los animes que tengan ese genero
        /// </summary>
        public List<Anime_Genero> Animes { get; set; }
        /// <summary>
        /// Relacion con los mangas que tengan ese genero
        /// </summary>
        public List<Manga_Genero> Mangas { get; set; }

        /// <summary>
        /// Instancia para crear un genero en la base de datos
        /// </summary>
        public Genero()
        {
            Animes = new List<Anime_Genero>();
            Mangas = new List<Manga_Genero>();
        }
    }
}
