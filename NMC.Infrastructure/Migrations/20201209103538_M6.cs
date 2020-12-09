using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "acba7e7f-1247-4123-ae3a-907cc40456c1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3dde0314-9c72-4ea6-abae-3633f04c8b52");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4b3d235c-5280-44e4-9e44-6fff49a9a9aa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5166385d-a161-4f54-a06c-bb28f7eb7517", "AQAAAAEAACcQAAAAEG6JJdnIRoXgsDgESUOfIRLWIYNSs4TifamtjXbqGsz7jjsyQxbXAoJTdrq9GSnAeA==", "6976e297-67ae-440c-9324-e4c17f526abd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4194bac9-559e-4069-87a9-a22b85dc3ee2", "AQAAAAEAACcQAAAAEDLHYnZ3KJJEZC523hmUkbj/hWcXSCOmQh9YiVg2hot2xf0Bm3Q0jfKtE1mrTQoDKA==", "9845911b-58c0-4348-be3e-77e1d77b1dfd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226bd783-7de3-41fa-a469-ad694b3be0f3", "AQAAAAEAACcQAAAAEPOlGV77kwe0T1RhTyXMi5PEcxKuIuuymCK2xtZbzWkw+L0PmJ7lHZqramKa6cIODQ==", "5582acdb-d0a0-480b-88bf-a756fd33c02e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "23dad0b2-48bf-4cf4-8177-5239f585fcd7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "940fee37-7e11-434f-b40d-c9daca78b505");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "dd84191b-2a4b-49d9-8d60-6c4648aa9da1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9bd085f-fa4f-4571-81cc-56091e56738a", "AQAAAAEAACcQAAAAECQXiqJrXRoPWeTIITHNjvb+xcznL1Ya9UKZA491m7hjLeX8fGPaKUvtbjK4P888YA==", "b82b8e0b-b89a-4a43-a727-4ff028782a43" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84faf830-8e89-4bed-ad94-3cdaa7368600", "AQAAAAEAACcQAAAAEP/qZtEjGhBxf1+72qExgnUcINsQ+AyZSjmrSiYrVQOPOGJBcGsQQ+tIfFfEbhW/RA==", "d56f8cce-4303-4480-b841-700450353d6e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "725f09bd-15c0-446a-83d5-c11c7483af44", "AQAAAAEAACcQAAAAEHpwL8FCNwjJmU4ZXaVIZpc8ZVzHE0PTXBAZOgAu4Hr18BGtmXR2nCxeGDoVC53kjw==", "e9e4b574-15aa-41a9-9e40-b09cf04d3d62" });
        }
    }
}
