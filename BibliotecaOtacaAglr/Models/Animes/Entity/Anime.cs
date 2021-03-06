﻿using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using BibliotecaOtacaAglr.Models.Generos.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BibliotecaOtacaAglr.Models.Animes.Entity
{
    /// <summary>
    /// Modelo con los datos de anime que esta en la base de datos
    /// </summary>
    public class Anime
    {
        /// <summary>
        /// Identificacdor principal
        /// </summary>
        [Key]
        public int AnimeId { get; set; }

        /// <summary>
        /// Nombre del anime
        /// </summary>
        [Required(ErrorMessage = "Nombre del anime requerido")]
        [StringLength(100, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 2)]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del anime
        /// </summary>
        [Required(ErrorMessage = "Descripcion del anime requerida")]
        [StringLength(600, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 15)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Imagen de portada en arreglo de bytes del anime
        /// </summary>
        [Required(ErrorMessage = "Imagen de portada requerida")]
        public byte[] Portada { get; set; }

        /// <summary>
        /// Fecha de publicacion del anime
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime? Fecha_publicacion { get; set; }

        /// <summary>
        /// Fecha de subida del anime
        /// </summary>
        [Required]
        public DateTime Fecha_subida { get; set; }

        /// <summary>
        /// Numero de episodios que tiene el anime (no incluir OVA ni peliculas)
        /// </summary>
        [Required(ErrorMessage = "Cantidad de episodios requerida")]
        [Display(Name = "Numero de episodios")]
        public int Numero_episodios { get; set; }

        /// <summary>
        /// Relacion con Generos M:M (generos que tiene asignado el anime)
        /// </summary>
        [JsonIgnore]
        public List<Anime_Genero> Generos { get; set; }

        [NotMapped]
        public IList<Genero> ListaGeneros => Generos.Select(m => m.Genero).ToList();

        /// <summary>
        /// Relacion con Generos 1:M (episodios que tiene asignado el anime)
        /// </summary>
        public List<Anime_Episodio> Episodios { get; set; }

        /// <summary>
        /// Instancia para crear un anime a la base de datos
        /// </summary>
        public Anime()
        {
            Generos = new List<Anime_Genero>();
            Episodios = new List<Anime_Episodio>();
            Fecha_subida = DateTime.UtcNow;
        }
    }
}
