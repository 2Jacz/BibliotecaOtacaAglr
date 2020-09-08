using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Portada = table.Column<byte[]>(nullable: true),
                    Numero_episodios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    MangaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Portada = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.MangaId);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false),
                    Valor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime_Episodios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo_capitulo = table.Column<string>(nullable: false),
                    Numero_capitulo = table.Column<double>(nullable: false),
                    Nombre_archivo = table.Column<string>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Episodios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Anime_Episodios_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anime_FavoritoController",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    AnimeID = table.Column<int>(nullable: false),
                    Favorito = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Favorito", x => new { x.AnimeID, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_Anime_Favorito_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anime_Favorito_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anime_Genero",
                columns: table => new
                {
                    AnimeId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Genero", x => new { x.AnimeId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_Anime_Genero_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId");
                    table.ForeignKey(
                        name: "FK_Anime_Genero_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Manga_Capitulos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Num_capitulo = table.Column<double>(nullable: false),
                    MangaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga_Capitulos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Manga_Capitulos_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga_Favorito",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    MangaID = table.Column<int>(nullable: false),
                    Favorito = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga_Favorito", x => new { x.MangaID, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_Manga_Favorito_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manga_Favorito_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga_Genero",
                columns: table => new
                {
                    MangaId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga_Genero", x => new { x.MangaId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_Manga_Genero_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Manga_Genero_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId");
                });

            migrationBuilder.CreateTable(
                name: "Anime_Episodios_Servidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enlace = table.Column<string>(nullable: false),
                    Anime_EpisodioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Episodios_Servidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioId",
                        column: x => x.Anime_EpisodioId,
                        principalTable: "Anime_Episodios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga_Capitulo_Paginas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_pagina = table.Column<string>(nullable: true),
                    Pagina = table.Column<byte[]>(nullable: true),
                    CapituloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga_Capitulo_Paginas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                        column: x => x.CapituloId,
                        principalTable: "Manga_Capitulos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fbe82cec-a56e-40c3-afb1-60b8bd38b611", "b482d251-54a7-42fd-a746-062d7ec02580", "IUsuario", "USUARIO" },
                    { "8e8ddcce-fe93-4563-be09-de9620c7e5e3", "3339f49d-6619-43c1-9f4a-0f027b8873ac", "Administrador", "ADMINISTRADOR" },
                    { "0224e393-55a4-4211-97d4-a4b9f5052609", "4b5e24d2-fbba-422b-861c-573f7ea2cda8", "Uploader", "UPLOADER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d304ebd-9b85-49bb-83ea-3313f534a865", 0, "ba969592-659c-49b9-8d08-be013ffe8f7d", "Kaoru@onee.sama", true, false, null, "KAORU@ONEE.SAMA", "KAORU", "AQAAAAEAACcQAAAAEA3LiPq7yX3P25iQL0zpH8Fswk/lFfNoa9/U1ukJbUAxpkee4RkpEjsw47ZlY9OS+Q==", null, false, "1e12009b-3b10-4a73-ba28-57ae3323ad5f", false, "Kaoru" },
                    { "6d435a04-1bb0-4c7e-874d-edb7d25f41fc", 0, "a735128a-8159-4a90-8f17-453fa324cf99", "Kotori@onee.chan", true, false, null, "KOTORI@ONEE.CHAN", "KOTORI", "AQAAAAEAACcQAAAAENVy3JPvHPNF+CZbsc2+/kCAInP8JZa0h9u3zdAZsEA486bbW8RQAJ+2Qq+d2nhQpA==", null, false, "59e210b1-d92e-45a9-8cd4-c7837a01e691", false, "Kotori" },
                    { "f5b93248-10dd-40fb-a317-12b24d190a3c", 0, "115ea351-fd88-4340-9d94-0230088a1d46", "example@example.net", true, false, null, "EXAMPLE@EXAMPLE.NET", "MAD0", "AQAAAAEAACcQAAAAEAQj91MimkppQ9f8gne3qzTBYxWvkj5+k5O4cz2dobVtXIFTJZxdZBgzkGPn+XQ0Cg==", null, false, "76d7c417-6c39-45db-8963-304f80f361e0", false, "MAD0" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Tipo", "Valor" },
                values: new object[,]
                {
                    { 22, "Borrar Manga Capitulos Paginas", "Puede borrar paginas en mangas" },
                    { 21, "Editar Manga Capitulos Paginas", "Puede editar paginas en mangas" },
                    { 20, "Crear Manga Capitulos Paginas", "Puede crear paginas en capitulos en mangas" },
                    { 19, "Borrar Manga Capitulos", "Puede borrar capitulos en mangas" },
                    { 18, "Editar Manga Capitulos", "Puede editar capitulos en mangas" },
                    { 17, "Crear Manga Capitulos", "Puede crear capitulos en mangas" },
                    { 16, "Borrar Manga", "Puede borrar mangas" },
                    { 15, "Editar Manga", "Puede editar mangas" },
                    { 14, "Crear Manga", "Puede crear mangas" },
                    { 12, "Editar Anime Capitulo", "Puede editar capitulos en animes" },
                    { 11, "Crear Anime Capitulo", "Puede crear capitulos en animes" },
                    { 10, "Borrar Anime", "Puede borrar animes" },
                    { 9, "Editar Anime", "Puede editar animes" },
                    { 8, "Crear Anime", "Puede crear animes" },
                    { 7, "Borrar Generos", "Puede borrar generos" },
                    { 6, "Editar Generos", "Puede editar generos" },
                    { 5, "Crear Generos", "Puede crear generos" },
                    { 4, "Gestionar Roles", "Puede gestionar roles" },
                    { 3, "Borrar IUsuario", "Puede borrar usuarios" },
                    { 2, "Crear IUsuario", "Puede crear usuarios" },
                    { 13, "Borrar Anime Capitulo", "Puede borrar capitulos en animes" },
                    { 1, "Administrador", "Permisos de administrador" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Email", "example@example.net", "f5b93248-10dd-40fb-a317-12b24d190a3c" },
                    { 3, "Email", "Kotori@onee.chan", "6d435a04-1bb0-4c7e-874d-edb7d25f41fc" },
                    { 2, "Email", "Kaoru@onee.sama", "0d304ebd-9b85-49bb-83ea-3313f534a865" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "f5b93248-10dd-40fb-a317-12b24d190a3c", "8e8ddcce-fe93-4563-be09-de9620c7e5e3" },
                    { "6d435a04-1bb0-4c7e-874d-edb7d25f41fc", "0224e393-55a4-4211-97d4-a4b9f5052609" },
                    { "0d304ebd-9b85-49bb-83ea-3313f534a865", "fbe82cec-a56e-40c3-afb1-60b8bd38b611" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_AnimeId",
                table: "Anime_Episodios",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Favorito_UsuarioId",
                table: "Anime_FavoritoController",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Genero_GeneroId",
                table: "Anime_Genero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Capitulo_Paginas_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "CapituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Capitulos_MangaId",
                table: "Manga_Capitulos",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Favorito_UsuarioId",
                table: "Manga_Favorito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Genero_GeneroId",
                table: "Manga_Genero",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime_Episodios_Servidores");

            migrationBuilder.DropTable(
                name: "Anime_FavoritoController");

            migrationBuilder.DropTable(
                name: "Anime_Genero");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Manga_Capitulo_Paginas");

            migrationBuilder.DropTable(
                name: "Manga_Favorito");

            migrationBuilder.DropTable(
                name: "Manga_Genero");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Anime_Episodios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Manga_Capitulos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Mangas");
        }
    }
}
