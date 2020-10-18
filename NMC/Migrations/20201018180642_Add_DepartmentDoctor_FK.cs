using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Add_DepartmentDoctor_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentDoctors_Departments_DoctorId",
                table: "DepartmentDoctors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b5d3c27-a0c7-430d-b606-fe74360d1b6a", "AQAAAAEAACcQAAAAEGkA19tAcxOZ+109y5nT3Spxnm63xY6juAsfP7xfgyHZd9NwmZHrtn0ZanhGC/zrrg==", "90aa7247-e0c0-470e-8311-4b976c2279d0" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDoctors_DepartmentId",
                table: "DepartmentDoctors",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentDoctors_Departments_DepartmentId",
                table: "DepartmentDoctors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentDoctors_Departments_DepartmentId",
                table: "DepartmentDoctors");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentDoctors_DepartmentId",
                table: "DepartmentDoctors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fae3d7b-9e5a-408f-97f9-70d3af85951a", "AQAAAAEAACcQAAAAEDVLqF93NJHOSK1I4fXzj3e1GAmBEqboWJSwWNYU8y77GiqxjxnfPsEcoDT1IXCH3A==", "68e3a189-6b92-40ab-9096-1eb59cae57ab" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentDoctors_Departments_DoctorId",
                table: "DepartmentDoctors",
                column: "DoctorId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
