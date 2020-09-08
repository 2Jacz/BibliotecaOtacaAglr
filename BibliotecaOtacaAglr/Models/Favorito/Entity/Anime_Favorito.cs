using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaOtacaAglr.Models.Favorito.Entity
{
    /// <summary>
    /// Instancia para aniadir un anime favorito a un usuario
    /// </summary>
    [Authorize]
    public class Anime_Favorito
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string UsuarioId { get; set; }
        /// <summary>
        /// Identificador del anime
        /// </summary>
        public int AnimeID { get; set; }

        /// <summary>
        /// Seniala si el anime es favorito
        /// </summary>
        public bool Favorito { get; set; }

        /// <summary>
        /// Instancia del usuario a agregarle un anime favorito
        /// </summary>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// Instancia del anime al que tendra un usuario como fan(?)
        /// </summary>
        public Anime Anime { get; set; }
    }
}
