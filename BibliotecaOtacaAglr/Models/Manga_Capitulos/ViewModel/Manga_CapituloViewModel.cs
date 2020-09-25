
using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulos.ViewModel
{
    public class Manga_CapituloViewModel
    {
        public Manga Manga { get; set; }

        public List<Manga_Capitulo> Capitulos { get; set; }
    }
}
