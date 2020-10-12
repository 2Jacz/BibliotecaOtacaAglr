using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public int GeneroId { get; set; }

        /// <summary>
        /// Nombre del genero
        /// </summary>
        [Required(ErrorMessage = "El genero debe tener un nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Relacion con los animes que tengan ese genero
        /// </summary>
        [JsonIgnore]
        public List<Anime_Genero> Animes { get; set; }

        [NotMapped]
        public IList<Anime> ListaAnimes => Animes.Select(m => m.Anime).ToList();

        /// <summary>
        /// Relacion con los mangas que tengan ese genero
        /// </summary>
        [JsonIgnore]
        public List<Manga_Genero> Mangas { get; set; }

        [NotMapped]
        public IList<Manga> ListaMangas => Mangas.Select(m => m.Manga).ToList();

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
