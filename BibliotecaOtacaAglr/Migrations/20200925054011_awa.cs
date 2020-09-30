using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class awa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropIndex(
                name: "IX_Manga_Capitulo_Paginas_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropIndex(
                name: "IX_Anime_Episodios_Servidores_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropColumn(
                name: "EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.AddColumn<int>(
                name: "Manga_CapituloId",
                table: "Manga_Capitulo_Paginas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "2efc6c99-4df5-4cb6-bab5-3f9e0ae71fb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "96a8fc35-4074-4ff6-b570-e45d74696718");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "3075fd4b-624c-45b9-b53b-b8cb3f417281");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "502ccbf1-f7cf-4b9b-bd33-9a52b870c189", "AQAAAAEAACcQAAAAEJbbOKXQwatNqh81+G7kqyQmnEc+RfI1ZCQacuhBIytrkWVHwuy+oHkDrrkuwVRYqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffcefe83-4e53-4a21-9e9f-5bfeb468c2fb", "AQAAAAEAACcQAAAAEBKlu3To5WyT4OMla0x0f8VzYDboYaQSOPL2+S6bG9PLZY0ctzl1ib8zYqtzW6rPhQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "665ec925-3f1e-49f6-b9bc-5935a713b0ed", "AQAAAAEAACcQAAAAEGoC+leP/p+7fO4cf1fBAJmdBE/RVYt1OmwGXym4TiHuGshTc8PazRPdHe/Hl/EWxA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Capitulo_Paginas_Manga_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "Manga_CapituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioEpisodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioEpisodioId",
                principalTable: "Anime_Episodios",
                principalColumn: "EpisodioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores",
                column: "Anime_EpisodioId",
                principalTable: "Anime_Episodios",
                principalColumn: "EpisodioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_Manga_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "Manga_CapituloId",
                principalTable: "Manga_Capitulos",
                principalColumn: "CapituloId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Episodios_Servidores_Anime_Episodios_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_Manga_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropIndex(
                name: "IX_Manga_Capitulo_Paginas_Manga_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Anime_Episodios_Servidores_Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "Manga_CapituloId",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.DropColumn(
                name: "Anime_EpisodioEpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.DropColumn(
                name: "Anime_EpisodioId",
                table: "Anime_Episodios_Servidores");

            migrationBuilder.AddColumn<int>(
                name: "CapituloId",
                table: "Manga_Capitulo_Paginas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EpisodioId",
                table: "Anime_Episodios_Servidores",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Capitulo_Paginas_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "CapituloId");

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
                name: "FK_Manga_Capitulo_Paginas_Manga_Capitulos_CapituloId",
                table: "Manga_Capitulo_Paginas",
                column: "CapituloId",
                principalTable: "Manga_Capitulos",
                principalColumn: "CapituloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
