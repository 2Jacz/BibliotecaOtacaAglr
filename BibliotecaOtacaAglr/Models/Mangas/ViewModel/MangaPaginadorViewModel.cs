using BibliotecaOtacaAglr.Models.Mangas.Entity;
using BibliotecaOtacaAglr.Models.Others.Entity.Paginador;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Mangas.ViewModel
{
    /// <summary>
    /// Model de paginador de mangas
    /// </summary>
    public class MangaPaginadorViewModel
    {
        /// <summary>
        /// Lista con los mangas
        /// </summary>
        public IEnumerable<Manga> Datos { get; set; }
        /// <summary>
        /// Configuracion de la paginacion
        /// </summary>
        public Paginado Pagina { get; set; }
    }
}
