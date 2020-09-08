using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Anime_Episodios.ViewModel
{
    public class Anime_EpisodioNavegacionEntreEpsViewModel
    {
        /// <summary>
        /// Episodio actual
        /// </summary>
        [Display(Name = "Episodio actual")]
        public Anime_Episodio Ep_actual { get; set; }
        /// <summary>
        /// Episodio anterior
        /// </summary>
        [Display(Name = "Episodio anterior")]
        public Anime_Episodio Ep_anterior { get; set; }
        /// <summary>
        /// Episodio siguiente
        /// </summary>
        [Display(Name = "Episodio siguiente")]
        public Anime_Episodio Ep_siguiente { get; set; }
        /// <summary>
        /// Ultimo episodio
        /// </summary>
        [Display(Name = "Ultimo Episodio")]
        public double Ultimo_ep { get; set; }
        /// <summary>
        /// Primer episodio
        /// </summary>
        [Display(Name = "Primer Episodio")]
        public double Primer_ep { get; set; }
    }
}
