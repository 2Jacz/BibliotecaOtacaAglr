using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using System;
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
        [Required(ErrorMessage = "Nombre del manga requerido")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del manga
        /// </summary>
        [Required(ErrorMessage = "Descripcion requerida")]
        [StringLength(600, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 15)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de publicacion del anime
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime? Fecha_publicacion { get; set; }

        /// <summary>
        /// Portada del manga en arreglo de bytes
        /// </summary>
        [Required(ErrorMessage = "Imagen de portada del manga requerida")]
        public byte[] Portada { get; set; }

        /// <summary>
        /// Fecha de subida del anime
        /// </summary>
        [Required]
        public DateTime Fecha_subida { get; set; }

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
            Fecha_subida = DateTime.UtcNow;
        }
    }
}
