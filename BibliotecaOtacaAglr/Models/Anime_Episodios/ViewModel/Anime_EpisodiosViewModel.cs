using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using BibliotecaOtacaAglr.Models.Animes.Entity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Anime_Episodios.ViewModel
{
    public class Anime_EpisodiosViewModel
    {
        public Anime Anime { get; set; }

        public List<Anime_Episodio> Episodios { get; set; }
    }
}
