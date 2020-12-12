using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Create_Room_ALTKEY_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_RoomNo",
                table: "Rooms",
                column: "RoomNo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5562ad1-4882-418d-b8d3-e32fee7d3af2", "AQAAAAEAACcQAAAAEPT/5bV/BuDXWVSre+B5Ai31oZisd9KRIouZfkcQ3Eqyvb3blB/tuNZV5A7jX3eJYQ==", "d76458e7-43be-494a-afe4-80f26877dcf2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_RoomNo",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921e493b-d86a-408c-9b11-186f434c7678", "AQAAAAEAACcQAAAAEBd7On0W0XquFvQHLHnKrlflqoT/Bt59vLJ+m9xOZCTnJONnpxCYoha2erSomOdDqw==", "d43070bb-a024-4d77-8060-8c299382724f" });
        }
    }
}
