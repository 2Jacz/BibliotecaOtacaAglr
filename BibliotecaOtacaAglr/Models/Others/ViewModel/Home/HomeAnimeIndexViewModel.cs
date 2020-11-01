using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Others.ViewModel.Home
{
    /// <summary>
    /// Informacion para mostrar en el home/index
    /// </summary>
    public class HomeAnimeIndexViewModel
    {
        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<HomeAnime_EpisodioViewModel> AnimeUltimos12EpsAgregados { get; set; }

        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<HomeAnimeViewModel> Ultimos9AnimesAgregados { get; set; }

        public HomeAnimeIndexViewModel()
        {
            AnimeUltimos12EpsAgregados = new List<HomeAnime_EpisodioViewModel>();
            Ultimos9AnimesAgregados = new List<HomeAnimeViewModel>();
        }
    }

    public class HomeAnime_EpisodioViewModel
    {
        public int EpisodioId { get; set; }

        public double Numero_episodio { get; set; }

        public string Nombre_anime { get; set; }

        public byte[] Anime_portada { get; set; }
    }

    public class HomeAnimeViewModel
    {
        public int AnimeId { get; set; }

        public string Nombre { get; set; }

        public byte[] Portada { get; set; }
    }
}
