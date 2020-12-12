using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class Create_WardAndRoomGrade_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EnName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EnName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a581396-9d5a-42fc-a194-fa04c2f41fe7", "AQAAAAEAACcQAAAAEKWEOHs29hUZMKWlvcfn++TqkRrQ+V9M8kWrwX1SjFXjwr6W+5VqaqqeAAhrtc0yjA==", "066542e2-4e9b-4102-ba12-f99da69596b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomGrades");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04ebd99a-8baf-444e-9ff0-faa08977c59d", "AQAAAAEAACcQAAAAEEnEbErArHnDJbFuBNC4psA6NvW54pN5fKG0KAGX7xxW5FYt6LGrKLIi0tM7aYmyow==", "f47c6cae-dd6e-467d-b154-dd0c902716da" });
        }
    }
}
