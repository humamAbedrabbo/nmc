using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN", "78acee41-7604-4f70-97cc-6792d2815d05" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "78acee41-7604-4f70-97cc-6792d2815d05");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ACT",
                column: "ConcurrencyStamp",
                value: "76528703-0338-4530-b4ee-03e516a887e0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "4b8d1594-fd16-450f-998a-e292708b85a5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "DOCTOR",
                column: "ConcurrencyStamp",
                value: "8262d9d2-ee9a-4784-9a30-6b18d689dd3b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "FD",
                column: "ConcurrencyStamp",
                value: "5dcddded-f173-45a8-9252-42814de8e825");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABD",
                column: "ConcurrencyStamp",
                value: "782e1de2-8cfb-4581-8a8e-2ff66aac3b6d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABT",
                column: "ConcurrencyStamp",
                value: "5c7c7a2e-6b71-4ff7-b6c4-6f21b76d189f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "MGT",
                column: "ConcurrencyStamp",
                value: "83935821-9830-4b87-a05f-2b2d9e8ff5c8");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "37988cc0-4e95-4d2d-95fe-868a02f340d0", 0, "563fbecc-1536-4d61-b515-e5722810b07a", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAEE+opIYw4LB22xmgzVGirBZ+9/Nbv4Hj2/qVIlM18WcDIHzafPUqJGjCL8sFJwYkEg==", null, false, "eac4bd1a-2968-446b-a371-9805a04e0674", false, "admin" },
                    { "aaeaaa27-0e58-4b56-bd87-6731cd1a3180", 0, "05cbe6bb-0cb0-4fe0-a178-d627efabe21b", "fd@localhost", false, false, null, "FD@LOCALHOST", "FD", "AQAAAAEAACcQAAAAEH88cZPjjrycfm0iWE+4KF9YXJNk0ts42ixID3k10BOkiW30gaAgBYvZYQtxaIwdDQ==", null, false, "20b6a684-6f2a-4f1f-8d52-c47007c14c2c", false, "fd" },
                    { "3185f5ed-b6d6-4d20-acec-79bfb188c972", 0, "884fb419-b98e-426e-9074-932aa2169e7e", "act@localhost", false, false, null, "ACT@LOCALHOST", "ACT", "AQAAAAEAACcQAAAAEFjqAe/0z6mmcnziKGlIi9sUk/RD3A9p0YvAI27IQls8qcz2tb3iQNj5qbkpVTBgeA==", null, false, "83512b17-848e-4315-8ffa-96c0ec8f3e40", false, "act" },
                    { "d80a9d06-3cd3-41d2-80ef-04aa5e71131c", 0, "174bdf24-ab47-4dc0-afca-26a9682862ba", "mgt@localhost", false, false, null, "MGT@LOCALHOST", "MGT", "AQAAAAEAACcQAAAAEHO61bnMNcXVxB3HGrHystrxWBV/3CF51KdBmn9135LijxJa7SeJqMtTquIYlTtc2A==", null, false, "8abbfa9e-3975-4ed9-8f22-0ab8c2a7a472", false, "mgt" }
                });

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "37988cc0-4e95-4d2d-95fe-868a02f340d0");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 2, "Language", "en", "aaeaaa27-0e58-4b56-bd87-6731cd1a3180" },
                    { 3, "Language", "en", "3185f5ed-b6d6-4d20-acec-79bfb188c972" },
                    { 4, "Language", "en", "d80a9d06-3cd3-41d2-80ef-04aa5e71131c" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ADMIN", "37988cc0-4e95-4d2d-95fe-868a02f340d0" },
                    { "FD", "aaeaaa27-0e58-4b56-bd87-6731cd1a3180" },
                    { "ACT", "3185f5ed-b6d6-4d20-acec-79bfb188c972" },
                    { "MGT", "d80a9d06-3cd3-41d2-80ef-04aa5e71131c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ACT", "3185f5ed-b6d6-4d20-acec-79bfb188c972" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN", "37988cc0-4e95-4d2d-95fe-868a02f340d0" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FD", "aaeaaa27-0e58-4b56-bd87-6731cd1a3180" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "MGT", "d80a9d06-3cd3-41d2-80ef-04aa5e71131c" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3185f5ed-b6d6-4d20-acec-79bfb188c972");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "37988cc0-4e95-4d2d-95fe-868a02f340d0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aaeaaa27-0e58-4b56-bd87-6731cd1a3180");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d80a9d06-3cd3-41d2-80ef-04aa5e71131c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ACT",
                column: "ConcurrencyStamp",
                value: "a2a5bbe2-00b1-4326-8263-debb55f8d115");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "c3fdc4e4-0768-4632-af27-54a3cbb14350");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "DOCTOR",
                column: "ConcurrencyStamp",
                value: "d290a24d-1287-400c-9b3d-86c4bc48baf4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "FD",
                column: "ConcurrencyStamp",
                value: "7d2097cd-deca-4ea0-9603-aad327287d24");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABD",
                column: "ConcurrencyStamp",
                value: "766d76cf-36d3-4eb6-83b6-fbdfdbc3496e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABT",
                column: "ConcurrencyStamp",
                value: "ea0550b5-0fec-4c41-8221-f860c95d7ea4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "MGT",
                column: "ConcurrencyStamp",
                value: "74883392-4c48-4f7d-bffb-33524daa85d0");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78acee41-7604-4f70-97cc-6792d2815d05", 0, "8ab957b0-422a-454f-8c04-3e02de9637ef", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAEGPob204e/c36wd6kCYooqJWp4VDLsQYwgld9gqS5eiuxDbeFLde3kkgQ/qUWSSm3g==", null, false, "99779c11-b2bf-4469-9645-01e06b9a0213", false, "admin" });

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "78acee41-7604-4f70-97cc-6792d2815d05");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN", "78acee41-7604-4f70-97cc-6792d2815d05" });
        }
    }
}
