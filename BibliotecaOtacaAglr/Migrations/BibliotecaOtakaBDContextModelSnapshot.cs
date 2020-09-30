﻿// <auto-generated />
using System;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaOtacaAglr.Migrations
{
    [DbContext(typeof(BibliotecaOtakaBDContext))]
    partial class BibliotecaOtakaBDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Anime_Episodios.Entity.Anime_Episodio", b =>
                {
                    b.Property<int>("EpisodioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_subida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_archivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Numero_episodio")
                        .HasColumnType("float");

                    b.Property<string>("Titulo_episodio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodioId");

                    b.HasIndex("AnimeId");

                    b.ToTable("Anime_Episodios");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores.Anime_Episodio_Servidor", b =>
                {
                    b.Property<int>("ServidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Anime_EpisodioEpisodioId")
                        .HasColumnType("int");

                    b.Property<int>("Anime_EpisodioId")
                        .HasColumnType("int");

                    b.Property<string>("Enlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServidorId");

                    b.HasIndex("Anime_EpisodioEpisodioId");

                    b.HasIndex("Anime_EpisodioId");

                    b.ToTable("Anime_Episodios_Servidores");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Animes.Entity.Anime", b =>
                {
                    b.Property<int>("AnimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_publicacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_subida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero_episodios")
                        .HasColumnType("int");

                    b.Property<byte[]>("Portada")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("AnimeId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Animes.Entity.Anime_Genero", b =>
                {
                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("AnimeId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Anime_Genero");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Favorito.Entity.Anime_Favorito", b =>
                {
                    b.Property<int>("AnimeID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Favorito")
                        .HasColumnType("bit");

                    b.HasKey("AnimeID", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Anime_Favorito");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Favorito.Entity.Manga_Favorito", b =>
                {
                    b.Property<int>("MangaID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Favorito")
                        .HasColumnType("bit");

                    b.HasKey("MangaID", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Manga_Favorito");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Generos.Entity.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity.Manga_Capitulo_Pagina", b =>
                {
                    b.Property<int>("PaginaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Manga_CapituloId")
                        .HasColumnType("int");

                    b.Property<double>("Numero_pagina")
                        .HasColumnType("float");

                    b.Property<byte[]>("Pagina")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PaginaId");

                    b.HasIndex("Manga_CapituloId");

                    b.ToTable("Manga_Capitulo_Paginas");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity.Manga_Capitulo", b =>
                {
                    b.Property<int>("CapituloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha_publicacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_subida")
                        .HasColumnType("datetime2");

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_capitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Numero_capitulo")
                        .HasColumnType("float");

                    b.HasKey("CapituloId");

                    b.HasIndex("MangaId");

                    b.ToTable("Manga_Capitulos");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga", b =>
                {
                    b.Property<int>("MangaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_publicacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_subida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Portada")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("MangaId");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga_Genero", b =>
                {
                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("MangaId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Manga_Genero");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Permisos.Entity.Permiso", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermisoId");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            PermisoId = 1,
                            Tipo = "Administrador",
                            Valor = "Permisos de administrador"
                        },
                        new
                        {
                            PermisoId = 2,
                            Tipo = "Crear IUsuario",
                            Valor = "Puede crear usuarios"
                        },
                        new
                        {
                            PermisoId = 3,
                            Tipo = "Borrar IUsuario",
                            Valor = "Puede borrar usuarios"
                        },
                        new
                        {
                            PermisoId = 4,
                            Tipo = "Gestionar Roles",
                            Valor = "Puede gestionar roles"
                        },
                        new
                        {
                            PermisoId = 5,
                            Tipo = "Crear Generos",
                            Valor = "Puede crear generos"
                        },
                        new
                        {
                            PermisoId = 6,
                            Tipo = "Editar Generos",
                            Valor = "Puede editar generos"
                        },
                        new
                        {
                            PermisoId = 7,
                            Tipo = "Borrar Generos",
                            Valor = "Puede borrar generos"
                        },
                        new
                        {
                            PermisoId = 8,
                            Tipo = "Crear Anime",
                            Valor = "Puede crear animes"
                        },
                        new
                        {
                            PermisoId = 9,
                            Tipo = "Editar Anime",
                            Valor = "Puede editar animes"
                        },
                        new
                        {
                            PermisoId = 10,
                            Tipo = "Borrar Anime",
                            Valor = "Puede borrar animes"
                        },
                        new
                        {
                            PermisoId = 11,
                            Tipo = "Crear Anime Capitulo",
                            Valor = "Puede crear capitulos en animes"
                        },
                        new
                        {
                            PermisoId = 12,
                            Tipo = "Editar Anime Capitulo",
                            Valor = "Puede editar capitulos en animes"
                        },
                        new
                        {
                            PermisoId = 13,
                            Tipo = "Borrar Anime Capitulo",
                            Valor = "Puede borrar capitulos en animes"
                        },
                        new
                        {
                            PermisoId = 14,
                            Tipo = "Crear Manga",
                            Valor = "Puede crear mangas"
                        },
                        new
                        {
                            PermisoId = 15,
                            Tipo = "Editar Manga",
                            Valor = "Puede editar mangas"
                        },
                        new
                        {
                            PermisoId = 16,
                            Tipo = "Borrar Manga",
                            Valor = "Puede borrar mangas"
                        },
                        new
                        {
                            PermisoId = 17,
                            Tipo = "Crear Manga Capitulos",
                            Valor = "Puede crear capitulos en mangas"
                        },
                        new
                        {
                            PermisoId = 18,
                            Tipo = "Editar Manga Capitulos",
                            Valor = "Puede editar capitulos en mangas"
                        },
                        new
                        {
                            PermisoId = 19,
                            Tipo = "Borrar Manga Capitulos",
                            Valor = "Puede borrar capitulos en mangas"
                        },
                        new
                        {
                            PermisoId = 20,
                            Tipo = "Crear Manga Capitulos Paginas",
                            Valor = "Puede crear paginas en capitulos en mangas"
                        },
                        new
                        {
                            PermisoId = 21,
                            Tipo = "Editar Manga Capitulos Paginas",
                            Valor = "Puede editar paginas en mangas"
                        },
                        new
                        {
                            PermisoId = 22,
                            Tipo = "Borrar Manga Capitulos Paginas",
                            Valor = "Puede borrar paginas en mangas"
                        });
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.UsuarioTokens.UsuarioToken", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Expiracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Valido")
                        .HasColumnType("bit");

                    b.HasKey("TokenID");

                    b.ToTable("UsuariosTokens");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "f5b93248-10dd-40fb-a317-12b24d190a3c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "665ec925-3f1e-49f6-b9bc-5935a713b0ed",
                            Email = "example@example.net",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE@EXAMPLE.NET",
                            NormalizedUserName = "MAD0",
                            PasswordHash = "AQAAAAEAACcQAAAAEGoC+leP/p+7fO4cf1fBAJmdBE/RVYt1OmwGXym4TiHuGshTc8PazRPdHe/Hl/EWxA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "76d7c417-6c39-45db-8963-304f80f361e0",
                            TwoFactorEnabled = false,
                            UserName = "MAD0"
                        },
                        new
                        {
                            Id = "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ffcefe83-4e53-4a21-9e9f-5bfeb468c2fb",
                            Email = "Kotori@onee.chan",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "KOTORI@ONEE.CHAN",
                            NormalizedUserName = "KOTORI",
                            PasswordHash = "AQAAAAEAACcQAAAAEBKlu3To5WyT4OMla0x0f8VzYDboYaQSOPL2+S6bG9PLZY0ctzl1ib8zYqtzW6rPhQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "59e210b1-d92e-45a9-8cd4-c7837a01e691",
                            TwoFactorEnabled = false,
                            UserName = "Kotori"
                        },
                        new
                        {
                            Id = "0d304ebd-9b85-49bb-83ea-3313f534a865",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "502ccbf1-f7cf-4b9b-bd33-9a52b870c189",
                            Email = "Kaoru@onee.sama",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "KAORU@ONEE.SAMA",
                            NormalizedUserName = "KAORU",
                            PasswordHash = "AQAAAAEAACcQAAAAEJbbOKXQwatNqh81+G7kqyQmnEc+RfI1ZCQacuhBIytrkWVHwuy+oHkDrrkuwVRYqg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1e12009b-3b10-4a73-ba28-57ae3323ad5f",
                            TwoFactorEnabled = false,
                            UserName = "Kaoru"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                            ConcurrencyStamp = "96a8fc35-4074-4ff6-b570-e45d74696718",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "0224e393-55a4-4211-97d4-a4b9f5052609",
                            ConcurrencyStamp = "2efc6c99-4df5-4cb6-bab5-3f9e0ae71fb7",
                            Name = "Uploader",
                            NormalizedName = "UPLOADER"
                        },
                        new
                        {
                            Id = "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                            ConcurrencyStamp = "3075fd4b-624c-45b9-b53b-b8cb3f417281",
                            Name = "Usuario",
                            NormalizedName = "USUARIO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Email",
                            ClaimValue = "example@example.net",
                            UserId = "f5b93248-10dd-40fb-a317-12b24d190a3c"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Email",
                            ClaimValue = "Kaoru@onee.sama",
                            UserId = "0d304ebd-9b85-49bb-83ea-3313f534a865"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Email",
                            ClaimValue = "Kotori@onee.chan",
                            UserId = "6d435a04-1bb0-4c7e-874d-edb7d25f41fc"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "f5b93248-10dd-40fb-a317-12b24d190a3c",
                            RoleId = "8e8ddcce-fe93-4563-be09-de9620c7e5e3"
                        },
                        new
                        {
                            UserId = "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                            RoleId = "0224e393-55a4-4211-97d4-a4b9f5052609"
                        },
                        new
                        {
                            UserId = "0d304ebd-9b85-49bb-83ea-3313f534a865",
                            RoleId = "fbe82cec-a56e-40c3-afb1-60b8bd38b611"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Anime_Episodios.Entity.Anime_Episodio", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Animes.Entity.Anime", "Anime")
                        .WithMany("Episodios")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores.Anime_Episodio_Servidor", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Anime_Episodios.Entity.Anime_Episodio", null)
                        .WithMany("UrlServidores")
                        .HasForeignKey("Anime_EpisodioEpisodioId");

                    b.HasOne("BibliotecaOtacaAglr.Models.Anime_Episodios.Entity.Anime_Episodio", null)
                        .WithMany()
                        .HasForeignKey("Anime_EpisodioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Animes.Entity.Anime_Genero", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Animes.Entity.Anime", "Anime")
                        .WithMany("Generos")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BibliotecaOtacaAglr.Models.Generos.Entity.Genero", "Genero")
                        .WithMany("Animes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Favorito.Entity.Anime_Favorito", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Animes.Entity.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", "Usuario")
                        .WithMany("Animes_Favoritos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Favorito.Entity.Manga_Favorito", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", "Usuario")
                        .WithMany("Mangas_Favoritos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity.Manga_Capitulo_Pagina", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity.Manga_Capitulo", "Capitulo")
                        .WithMany("Paginas")
                        .HasForeignKey("Manga_CapituloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity.Manga_Capitulo", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga", "Manga")
                        .WithMany("Capitulos")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga_Genero", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Generos.Entity.Genero", "Genero")
                        .WithMany("Mangas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BibliotecaOtacaAglr.Models.Mangas.Entity.Manga", "Manga")
                        .WithMany("Generos")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BibliotecaOtacaAglr.Models.Usuarios.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
