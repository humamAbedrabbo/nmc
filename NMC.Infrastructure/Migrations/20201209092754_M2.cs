using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentType",
                table: "Departments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e636e3eb-7508-42de-a50a-c05ef03db905");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a5638254-8c86-436b-8a00-2433a0afb4ad");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "11cf130a-0089-460b-9719-274e2a8e6d38");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71119df7-8de4-4699-820c-6deb5efe77bf", "AQAAAAEAACcQAAAAEMhEXaT1uYRvBS6pY6XpudW7jS2B42Wp4/PBnodFXfAWtG9imw1v0YC8kMK17h/HJg==", "75833f1e-0f54-4f8d-971d-133e4ff5c5ff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a01c232-db70-4f48-9130-1df15f1bddbd", "AQAAAAEAACcQAAAAEGCJlO9R3SkXOHuZPiarzpx/S9zDzZijRGfJVfgRcrAJpbTdAbLZY6TfGqm8BKs3eg==", "59aea061-d596-4e0a-8993-347cc7a83104" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d581b5a8-5035-49e7-81e1-5c80ad64ee8e", "AQAAAAEAACcQAAAAEOLSjS8fWx+tG9B9z45PM5Vqh4OCm8aMpFwialgjNMayLhLptSADizTK8GlbWvTiTg==", "74f5fa2a-12c0-455e-a6fe-4ca42e70a50f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentType",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e99e4489-4025-4ee8-a059-7360430fc6a0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b3c92566-94b9-434a-bbb9-c5176fe9c5e1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4b570f0e-8979-4616-9ea1-7b8ead5af33b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "999454fa-adaf-4edf-adba-ddc7c9361646", "AQAAAAEAACcQAAAAEE2gExCou8VHM4soIywqAry5kDaLxVKTPp1anbNvRt36gVHe/lTPc2PYhwf/DBwlmw==", "355d6f63-ca58-455c-a00c-c18240c1bfee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c42d5cea-db2d-4f82-82f4-d1fc7fab7c85", "AQAAAAEAACcQAAAAEOjCu3SfhTHwJ1oPmJQhXsgaldjphpYUqefiJim3cDMpGgpfBWhNUG9y0qEkAsHjVQ==", "1e25833c-eaed-4dd0-b0ec-3382accfd1f1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b89ae2b-d9fb-4c38-a38b-fcf3a5e45e83", "AQAAAAEAACcQAAAAEFZ+GwyU9gfdW2tuIZF+4jGhh/OEQxE78FZEujApMVWuownnMSKesqvFlu1aZEnpvQ==", "d5b417bf-8607-44b8-9e0a-db06eec2b26b" });
        }
    }
}
