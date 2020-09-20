using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class datetimefieldanimeandmangacaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_subida",
                table: "Manga_Capitulos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_subida",
                table: "Anime_Episodios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "c351e0e0-1fe5-40e4-8af2-88c7d415915f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "49e8b6ad-270d-4222-acae-cb28b0f323a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "0b445eba-ea7f-4731-b03b-509fba172d0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c12e979c-5fc2-40d3-89aa-bb62d5304b7d", "AQAAAAEAACcQAAAAEB6kEg+NUFSi/FJnE9BUNGFpbLA+D+CTRu6YQy+ejJlyO6Vdhvo7yC3d+XufJ90p1w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96a1d3ca-4467-472c-a90e-4928ea950538", "AQAAAAEAACcQAAAAEL5nTfu3SstPSz5wCDjModvJ7wOyn8wKUPfgDn7dXHtw/wq7ewigzGITRI1jN92z+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9df4a859-6119-4bea-93a3-8167b928b543", "AQAAAAEAACcQAAAAEKT/2QKW1VqAAnr0Rq9eKJpmGpuAGxR6cFXvFx2AlnO2f3kIuBxsoScSOR1kIKZt+Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_subida",
                table: "Manga_Capitulos");

            migrationBuilder.DropColumn(
                name: "Fecha_subida",
                table: "Anime_Episodios");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "ebe41fd7-0f48-4838-9b89-cc530c679193");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "532ed60c-aaf4-43e3-b3e5-dfbe439e7742");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "1552672b-1ba3-4122-8eb4-b4a0ad09689a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a6614b1-a9f3-434d-80cf-f3f616b5893e", "AQAAAAEAACcQAAAAECm4SAMFVpcEkBM2uJc/jJfzqR07XumO38K49n2HYMLUbV0ISo4sHn0uwvdZIJ5eqA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8afaac8-3367-4ee9-97da-3166ee989d53", "AQAAAAEAACcQAAAAEKe5/X/CJ6VndpKHpX+9wI/7WL0irVnPUXLuKoXtYwP4v5QAElAYHyJmGak1JIHuZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b47a7e17-149f-4b1e-b960-3190e6e2da08", "AQAAAAEAACcQAAAAELGRyCmF14Zt1EkGIv0aWcTuxHmXWBDmBX/nNJLUuT6GW+2UH/yJy1+irCLtjzD9qw==" });
        }
    }
}
