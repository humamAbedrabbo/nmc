using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Username", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Administration", "855c48d7-7d6a-40d0-a64e-82681dd0e0aa", "Administration", "Administration" },
                    { "Admission", "69d81875-703c-4011-b525-3f0e28b1b160", "Admission", "Admission" },
                    { "Reception", "477fa4cc-fdd5-4e58-8cf4-132a14932d36", "Reception", "Reception" },
                    { "Doctor", "87be5950-2bae-42b5-8638-445f104b8223", "Doctor", "Doctor" },
                    { "Laboratory", "e25d8922-d324-42eb-b0b8-a184c0b55359", "Laboratory", "Laboratory" },
                    { "Management", "83775708-246a-4611-8b78-3d6cd09cc588", "Management", "Management" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b5b52d8c-556f-4da4-84c1-437e62e6cda1", 0, "e6724f63-2a63-43e1-aac8-75bea8682e1d", "admin@hospital", false, false, null, "ADMIN@HOSPITAL", "ADMIN", "AQAAAAEAACcQAAAAENaXmE5tL5McHwSuX5IqYgwRC0NyCVFUhHh4z/wlaCuyYTiSi0qEkvESPTrK0RKI/w==", null, false, "a82be335-d428-478a-911a-d4ed455557a8", false, "admin" },
                    { "0da5b169-b24c-4768-a939-0b1c2fd0985b", 0, "cfe2fa92-7ba1-4c05-83b8-85c122ef8291", "admission@hospital", false, false, null, "ADMISSION@HOSPITAL", "ADMISSION", "AQAAAAEAACcQAAAAECEQJPkOzzyHybfgXqvxjqhS15rZZ2iVtA+EhOshB1WPT2cyT8eGBUN1LFJUAOJGxQ==", null, false, "d4e4ca2c-61e7-453b-a814-b89198d94107", false, "admission" },
                    { "3b0d9298-c0a1-420a-b755-59e7ac706bfa", 0, "8eb943fd-616c-417f-997d-57be00a00f5d", "reception@hospital", false, false, null, "RECEPTION@HOSPITAL", "RECEPTION", "AQAAAAEAACcQAAAAEPMRh1tT/H0crmRnhRjn/1KVDvHHKrA9fzHNst1agQQtPlwQ43bPqa5HOR+0D+7V9g==", null, false, "bcb45f0f-360a-4466-a79e-4dedf364182f", false, "reception" },
                    { "4e9bcd46-fc94-4394-9b27-9492edaaa6f0", 0, "bdd23eca-243e-41b6-aee6-495dcafb4700", "lab@hospital", false, false, null, "LAB@HOSPITAL", "LAB", "AQAAAAEAACcQAAAAEPjCZpHuqtixC5EzhnPdaG2rsMPDjmvpUofdTk9bmGU8BnC0xQw1GigCBPTanYm+9w==", null, false, "7fd41bbc-787c-4250-bc78-0da189f4ad11", false, "lab" },
                    { "92fc2734-5b36-4a8b-9569-4df2cb1c99b5", 0, "d6a0f1d9-474c-4e41-9f5f-38210a916fd7", "management@hospital", false, false, null, "MANAGEMENT@HOSPITAL", "MANAGEMENT", "AQAAAAEAACcQAAAAEKrXhFKm5Lxx0pfnPAzgUi8ZgiXIxf4ZRxfIlrTcHjD1c4gyjrFu/r8SGUfxeZsvCQ==", null, false, "1afa47d7-3d51-43cd-8b12-e8cc74fe23c8", false, "management" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Administration", "b5b52d8c-556f-4da4-84c1-437e62e6cda1" },
                    { "Admission", "0da5b169-b24c-4768-a939-0b1c2fd0985b" },
                    { "Reception", "3b0d9298-c0a1-420a-b755-59e7ac706bfa" },
                    { "Laboratory", "4e9bcd46-fc94-4394-9b27-9492edaaa6f0" },
                    { "Management", "92fc2734-5b36-4a8b-9569-4df2cb1c99b5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
