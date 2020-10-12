using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Animes.ViewModel
{
    /// <summary>
    /// Modelo de Anime digido a la vista de crear anime
    /// </summary>
    public class AnimeCrearViewModel
    {
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
        /// Fecha de publicacion del anime
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime Fecha_publicacion { get; set; }

        /// <summary>
        /// Imagen de la portada que tendra el anime
        /// </summary>
        [DataType(DataType.Upload, ErrorMessage = "Formato de archivo invalido")]
        public IFormFile Portada { get; set; }

        /// <summary>
        /// Numeros de episodio del anime
        /// </summary>
        [Required(ErrorMessage = "Numero de episodios requerido")]
        [Display(Name = "Numero de episodios")]
        public int Numero_episodios { get; set; }

        /// <summary>
        /// Generos del anime
        /// </summary>
        [Display(Name = "Generos")]
        public List<GeneroAsignadoViewModel> GenerosActivos { get; set; }

        /// <summary>
        /// Instancia para crear animes
        /// </summary>
        public AnimeCrearViewModel()
        {
            GenerosActivos = new List<GeneroAsignadoViewModel>();
        }
    }
}
