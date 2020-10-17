using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Add_Reservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Reservation_ReservationId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Reservation_ReservationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RoomGrades_GradeId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Patients_PatientId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_RoomNo",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_RoomNo",
                table: "Reservations",
                newName: "IX_Reservations_RoomNo");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PatientId",
                table: "Reservations",
                newName: "IX_Reservations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_GradeId",
                table: "Reservations",
                newName: "IX_Reservations_GradeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusTime",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusType",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Reservations_ReservationId",
                table: "Admissions",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RoomGrades_GradeId",
                table: "Reservations",
                column: "GradeId",
                principalTable: "RoomGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Patients_PatientId",
                table: "Reservations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomNo",
                table: "Reservations",
                column: "RoomNo",
                principalTable: "Rooms",
                principalColumn: "RoomNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Reservations_ReservationId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RoomGrades_GradeId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Patients_PatientId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomNo",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StatusTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StatusType",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomNo",
                table: "Reservation",
                newName: "IX_Reservation_RoomNo");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservation",
                newName: "IX_Reservation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_GradeId",
                table: "Reservation",
                newName: "IX_Reservation_GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStatus_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatus_ReservationId",
                table: "ReservationStatus",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Reservation_ReservationId",
                table: "Admissions",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Reservation_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RoomGrades_GradeId",
                table: "Reservation",
                column: "GradeId",
                principalTable: "RoomGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Patients_PatientId",
                table: "Reservation",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_RoomNo",
                table: "Reservation",
                column: "RoomNo",
                principalTable: "Rooms",
                principalColumn: "RoomNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
