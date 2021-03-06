﻿using BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Anime_Episodios.ViewModel
{
    public class Anime_EpisodioEditarViewModel
    {
        /// <summary>
        /// Identificador del episodio
        /// </summary>
        [Required]
        public int EpisodioId { get; set; }
        /// <summary>
        /// Titulo del episodio
        /// </summary>
        [Required]
        [Display(Name = "Titulo del episodio")]
        public string Titulo_episodio { get; set; }
        /// <summary>
        /// Numero del capitulo
        /// </summary>
        [Required]
        [Display(Name = "Numero del episodio")]
        public double Numero_episodio { get; set; }
        /// <summary>
        /// Relacion con las url donde esta alojado el episodio
        /// </summary>
        public List<Anime_Episodio_Servidor> UrlServidores { get; set; }
        /// <summary>
        /// Nombre completo del archivo subido (incluyendo extencion)
        /// </summary>
        [Required(ErrorMessage = "Seleccione un capitulo o escriba un nombre")]
        [Display(Name = "Nombre del Ep (con extencion ej: ep.mp4, ep.avi...) o seleccionelo en el input de abajo")]
        public string Nombre_Archivo { get; set; }
    }
}
