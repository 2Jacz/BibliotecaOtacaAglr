using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Others.Entity.Paginador;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Animes.ViewModel
{
    /// <summary>
    /// Model de paginador de animes
    /// </summary>
    public class AnimePaginadorViewModel
    {
        /// <summary>
        /// Lista con los animes
        /// </summary>
        public IEnumerable<Anime> Datos { get; set; }
        /// <summary>
        /// Configuracion de la paginacion
        /// </summary>
        public Paginado Pagina { get; set; }
    }
}
