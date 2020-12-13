using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class Create_Doctor_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DoctorType = table.Column<int>(type: "integer", nullable: false),
                    Referrer = table.Column<bool>(type: "boolean", nullable: false),
                    Surgeon = table.Column<bool>(type: "boolean", nullable: false),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37d7655a-cae2-48cc-9829-83031552eb0f", "AQAAAAEAACcQAAAAEHaAFNJkrr77uahboCzx/CyodFG7lutM5kxbPZ6Zez+P9U+WNX/kk0mIXYu6cUJfSA==", "27760718-b76c-4b8a-86a3-37cfd02547dc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5562ad1-4882-418d-b8d3-e32fee7d3af2", "AQAAAAEAACcQAAAAEPT/5bV/BuDXWVSre+B5Ai31oZisd9KRIouZfkcQ3Eqyvb3blB/tuNZV5A7jX3eJYQ==", "d76458e7-43be-494a-afe4-80f26877dcf2" });
        }
    }
}
