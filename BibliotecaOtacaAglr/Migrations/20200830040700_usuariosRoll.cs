using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaOtacaAglr.Migrations
{
    public partial class usuariosRoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "d1db0506-6f8b-4568-967f-a0acdabddd3b", "Usuario" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "ad50bcd4-d971-46eb-abb0-2dcd2773e7f0", "IUsuario" });

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
        }
    }
}
