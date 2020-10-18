using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Add_Admin_Lang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Language", "en", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fae3d7b-9e5a-408f-97f9-70d3af85951a", "AQAAAAEAACcQAAAAEDVLqF93NJHOSK1I4fXzj3e1GAmBEqboWJSwWNYU8y77GiqxjxnfPsEcoDT1IXCH3A==", "68e3a189-6b92-40ab-9096-1eb59cae57ab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc94c58a-7f3b-46f3-9a3a-3872a38e3241", "AQAAAAEAACcQAAAAEOR3R1K9kcFFyzs3YSZhhrBB1A/WIUEPxrhVNyCa3OaJEVcO4ogZeORa8KGjYOnmoQ==", "960384c9-25a2-4dc1-b0b7-90c92db4aa73" });
        }
    }
}
