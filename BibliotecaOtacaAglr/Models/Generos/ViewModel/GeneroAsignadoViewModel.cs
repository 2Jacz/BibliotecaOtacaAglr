using BibliotecaOtacaAglr.Models.Generos.Entity;

namespace BibliotecaOtacaAglr.Models.Generos.ViewModel
{
    /// <summary>
    /// Determina si el anime/manga tiene el genero asignado o no
    /// </summary>
    public class GeneroAsignadoViewModel
    {
        /// <summary>
        /// El genero
        /// </summary>
        public Genero Genero { get; set; }

        /// <summary>
        /// Determina si el genero esta asignado o no
        /// </summary>
        public bool Activo { get; set; }
    }
}