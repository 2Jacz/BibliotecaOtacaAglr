using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class models_update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Portada",
                table: "Mangas",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Mangas",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Mangas",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Manga_Capitulos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Portada",
                table: "Animes",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Animes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Animes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Animes",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "c368e164-4596-4db1-ab6d-8d5c9e5c9385");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "bf74a205-16e2-4bc7-b937-1e2758dce4bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "1212a48e-7323-4710-ae19-73ffea59397e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9694fd1d-5ef9-428a-90b9-6f45925f1d27", "AQAAAAEAACcQAAAAEAY0AAbrQG1XymRXzzJMFmwjnFj5ta3jb5WSa1oVrbxo4UQFs2h7sqKVMdEBRTCg8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e65f8b6-cdd6-4567-a799-1c8cc5efcbec", "AQAAAAEAACcQAAAAEHs53jfL+otf5Z9qEHIcD51u+lAvrPgniZE0ViNt24WX0cwFAmMwClWU6mumgZi+Ag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "948a5d61-df50-4c50-81c7-cc2e5882cb84", "AQAAAAEAACcQAAAAEK2Nxithy67JG0q+GNTjkLjKX8oURp8Tjgsy/OGxXXTZQwP7R1UhbttqnnbunjbpUQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Portada",
                table: "Mangas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Mangas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Manga_Capitulos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Portada",
                table: "Animes",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Animes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);

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
        }
    }
}
