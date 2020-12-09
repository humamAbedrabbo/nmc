using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "DepartmentType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "DepartmentType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "DepartmentType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "DepartmentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7926d914-0b2b-4ed0-9afa-e786cf54f45c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d6bd308-6022-49d4-bbf3-5577040ed202");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "9bdc335c-e7f9-4ba1-ad55-9619d2fb87a7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b3c1792-47f1-4c93-b766-de98771a0cf5", "AQAAAAEAACcQAAAAEGfgTCbkABB+5RhX62bkbiQNVfnWJkyDxkJ7RkX6yODsHaOiU8ijDOjedXs3bbPPxw==", "1935cc40-d68a-46ef-9a21-832cb64dad82" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78476206-614c-4625-adbe-4b352073f816", "AQAAAAEAACcQAAAAEJbpXHPglWT4rWUFe+44naHRVfSt4FWG/mb4zenqzRoVwaqL4qWRWRzFUXKliCtMjQ==", "9f98fc6b-80b5-4b73-9a2e-6329495e118f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "778367ff-3e08-4dc1-9a49-14cfaa655b6e", "AQAAAAEAACcQAAAAEEDDye3GMSG16+y8cX6eTOpDifuSPAO8P8XOry5P59w/mHqbKrSP3s/OyWUBwDPtLQ==", "17950607-5547-4027-bc43-f1036029a7ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "DepartmentType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "DepartmentType",
                value: 0);

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
    }
}
