using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using Microsoft.AspNetCore.Http;
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
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del anime
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Imagen de la portada que tendra el anime
        /// </summary>
        public IFormFile Portada { get; set; }

        /// <summary>
        /// Numeros de episodio del anime
        /// </summary>
        [Required]
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
