using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class usertokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosTokens",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(nullable: true),
                    Valido = table.Column<bool>(nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Fecha_Expiracion = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTokens", x => x.TokenID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0224e393-55a4-4211-97d4-a4b9f5052609",
                column: "ConcurrencyStamp",
                value: "787c2b2f-52c3-40f9-863b-205613599292");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8ddcce-fe93-4563-be09-de9620c7e5e3",
                column: "ConcurrencyStamp",
                value: "deb73764-b9be-40c6-83b8-5ee349de4226");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe82cec-a56e-40c3-afb1-60b8bd38b611",
                column: "ConcurrencyStamp",
                value: "d1db0506-6f8b-4568-967f-a0acdabddd3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d304ebd-9b85-49bb-83ea-3313f534a865",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a1c66eb-8bff-491d-9142-4172a51f0b32", "AQAAAAEAACcQAAAAEPNpvrOPpZkw0uKsR2KjC/qzTGH8sj+RApu1+udJFX8jm8JUv9kUAMtc4EVbHH0rWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d435a04-1bb0-4c7e-874d-edb7d25f41fc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72078cba-9c41-4dcf-87b8-0d57e1c853b4", "AQAAAAEAACcQAAAAEE4Ztk5ovBAJFoy7eZyG9AZP0/mDaTM6Rp7SmInrpI9adXkMdNQ0ikZik8b+EXJmUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5b93248-10dd-40fb-a317-12b24d190a3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d21e53b7-2b63-4b82-a5c1-b8e9e8f69203", "AQAAAAEAACcQAAAAECWKNfEknxc+ozdD6zS+/pGoAFBMWpFHqP/5ZcEPLvkwMlK1i1tWnC4aLtQjzWrS8Q==" });
        }
    }
}
