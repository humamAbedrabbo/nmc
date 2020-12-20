using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M_ADM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e3570fc2-1711-4046-aedd-c300efeda4c8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "59bbd2b8-f8f2-47af-851f-52e5f9420be5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "40129c19-f747-460c-a87b-7bbc02fe6749");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0908fd1-ae2d-4823-9725-2afb018bbda5", "AQAAAAEAACcQAAAAEBeeUgu+crHFPoeLH660PQRedQB28Ro+wmeWI9SOq3uQh9VPcjXwluyyozyZY1M4xA==", "df9db5ba-63cf-4915-a770-8b89b4fbec60" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "56b33b24-148e-4090-b670-fe6e4cf03588", "adm@nmc", false, false, null, "ADM@NMC", "ADM", "AQAAAAEAACcQAAAAEKy0qD4QT+tghA24/CgbkdBGsNvTnRssxiPQ/Ay4Yg5l7wQh7C7+YATJuzaf3JXF9Q==", null, false, "f472b4d6-756d-4710-987b-d1f65b8c517c", false, "adm" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c402fe0f-dbbf-4d6a-950c-61f9e10d84f7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "266813d6-8c5a-4da9-b5e4-44e8c6830a0a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c8767879-7254-473a-95cb-47bcc067e11a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9e02e20-ef00-4a05-95bc-c79cc5df4e03", "AQAAAAEAACcQAAAAEGGr3yopSqYLp62MiMBoWH3dk45UVX6tM1DXLMfDp4UE12jO1saUJVr7xathTbnPFQ==", "d8441105-d539-4611-849d-163ce0ed4683" });
        }
    }
}
