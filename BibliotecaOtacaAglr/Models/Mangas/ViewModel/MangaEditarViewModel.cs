using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Mangas.ViewModel
{
    public class MangaEditarViewModel
    {
        /// <summary>
        /// Identificador del manga
        /// </summary>
        [Required]
        public int Id { get; set; }
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
        public IFormFile Portada { get; set; }
        /// <summary>
        /// Relacion con los generos que tiene el manga
        /// </summary>
        public List<GeneroAsignadoViewModel> GenerosActivos { get; set; }
        /// <summary>
        /// Relacion con los capitulos que tiene el manga
        /// </summary>
        public List<Manga_Capitulo> Capitulos { get; set; }

        /// <summary>
        /// Instancia para editar un manga en la base de datos
        /// </summary>
        public MangaEditarViewModel()
        {
            GenerosActivos = new List<GeneroAsignadoViewModel>();
            Capitulos = new List<Manga_Capitulo>();
        }
    }
}
