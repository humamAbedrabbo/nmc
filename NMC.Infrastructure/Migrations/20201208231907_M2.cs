using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f93cc88-d6fd-4009-a10a-01087a45c35e", "AQAAAAEAACcQAAAAENa6TUUNKWerFzUZqxjOXN2WEMHAG8cIcXJGh6oe+KkmQAQDJ+Y6BcDq/YAovd2I/A==", "ac71cda4-16f5-4a44-8f7c-652d7cb8275b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f59aa59f-8836-4386-a4a4-3a1713cc23ed", "AQAAAAEAACcQAAAAEB1VULmaITabTuP4sUy57+finl7S5KOOqi/OfgRldHCsFO5zdAZ2QQgPEAPfC9/qwg==", "9bb89ed8-427e-4c1b-a181-4619539622d7" });
        }
    }
}
