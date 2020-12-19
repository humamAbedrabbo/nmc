using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M_Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "175081c1-075b-456b-8400-d632c1cc2e84", "Admin", "ADMIN" },
                    { 2, "8f440f25-d07a-4095-8d60-e31a199bd833", "Admission", "ADMISSION" },
                    { 3, "300cd0df-ba51-42d1-9e36-8089824ca884", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "d34b1028-bc85-4eab-aad4-61081cac5853", "admin@nmc", false, false, null, "ADMIN@NMC", "ADMIN", "AQAAAAEAACcQAAAAEIBlGUrxoF3hlXElxqi+hey85TF1J7aVmANj7EcwTPeL/O8jFWHJ3DmBSFK+wGnugg==", null, false, "fac395a1-6d4c-47a4-a054-a942bbcb2527", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
