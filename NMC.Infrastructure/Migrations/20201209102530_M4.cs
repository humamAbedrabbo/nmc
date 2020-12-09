using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "Rooms",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "137c04c3-2165-4a56-8d9c-5cfa8a9a061c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "884aeaab-4aa2-47cc-8470-f08cedfd96a6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0937c811-2f5a-4ed3-b458-3a63ca9ec7ce");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8dfabed-df86-43c1-9618-3453211c0a46", "AQAAAAEAACcQAAAAEBZqqw0Re6pSrnWup78z1K+8qkC173obV/V5YBbmBQH0v6Kn+bDe3yUaV8a1Yh2/eA==", "676ce984-56f3-4b7c-ae74-da75dc09a234" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd0291ff-3e75-422c-be3a-ddc7d6b8ea47", "AQAAAAEAACcQAAAAEI4y/PqCASdzLJxGyE6kabqLWYh9X3LKNBXhU/CVP/9aK9tOAg6YLNNVcvdbKd4cVg==", "9791ce9c-e167-4d78-80a1-530d9c548aa1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfc557c-0f51-408f-a712-6e096e53a2ce", "AQAAAAEAACcQAAAAEHJ3DWScSmHDkZvTLNRcMONFSLkUqbGues/0M0cMVQaHNorwM8m1Q1uDYP+IkH41LQ==", "2b794156-b4be-4ad2-8545-e7d7735880be" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardId",
                table: "Rooms",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Departments_WardId",
                table: "Rooms",
                column: "WardId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Departments_WardId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_WardId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Rooms");

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
    }
}
