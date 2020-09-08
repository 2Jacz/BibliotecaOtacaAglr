using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class ActualizacionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre_pagina",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.AddColumn<string>(
                name: "Numero_pagina",
                table: "Manga_Capitulo_Paginas",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero_pagina",
                table: "Manga_Capitulo_Paginas");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_pagina",
                table: "Manga_Capitulo_Paginas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "4b5e24d2-fbba-422b-861c-573f7ea2cda8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "3339f49d-6619-43c1-9f4a-0f027b8873ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "b482d251-54a7-42fd-a746-062d7ec02580");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba969592-659c-49b9-8d08-be013ffe8f7d", "AQAAAAEAACcQAAAAEA3LiPq7yX3P25iQL0zpH8Fswk/lFfNoa9/U1ukJbUAxpkee4RkpEjsw47ZlY9OS+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a735128a-8159-4a90-8f17-453fa324cf99", "AQAAAAEAACcQAAAAENVy3JPvHPNF+CZbsc2+/kCAInP8JZa0h9u3zdAZsEA486bbW8RQAJ+2Qq+d2nhQpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "115ea351-fd88-4340-9d94-0230088a1d46", "AQAAAAEAACcQAAAAEAQj91MimkppQ9f8gne3qzTBYxWvkj5+k5O4cz2dobVtXIFTJZxdZBgzkGPn+XQ0Cg==" });
        }
    }
}
