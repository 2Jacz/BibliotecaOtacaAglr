using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Animes.ViewModel
{
    /// <summary>
    /// Modelo de Anime digido a la vista de editar anime
    /// </summary>
    public class AnimeEditarViewModel
    {
        /// <summary>
        /// Identificador del anime
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
        [Required]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de publicacion del anime
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime? Fecha_publicacion { get; set; }

        /// <summary>
        /// Portada del anime
        /// </summary>
        [DataType(DataType.Upload, ErrorMessage = "Formato de archivo invalido")]
        public IFormFile Portada { get; set; }

        /// <summary>
        /// Numero de episodios del anime
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
        /// Instancia para editar animes
        /// </summary>
        public AnimeEditarViewModel()
        {
            GenerosActivos = new List<GeneroAsignadoViewModel>();
        }
    }
}
