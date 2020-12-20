using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class M_Allocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    InpatientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7bc7f34a-76bb-445e-ac43-d511542dd396");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "66d87b64-0dac-4e30-889a-d32096176836");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "367a9b5a-1d13-41b8-b7ce-4cd1ec14540f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bbe4137-383c-4a4c-b933-9bccaf2f42dd", "AQAAAAEAACcQAAAAENeHlypyO4jBNFoDK08Y8UhYO+qV5cnFAWZEXJg1LpVxfE4wR+66e7wFj2t0VZZAvg==", "6b55504e-ec49-4553-a731-b11636a09560" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_BookingId",
                table: "RoomAllocations",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_Date",
                table: "RoomAllocations",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_RoomId",
                table: "RoomAllocations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_Status",
                table: "RoomAllocations",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAllocations");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d8676783-5d17-40ba-8ac2-2a0e977118e9");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "02ea3958-b690-429e-8600-b644c2147aeb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "cc24a4ab-fdc8-41d5-bce0-12b12f29c330");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de0c4fcf-63e6-40ed-af49-a9698ed285b7", "AQAAAAEAACcQAAAAEGSwDFEy6Dmu86H5opdGtF9VxiUi+h2+WRUlXkzJF5oBh0EdOf/l4SuUwOM0rYdUWw==", "cc12223b-29a3-4d72-88c9-c5d021b3a3ac" });
        }
    }
}
