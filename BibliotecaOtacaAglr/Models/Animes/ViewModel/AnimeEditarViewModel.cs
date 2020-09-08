using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using Microsoft.AspNetCore.Http;
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
        /// Nombre del anime
        /// </summary>
        [Key]
        public int AnimeId { get; set; }
        /// <summary>
        /// Descripcion del anime
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
        /// Portada del anime
        /// </summary>
        public IFormFile Portada { get; set; }
        /// <summary>
        /// Numero de episodios del anime
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
        /// Generos del anime
        /// </summary>
        [Display(Name = "Episodios")]
        public List<Anime_Episodio> Episodios { get; set; }


        /// <summary>
        /// Instancia para editar animes
        /// </summary>
        public AnimeEditarViewModel()
        {
            GenerosActivos = new List<GeneroAsignadoViewModel>();
        }
    }
}
