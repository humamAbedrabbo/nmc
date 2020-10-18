using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Add_DepartmentDoctor_FK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentRooms_Departments_RoomId",
                table: "DepartmentRooms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308a5163-8268-421a-bc31-ef9992cbfd07", "AQAAAAEAACcQAAAAEJcT9ZvCfe36h4XuR0W92OFf5L8FFT0kP2LW97GSqQNRR7ecZXBjw6IKH64fiODYyA==", "e87e5ab1-d436-489a-a70a-8aa9fb9596f3" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRooms_DepartmentId",
                table: "DepartmentRooms",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentRooms_Departments_DepartmentId",
                table: "DepartmentRooms",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentRooms_Departments_DepartmentId",
                table: "DepartmentRooms");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentRooms_DepartmentId",
                table: "DepartmentRooms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b5d3c27-a0c7-430d-b606-fe74360d1b6a", "AQAAAAEAACcQAAAAEGkA19tAcxOZ+109y5nT3Spxnm63xY6juAsfP7xfgyHZd9NwmZHrtn0ZanhGC/zrrg==", "90aa7247-e0c0-470e-8311-4b976c2279d0" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentRooms_Departments_RoomId",
                table: "DepartmentRooms",
                column: "RoomId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
