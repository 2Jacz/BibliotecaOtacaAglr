using BibliotecaOtacaAglr.Data.Others.BaseClaims;
using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores;
using BibliotecaOtacaAglr.Models.Animes.Entity;
using BibliotecaOtacaAglr.Models.Favorito.Entity;
using BibliotecaOtacaAglr.Models.Generos.Entity;
using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using BibliotecaOtacaAglr.Models.Permisos.Entity;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using BibliotecaOtacaAglr.Models.UsuarioTokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOtacaAglr.Data.DataBaseContext
{
    public class BibliotecaOtakaBDContext : IdentityDbContext<Usuario>
    {
        public BibliotecaOtakaBDContext(DbContextOptions<BibliotecaOtakaBDContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Anime_Entity
            modelBuilder.Entity<Anime>()
               .HasMany(a => a.Episodios)
               .WithOne(e => e.Anime)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Anime_Episodio>()
               .HasOne(e => e.Anime)
               .WithMany(a => a.Episodios)
               .HasForeignKey(e => e.AnimeId);

            modelBuilder.Entity<Anime_Episodio>()
               .HasMany(e => e.UrlServidores)
               .WithOne(a => a.Anime_Episodio);

            modelBuilder.Entity<Anime_Episodio_Servidor>()
                .HasOne(af => af.Anime_Episodio)
                .WithMany(u => u.UrlServidores)
                .HasForeignKey(af => af.Anime_EpisodioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Anime_Genero>()
            .HasKey(a => new { a.AnimeId, a.GeneroId });

            modelBuilder.Entity<Anime_Genero>()
                .HasOne(ag => ag.Anime)
                .WithMany(a => a.Generos)
                .HasForeignKey(ag => ag.AnimeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Anime_Genero>()
                .HasOne(ag => ag.Genero)
                .WithMany(g => g.Animes)
                .HasForeignKey(ag => ag.GeneroId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Anime_Favorito>()
            .HasKey(a => new { a.AnimeID, a.UsuarioId });

            modelBuilder.Entity<Anime_Favorito>()
                .HasOne(af => af.Usuario)
                .WithMany(u => u.Animes_Favoritos)
                .HasForeignKey(af => af.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Manga_Entity
            modelBuilder.Entity<Manga>()
               .HasMany(m => m.Capitulos)
               .WithOne(c => c.Manga);

            modelBuilder.Entity<Manga_Capitulo>()
               .HasOne(c => c.Manga)
               .WithMany(p => p.Capitulos)
               .HasForeignKey(c => c.MangaId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Manga_Capitulo>()
              .HasMany(p => p.Paginas)
              .WithOne(c => c.Capitulo);

            modelBuilder.Entity<Manga_Capitulo_Pagina>()
               .HasOne(c => c.Capitulo)
               .WithMany(p => p.Paginas)
               .HasForeignKey(c => c.CapituloId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Manga_Genero>()
                .HasKey(a => new { a.MangaId, a.GeneroId });

            modelBuilder.Entity<Manga_Genero>()
                .HasOne(ag => ag.Manga)
                .WithMany(m => m.Generos)
                .HasForeignKey(ag => ag.MangaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Manga_Genero>()
                .HasOne(ag => ag.Genero)
                .WithMany(g => g.Mangas)
                .HasForeignKey(ag => ag.GeneroId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Manga_Favorito>()
                .HasKey(a => new { a.MangaID, a.UsuarioId });

            modelBuilder.Entity<Manga_Favorito>()
                .HasOne(af => af.Usuario)
                .WithMany(u => u.Mangas_Favoritos)
                .HasForeignKey(af => af.UsuarioId);
            #endregion

            #region Usuarios_Entity
            var passwordHasher = new PasswordHasher<Usuario>();
            Usuario admin = new Usuario { Id = "f5b93248-10dd-40fb-a317-12b24d190a3c", Email = "example@example.net", EmailConfirmed = true, NormalizedEmail = "example@example.net".ToUpper(), UserName = "MAD0", NormalizedUserName = "MAD0".ToUpper(), SecurityStamp = "76d7c417-6c39-45db-8963-304f80f361e0" };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "++++++");
            Usuario upldr = new Usuario { Id = "6d435a04-1bb0-4c7e-874d-edb7d25f41fc", Email = "Kotori@onee.chan", EmailConfirmed = true, NormalizedEmail = "Kotori@onee.chan".ToUpper(), UserName = "Kotori", NormalizedUserName = "Kotori".ToUpper(), SecurityStamp = "59e210b1-d92e-45a9-8cd4-c7837a01e691" };
            upldr.PasswordHash = passwordHasher.HashPassword(upldr, "kotori");
            Usuario user = new Usuario { Id = "0d304ebd-9b85-49bb-83ea-3313f534a865", Email = "Kaoru@onee.sama", EmailConfirmed = true, NormalizedEmail = "Kaoru@onee.sama".ToUpper(), UserName = "Kaoru", NormalizedUserName = "Kaoru".ToUpper(), SecurityStamp = "1e12009b-3b10-4a73-ba28-57ae3323ad5f" };
            user.PasswordHash = passwordHasher.HashPassword(user, "kaoruu");

            modelBuilder.Entity<Usuario>().HasData(
                admin,
                upldr,
                user
            );
            #endregion

            #region Rol_Entity
            IdentityRole Administrador = new IdentityRole { Id = "8e8ddcce-fe93-4563-be09-de9620c7e5e3", Name = "Administrador", NormalizedName = "Administrador".ToUpper() };
            IdentityRole Uploader = new IdentityRole { Id = "0224e393-55a4-4211-97d4-a4b9f5052609", Name = "Uploader", NormalizedName = "Uploader".ToUpper() };
            IdentityRole Usuario = new IdentityRole { Id = "fbe82cec-a56e-40c3-afb1-60b8bd38b611", Name = "Usuario", NormalizedName = "Usuario".ToUpper() };

            modelBuilder.Entity<IdentityRole>().HasData(
                Administrador,
                Uploader,
                Usuario
            );
            #endregion

            #region BaseUserRol
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Administrador.Id,
                    UserId = admin.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = Uploader.Id,
                    UserId = upldr.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = Usuario.Id,
                    UserId = user.Id
                }
            );
            #endregion

            #region BaseUserEmailClaim
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = admin.Id,
                    ClaimType = "Email",
                    ClaimValue = admin.Email
                },
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = user.Id,
                    ClaimType = "Email",
                    ClaimValue = user.Email
                },
                new IdentityUserClaim<string>
                {
                    Id = 3,
                    UserId = upldr.Id,
                    ClaimType = "Email",
                    ClaimValue = upldr.Email
                }
                );
            #endregion

            #region BaseClaimsSeed
            foreach (var item in PermisosBaseRolUsuario.Rol_Claims)
            {
                modelBuilder.Entity<Permiso>().HasData(item);
            }
            foreach (var item in PermisosBaseRolUsuario.User_Claims)
            {
                modelBuilder.Entity<Permiso>().HasData(item);
            }
            #endregion

            foreach (var entidad in modelBuilder.Model.GetEntityTypes())
            {
                string tabla = entidad.GetTableName();

                if (tabla.Contains("Role"))
                {
                    var awa = entidad.GetForeignKeys();
                    foreach (var item in awa)
                    {
                        item.DeleteBehavior = DeleteBehavior.Restrict;
                    }
                }
            }
        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Anime_Episodio> Anime_Episodios { get; set; }
        public DbSet<Anime_Episodio_Servidor> Anime_Episodios_Servidores { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Manga_Capitulo> Manga_Capitulos { get; set; }
        public DbSet<Manga_Capitulo_Pagina> Manga_Capitulo_Paginas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Anime_Genero> Anime_Genero { get; set; }
        public DbSet<Manga_Genero> Manga_Genero { get; set; }
        public DbSet<Anime_Favorito> Anime_Favorito { get; set; }
        public DbSet<Manga_Favorito> Manga_Favorito { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioToken> UsuariosTokens { get; set; }
    }
}