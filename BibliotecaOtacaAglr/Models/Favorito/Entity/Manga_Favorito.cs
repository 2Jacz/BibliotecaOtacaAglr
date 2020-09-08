using BibliotecaOtacaAglr.Models.Mangas.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;

namespace BibliotecaOtacaAglr.Models.Favorito.Entity
{
    /// <summary>
    /// Instancia para aniadir un manga favorito a un usuario
    /// </summary>
    public class Manga_Favorito
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string UsuarioId { get; set; }
        /// <summary>
        /// Identificador del manga
        /// </summary>
        public int MangaID { get; set; }

        /// <summary>
        /// Seniala si el manga es favorito
        /// </summary>
        public bool Favorito { get; set; }
        /// <summary>
        /// Instancia del usuario a agregarle un manga favorito
        /// </summary>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// Instancia del manga al que tendra un usuario como fan(?)
        /// </summary>
        public Manga Manga { get; set; }
    }
}
