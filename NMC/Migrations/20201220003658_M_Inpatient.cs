using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class M_Inpatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Patients",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodAllergy",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalAllergy",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inpatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    WardId = table.Column<int>(type: "integer", nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true),
                    RoomGrade = table.Column<int>(type: "integer", nullable: false),
                    ReferrerId = table.Column<int>(type: "integer", nullable: true),
                    ReferrerNotes = table.Column<string>(type: "text", nullable: true),
                    Emergency = table.Column<bool>(type: "boolean", nullable: false),
                    General = table.Column<bool>(type: "boolean", nullable: false),
                    Accident = table.Column<bool>(type: "boolean", nullable: false),
                    PoliceRef = table.Column<bool>(type: "boolean", nullable: false),
                    Healing = table.Column<bool>(type: "boolean", nullable: false),
                    Improvement = table.Column<bool>(type: "boolean", nullable: false),
                    Ill = table.Column<bool>(type: "boolean", nullable: false),
                    Death = table.Column<bool>(type: "boolean", nullable: false),
                    Other = table.Column<bool>(type: "boolean", nullable: false),
                    Companion = table.Column<bool>(type: "boolean", nullable: false),
                    Meals = table.Column<string>(type: "text", nullable: true),
                    GLACC = table.Column<string>(type: "text", nullable: true),
                    EstDays = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdmetOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DischargedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Diseases = table.Column<string>(type: "text", nullable: true),
                    Medicines = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inpatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inpatients_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Doctors_ReferrerId",
                        column: x => x.ReferrerId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inpatients_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_InpatientId",
                table: "RoomAllocations",
                column: "InpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_BookingId",
                table: "Inpatients",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_PatientId",
                table: "Inpatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_ReferrerId",
                table: "Inpatients",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_RoomId",
                table: "Inpatients",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_WardId",
                table: "Inpatients",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Inpatients_InpatientId",
                table: "RoomAllocations",
                column: "InpatientId",
                principalTable: "Inpatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Inpatients_InpatientId",
                table: "RoomAllocations");

            migrationBuilder.DropTable(
                name: "Inpatients");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_InpatientId",
                table: "RoomAllocations");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FoodAllergy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalAllergy",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e8c68cc4-228d-4e8b-8f7d-9a5a72cd670c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9d88cdc0-6f0a-4f89-b0d9-2e419c588224");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e8ab3e32-38df-4521-939c-72010052f7a8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b2a05dc-46fa-4f8a-bf54-835fde6c84f8", "AQAAAAEAACcQAAAAEGiOoAkUmccSNvNOc8EI/vDlpXfaKdB6yVO0wqO2pf5uhQDAxR6oS3wmv/x9phz3FQ==", "69db3fd9-708c-4efc-86cb-db71316b9cdc" });
        }
    }
}
