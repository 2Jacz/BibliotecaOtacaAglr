using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class modelupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Genero_Generos_GeneroId",
                table: "Anime_Genero");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Genero_Generos_GeneroId",
                table: "Manga_Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manga_Capitulos",
                table: "Manga_Capitulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manga_Capitulo_Paginas",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anime_Episodios_Servidores",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anime_Episodios",
                table: "Anime_Episodios");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Num_capitulo",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Anime_Episodios");

            migrationBuilder.DropColumn(
                name: "Numero_capitulo",
                table: "Anime_Episodios");

            migrationBuilder.DropColumn(
                name: "Titulo_capitulo",
                table: "Anime_Episodios");

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "Permisos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CapituloId",
                table: "Manga_Capitulos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Manga_Capitulos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre_capitulo",
                table: "Manga_Capitulos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Numero_capitulo",
                table: "Manga_Capitulos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Pagina",
                table: "Manga_Capitulo_Paginas",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Numero_pagina",
                table: "Manga_Capitulo_Paginas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaginaId",
                table: "Manga_Capitulo_Paginas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Generos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ServidorId",
                table: "Anime_Episodios_Servidores",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EpisodioId",
                table: "Anime_Episodios_Servidores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EpisodioId",
                table: "Anime_Episodios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Numero_episodio",
                table: "Anime_Episodios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Titulo_episodio",
                table: "Anime_Episodios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos",
                column: "PermisoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manga_Capitulos",
                table: "Manga_Capitulos",
                column: "CapituloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manga_Capitulo_Paginas",
                table: "Manga_Capitulo_Paginas",
                column: "PaginaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "GeneroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anime_Episodios_Servidores",
                table: "Anime_Episodios_Servidores",
                column: "ServidorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anime_Episodios",
                table: "Anime_Episodios",
                column: "EpisodioId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "9eb1d600-1679-4766-8938-6dd26239ffed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "8b14b5ab-2900-4b7f-8584-f26bf8484a39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "b14d0f1f-ce1e-4ab5-9cc8-a34386996b4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd668b3b-8376-42ee-91ae-aecb55d82d9f", "AQAAAAEAACcQAAAAECkj4zRCB1g0Mek0pxdw5QWD9VV9JaD9+BSSHuZxu/c/6k/EQH03FmMjuoZhEgQkGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35f479b1-8305-463e-9690-f24608437f4a", "AQAAAAEAACcQAAAAEK+r8JDZEpEoChWY4cHFfh7fcEUacC/WsN/6f/+wASeEfNMo29/ISQbaLzzYoVd/MA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4666ce7-a98e-44b0-831e-88358d18b609", "AQAAAAEAACcQAAAAELvMy1dQGsMmCuFguPTzy+d/4u1iieWm+d+G6HpidEzmpmwei54xpiq91iTeUrdyzQ==" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Tipo", "Valor" },
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

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_Servidores_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "EpisodioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "EpisodioId",
                principalTable: "Anime_Episodios",
                principalColumn: "EpisodioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Genero_Generos_GeneroId",
                table: "Anime_Genero",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "CapituloId",
                principalTable: "Manga_Capitulos",
                principalColumn: "CapituloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Genero_Generos_GeneroId",
                table: "Manga_Genero",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Genero_Generos_GeneroId",
                table: "Anime_Genero");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Genero_Generos_GeneroId",
                table: "Manga_Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manga_Capitulos",
                table: "Manga_Capitulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manga_Capitulo_Paginas",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anime_Episodios_Servidores",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Anime_Episodios_Servidores_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anime_Episodios",
                table: "Anime_Episodios");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 22);

            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "CapituloId",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Fecha_publicacion",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Nombre_capitulo",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Numero_capitulo",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "PaginaId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "ServidorId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "EpisodioId",
                table: "Anime_Episodios");

            migrationBuilder.DropColumn(
                name: "Numero_episodio",
                table: "Anime_Episodios");

            migrationBuilder.DropColumn(
                name: "Titulo_episodio",
                table: "Anime_Episodios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Permisos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Manga_Capitulos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Manga_Capitulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Num_capitulo",
                table: "Manga_Capitulos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Pagina",
                table: "Manga_Capitulo_Paginas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "Numero_pagina",
                table: "Manga_Capitulo_Paginas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Manga_Capitulo_Paginas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Generos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Anime_Episodios_Servidores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Anime_Episodios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Numero_capitulo",
                table: "Anime_Episodios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Titulo_capitulo",
                table: "Anime_Episodios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manga_Capitulos",
                table: "Manga_Capitulos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manga_Capitulo_Paginas",
                table: "Manga_Capitulo_Paginas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anime_Episodios_Servidores",
                table: "Anime_Episodios_Servidores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anime_Episodios",
                table: "Anime_Episodios",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "6c88030a-533e-4c7e-8fb7-f95ca9ec0585");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "462c55a2-3eb2-438c-87d1-a1b208a2fc1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "ef2e1578-ed74-44ff-8d50-b2d3451890d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "403c2939-a7cd-4ab3-9ea9-bd4600350ff4", "AQAAAAEAACcQAAAAEJ8E8C4FWPT27KfnHEtSefmp50DrhPMhZysAh6m4g8wlcG0WGOpyzLtA5vt8i6basQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2eedade6-aecc-451e-bbc6-c6ab3f8c998e", "AQAAAAEAACcQAAAAELtP8HPlK7pce0e78tkbhCvo4xv+0lM6brpAMrHLNqoo4gf1wLNFkVyQldsAq7RxWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bbb2153c-6588-4792-8420-8d6e6b6687bf", "AQAAAAEAACcQAAAAELBMC+CUVKpMZa28Dfo8Dy0FzxG/gALIH+J+3BdBVJkJXCtLHn3cBko1kVclxiQTYg==" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioId",
                principalTable: "Anime_Episodios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Genero_Generos_GeneroId",
                table: "Anime_Genero",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "CapituloId",
                principalTable: "Manga_Capitulos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Genero_Generos_GeneroId",
                table: "Manga_Genero",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "ID");
        }
    }
}
