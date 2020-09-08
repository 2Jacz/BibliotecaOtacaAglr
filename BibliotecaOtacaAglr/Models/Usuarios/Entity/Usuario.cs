using BibliotecaOtacaAglr.Models.Favorito.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Models.Usuarios.Entity
{
    /// <summary>
    /// Datos extra a aniadir a IdentityUser
    /// </summary>
    public class Usuario : IdentityUser
    {
        /// <summary>
        /// Relacion con los animes favoritos del usuario
        /// </summary>
        public List<Anime_Favorito> Animes_Favoritos { get; set; }
        /// <summary>
        /// Relacion con los mangas favoritos del usuario
        /// </summary>
        public List<Manga_Favorito> Mangas_Favoritos { get; set; }

        public Usuario()
        {

        }
    }
}
