using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores;
using BibliotecaOtacaAglr.Models.Animes.Entity;


namespace BibliotecaOtacaAglr.Models.Anime_Episodios.Entity
{
    /// <summary>
    /// Modelo con los datos de un episodio de anime que esta en la base de datos
    /// </summary>
    public class Anime_Episodio
    {
        /// <summary>
        /// Identificacdor principal
        /// </summary>
        [Key]
        public int EpisodioId { get; set; }

        /// <summary>
        /// Titulo del episodio
        /// </summary>
        [Required]
        [Display(Name = "Titulo del capitulo")]
        public string Titulo_episodio { get; set; }

        /// <summary>
        /// Numero de episodio
        /// </summary>
        [Required]
        [Display(Name = "Numero del episodio")]
        public double Numero_episodio { get; set; }

        /// <summary>
        /// Relacion con las url donde esta alojado el episodio
        /// </summary>
        public List<Anime_Episodio_Servidor> UrlServidores { get; set; }

        /// <summary>
        /// Nombre del archivo (con extencion)
        /// </summary>
        [Required]
        public string Nombre_archivo { get; set; }

        /// <summary>
        /// Fecha de subida del ep
        /// </summary>
        public DateTime Fecha_subida { get; set; }

        /// <summary>
        /// Relacion al anime que pertenece el episodio
        /// </summary>
        [Required]
        [ForeignKey("Anime")]
        public int AnimeId { get; set; }

        /// <summary>
        /// Instancia del anime al que pertenece el episodio (o navegacion)
        /// </summary>
        [Required]
        [JsonIgnore]
        public Anime Anime { get; set; }

        /// <summary>
        /// Instacia para agregar un episodio de anime a la base de datos
        /// </summary>
        public Anime_Episodio()
        {
            UrlServidores = new List<Anime_Episodio_Servidor>();
            Anime = new Anime();
            Fecha_subida = DateTime.UtcNow;
        }
    }
}
