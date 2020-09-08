using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulos.ViewModel
{
    /// <summary>
    /// Instacia para navegar entre capitulos
    /// </summary>
    public class Manga_CapituloNavegacionViewModel
    {
        /// <summary>
        /// Capitulo actual
        /// </summary>
        public Manga_Capitulo Cap_actual { get; set; }
        /// <summary>
        /// Capitulo siguiente
        /// </summary>
        public Manga_Capitulo Cap_siguiente { get; set; }
        /// <summary>
        /// Capitulo anterior
        /// </summary>
        public Manga_Capitulo Cap_anterior { get; set; }
        /// <summary>
        /// Capitulo final
        /// </summary>
        public double Cap_final { get; set; }
        /// <summary>
        /// Capitulo inicial
        /// </summary>
        public double Cap_inicial { get; set; }
    }
}
