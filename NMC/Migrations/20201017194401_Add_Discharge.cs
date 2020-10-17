using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Add_Discharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DischargeTypeId",
                table: "Admissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DischargeTypeId",
                table: "Admissions",
                column: "DischargeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_DischargeTypes_DischargeTypeId",
                table: "Admissions",
                column: "DischargeTypeId",
                principalTable: "DischargeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_DischargeTypes_DischargeTypeId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_DischargeTypeId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "DischargeTypeId",
                table: "Admissions");
        }
    }
}
