using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Others.ViewModel.Home
{
    public class HomeMangaIndexViewModel
    {
        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<HomeMangaViewModel> Ultimos9MangasAgregados { get; set; }

        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<HomeManga_CapituloViewModel> MangaUltimos12CapsAgregados { get; set; }

        public HomeMangaIndexViewModel()
        {
            Ultimos9MangasAgregados = new List<HomeMangaViewModel>();
            MangaUltimos12CapsAgregados = new List<HomeManga_CapituloViewModel>();
        }
    }

    public class HomeMangaViewModel
    {
        public int MangaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public byte[] Portada { get; set; }
    }

    public class HomeManga_CapituloViewModel
    {
        public int CapituloId { get; set; }

        public double Numero_episodio { get; set; }

        public string Nombre_manga { get; set; }

        public byte[] Manga_portada { get; set; }
    }
}
