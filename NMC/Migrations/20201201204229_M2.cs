using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ADMIN", "c3fdc4e4-0768-4632-af27-54a3cbb14350", "Admin", "ADMIN" },
                    { "DOCTOR", "d290a24d-1287-400c-9b3d-86c4bc48baf4", "Doctor", "DOCTOR" },
                    { "FD", "7d2097cd-deca-4ea0-9603-aad327287d24", "Front Desk", "FRONT DESK" },
                    { "LABD", "766d76cf-36d3-4eb6-83b6-fbdfdbc3496e", "Laboratory Doctor", "LABORATORY DOCTOR" },
                    { "LABT", "ea0550b5-0fec-4c41-8221-f860c95d7ea4", "Laboratory Technician", "LABORATORY TECHNICIAN" },
                    { "ACT", "a2a5bbe2-00b1-4326-8263-debb55f8d115", "Accountant", "ACCOUNTANT" },
                    { "MGT", "74883392-4c48-4f7d-bffb-33524daa85d0", "Management", "MANAGEMENT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78acee41-7604-4f70-97cc-6792d2815d05", 0, "8ab957b0-422a-454f-8c04-3e02de9637ef", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAEGPob204e/c36wd6kCYooqJWp4VDLsQYwgld9gqS5eiuxDbeFLde3kkgQ/qUWSSm3g==", null, false, "99779c11-b2bf-4469-9645-01e06b9a0213", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Language", "en", "78acee41-7604-4f70-97cc-6792d2815d05" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN", "78acee41-7604-4f70-97cc-6792d2815d05" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ACT");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "DOCTOR");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "FD");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABD");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABT");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "MGT");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN", "78acee41-7604-4f70-97cc-6792d2815d05" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ADMIN");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "78acee41-7604-4f70-97cc-6792d2815d05");
        }
    }
}
