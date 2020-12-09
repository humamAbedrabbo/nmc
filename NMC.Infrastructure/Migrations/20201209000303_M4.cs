using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBMenuItems_SBMenuItems_ParentId",
                table: "SBMenuItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afd97c3c-fd3c-4c8d-8778-f463a109b397", "AQAAAAEAACcQAAAAED0bJ4/XbBaEs31cLxrkFwZ9DrIoSKpMq2sUu6F2DOq15EswIP76UwtifK5xoWTwlw==", "81059ebf-a3e0-48a3-8a4a-0f967e4a1424" });

            migrationBuilder.AddForeignKey(
                name: "FK_SBMenuItems_SBMenuItems_ParentId",
                table: "SBMenuItems",
                column: "ParentId",
                principalTable: "SBMenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBMenuItems_SBMenuItems_ParentId",
                table: "SBMenuItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddff63de-15c3-478b-87cb-0cbb39c9a6fc", "AQAAAAEAACcQAAAAELAB+T46yPqsflpdfdiInj6yTdMvwB3SDEV6B3uN5aMBTVw5YvjIx6m6cg7l3sgc2Q==", "f9bac2d4-b9f0-479b-8b53-3675eb5ff40b" });

            migrationBuilder.AddForeignKey(
                name: "FK_SBMenuItems_SBMenuItems_ParentId",
                table: "SBMenuItems",
                column: "ParentId",
                principalTable: "SBMenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
