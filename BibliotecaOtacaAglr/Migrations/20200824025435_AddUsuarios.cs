using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class AddUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime_Favorito");

            migrationBuilder.CreateTable(
                name: "Anime_Favorito",
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "b1215796-7b0c-4053-90ab-019be32a0933");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "aa53b353-184c-490e-81cc-3b51d085637b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "ad50bcd4-d971-46eb-abb0-2dcd2773e7f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac279c60-8ceb-41c6-aad7-9446d481b42d", "AQAAAAEAACcQAAAAEN+sWNdY5GdDdHPkacljHHLUqM2UcikOigECZsuP0cqHZ/7ni8q2o36oDqcwNn2OAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c84a43f-0e73-473b-9399-3dcf1caac449", "AQAAAAEAACcQAAAAELqxPMKzHL7RuFDpAZGSwquO6yMYwcpPmPzWDS/d6qWGDQDqQam+GVgeT/XNqFvDCg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90731a93-6585-4568-8617-16cef123d98f", "AQAAAAEAACcQAAAAEPG1UV8hVntj6DDVGb5gcudIOKoshIL6ntEZQ0JtVaecwyAVchfIxjuoO139Oos1eQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_Favorito_UsuarioId",
                table: "Anime_Favorito",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime_Favorito");

            migrationBuilder.CreateTable(
                name: "Anime_FavoritoController",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Favorito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_FavoritoController", x => new { x.AnimeID, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_Anime_FavoritoController_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anime_FavoritoController_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "3744589a-4259-458f-acd0-b82933ce9309");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "f245e69b-f14e-4824-98e8-14caf08a5892");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "0bb8deba-225a-4a4e-9e2b-027ecc1a8287");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff8ca4b9-f128-4b48-8197-f74bdc83d717", "AQAAAAEAACcQAAAAEJz3pEpP6Ebi0+SztghBCFWbZIc1Xd3S6r+tYc3fl0f+IR2/0+9Xc5oYG+Xa3hFW2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20781658-f5a7-474f-a8df-7ebae8dcb009", "AQAAAAEAACcQAAAAEPax3f2M2NtnDAZVocyeKpuOH7TviR/NtHt7wkVqegoE9of0xPlS+O4nQNihWLo3LQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c007f1c0-d723-4f1a-a72a-e68d7332e633", "AQAAAAEAACcQAAAAEOCkL/nMhr+/Rbsmkv9DjzBMFc0rCUQv94AT30ji73DCc4Vx8m0Yh3KkFZc66eEuww==" });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_FavoritoController_UsuarioId",
                table: "Anime_FavoritoController",
                column: "UsuarioId");
        }
    }
}
