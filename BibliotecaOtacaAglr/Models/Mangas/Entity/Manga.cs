using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Mangas.Entity
{
    /// <summary>
    /// Modelo con los datos del manga que tendra la base de datos
    /// </summary>
    public class Manga
    {
        /// <summary>
        /// Identificador del manga
        /// </summary>
        [Key]
        public int MangaId { get; set; }
        /// <summary>
        /// Nombre del manga
        /// </summary>
        [Required]
        public string Nombre { get; set; }
        /// <summary>
        /// Descripcion del manga
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        /// <summary>
        /// Portada del manga en arreglo de bytes
        /// </summary>
        public byte[] Portada { get; set; }
        /// <summary>
        /// Relacion con los generos que tiene el manga
        /// </summary>
        public List<Manga_Genero> Generos { get; set; }
        /// <summary>
        /// Relacion con los capitulos que tiene el manga
        /// </summary>
        public List<Manga_Capitulo> Capitulos { get; set; }

        /// <summary>
        /// Instancia para crear un manga en la base de datos
        /// </summary>
        public Manga()
        {
            Generos = new List<Manga_Genero>();
            Capitulos = new List<Manga_Capitulo>();
        }
    }
}
