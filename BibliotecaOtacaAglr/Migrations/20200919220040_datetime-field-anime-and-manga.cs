using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class datetimefieldanimeandmanga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Mangas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_subida",
                table: "Mangas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_publicacion",
                table: "Animes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_subida",
                table: "Animes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_publicacion",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Fecha_subida",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Fecha_publicacion",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Fecha_subida",
                table: "Animes");

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
    }
}
