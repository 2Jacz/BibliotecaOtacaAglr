using BibliotecaOtacaAglr.Models.Permisos.Entity;
using System.Collections.Generic;

namespace BibliotecaOtacaAglr.Data.Others.BaseClaims
{
    public static class PermisosBaseRolUsuario
    {
        /// <summary>
        /// Lista contenedora de todos los permisos de los usuarios
        /// </summary>
        public static List<Permiso> User_Claims = new List<Permiso>()
        {
            new Permiso(1,"Administrador","Permisos de administrador"),

            new Permiso(2,"Crear IUsuario","Puede crear usuarios"),
            new Permiso(3,"Borrar IUsuario","Puede borrar usuarios"),
            new Permiso(4,"Gestionar Roles","Puede gestionar roles"),

            new Permiso(5,"Crear Generos","Puede crear generos"),
            new Permiso(6,"Editar Generos","Puede editar generos"),
            new Permiso(7,"Borrar Generos","Puede borrar generos"),

            new Permiso(8,"Crear Anime","Puede crear animes"),
            new Permiso(9,"Editar Anime","Puede editar animes"),
            new Permiso(10,"Borrar Anime","Puede borrar animes"),

            new Permiso(11,"Crear Anime Capitulo","Puede crear capitulos en animes"),
            new Permiso(12,"Editar Anime Capitulo","Puede editar capitulos en animes"),
            new Permiso(13,"Borrar Anime Capitulo","Puede borrar capitulos en animes"),

            new Permiso(14,"Crear Manga","Puede crear mangas"),
            new Permiso(15,"Editar Manga","Puede editar mangas"),
            new Permiso(16,"Borrar Manga","Puede borrar mangas"),

            new Permiso(17,"Crear Manga Capitulos","Puede crear capitulos en mangas"),
            new Permiso(18,"Editar Manga Capitulos","Puede editar capitulos en mangas"),
            new Permiso(19,"Borrar Manga Capitulos","Puede borrar capitulos en mangas"),

            new Permiso(20,"Crear Manga Capitulos Paginas","Puede crear paginas en capitulos en mangas"),
            new Permiso(21,"Editar Manga Capitulos Paginas","Puede editar paginas en mangas"),
            new Permiso(22,"Borrar Manga Capitulos Paginas","Puede borrar paginas en mangas")
        };

        /// <summary>
        /// Lista contenedora de todos los permisos de los roles
        /// </summary>
        public static List<Permiso> Rol_Claims = new List<Permiso>()
        {

        };
    }
}
