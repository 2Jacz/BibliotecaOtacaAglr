using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Others.ViewModel.Home
{
    /// <summary>
    /// Informacion para mostrar en el home/index
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<Anime_Episodio> AnimeUltimos10EpsAgregados { get; set; }

        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<Anime> Ultimos7AnimesAgregados { get; set; }

        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<Manga> Ultimos7MangasAgregados { get; set; }

        /// <summary>
        /// Los 10 episodios recien subidos de animes
        /// </summary>
        public List<Manga_Capitulo> MangaUltimos10CapsAgregados { get; set; }

        public HomeIndexViewModel()
        {
            AnimeUltimos10EpsAgregados = new List<Anime_Episodio>();
            MangaUltimos10CapsAgregados = new List<Manga_Capitulo>();
            Ultimos7AnimesAgregados = new List<Anime>();
            Ultimos7MangasAgregados = new List<Manga>();
        }
    }
}
