using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admission", "0da5b169-b24c-4768-a939-0b1c2fd0985b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Reception", "3b0d9298-c0a1-420a-b755-59e7ac706bfa" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "4e9bcd46-fc94-4394-9b27-9492edaaa6f0" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "92fc2734-5b36-4a8b-9569-4df2cb1c99b5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administration", "b5b52d8c-556f-4da4-84c1-437e62e6cda1" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0da5b169-b24c-4768-a939-0b1c2fd0985b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3b0d9298-c0a1-420a-b755-59e7ac706bfa");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4e9bcd46-fc94-4394-9b27-9492edaaa6f0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "92fc2734-5b36-4a8b-9569-4df2cb1c99b5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b5b52d8c-556f-4da4-84c1-437e62e6cda1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Administration",
                column: "ConcurrencyStamp",
                value: "ad321268-58a3-4549-ab12-ad39e29dc2a1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Admission",
                column: "ConcurrencyStamp",
                value: "d1a9b44f-a4fd-422e-9816-7b4553780c63");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "6ea2d4db-dc2e-43c0-a950-f9514be30877");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Laboratory",
                column: "ConcurrencyStamp",
                value: "8b4c8f63-b349-46b7-8ebc-1da032013ab0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Management",
                column: "ConcurrencyStamp",
                value: "6439c6be-8987-44fa-9de8-c5d4aece2f20");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Reception",
                column: "ConcurrencyStamp",
                value: "64b45286-9f4c-40b0-83f3-38e3bd21c54e");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c2438c5e-bc02-44ae-b016-b3a34167875c", 0, "8249f9c3-3c24-4b7d-85c9-229c7c8bcce7", "admin@hospital", false, false, null, "ADMIN@HOSPITAL", "ADMIN", "AQAAAAEAACcQAAAAECDebHv8SDXUT+V4Z5eIrKs6zJSTQOyPacOamt8No5Iz4SpxqB6iIqnBbogaSfR+YQ==", null, false, "d1b71df4-6a7f-4e24-8436-15dbb11bffee", false, "admin" },
                    { "395a4a46-912b-4e88-a1bb-86029cd287ad", 0, "da524568-e99e-4b2e-88ce-561d645b1928", "admission@hospital", false, false, null, "ADMISSION@HOSPITAL", "ADMISSION", "AQAAAAEAACcQAAAAEMkMaThNwbU/2kCF4GOQ2YWt6iH/d+AT/OGoExV7nMXUX/RWAc9TKGYKFJiMYk4Bfg==", null, false, "8bcd1459-f8f1-46c3-9d7b-dd9a7a7dccb1", false, "admission" },
                    { "b580b4f4-0234-4a21-a46c-fc5258476a6b", 0, "875629ad-d724-463f-a7ed-a808feba8726", "reception@hospital", false, false, null, "RECEPTION@HOSPITAL", "RECEPTION", "AQAAAAEAACcQAAAAEO1FqN/ga6Rcd36zJfGwCrV2AW3AOxRUuHRSFNd3IMuYo8ykIlctJDMGtYbtbF1g7Q==", null, false, "b2c162db-7c17-4a6a-8cac-aa70290fc548", false, "reception" },
                    { "2eab18c7-40b8-4a4e-abf1-d2c12713682d", 0, "b1315bbe-27b8-4f68-8bfa-aa81c4ba8cdd", "lab@hospital", false, false, null, "LAB@HOSPITAL", "LAB", "AQAAAAEAACcQAAAAEJn+umHPJCZoIJdLmK4410pv+ZyUPWsXoaW03i2BabjDigOxQ8Z4hjiSIaRAXv5/7A==", null, false, "322959c4-1fae-41ed-9c40-18f528c09bb1", false, "lab" },
                    { "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9", 0, "2f73a0f3-a290-4116-9841-979d42eeeb2d", "labdoctor@hospital", false, false, null, "LABDOCTOR@HOSPITAL", "LABDOCTOR", "AQAAAAEAACcQAAAAEBQ6Kkw8oaYpTuv0wEKMwZzTd1NbmZDgHUBfsQax/TyyAYQmtlDsQJoZj3sfAeLoCQ==", null, false, "259cdaee-e1f1-4838-a3b4-6642573c6d0b", false, "labdoctor" },
                    { "51e1bf75-3b3c-4145-898f-372fa01a562b", 0, "86ff2b2d-f888-4e9b-9846-92383f20cf11", "management@hospital", false, false, null, "MANAGEMENT@HOSPITAL", "MANAGEMENT", "AQAAAAEAACcQAAAAEHSqJpJuCHFsQEWpB3NY0yAx0MSJumhGFA9265HaO8SuHH6RrEe/ptasQn4EHmLrtg==", null, false, "68a9f4b7-4947-4561-8173-7dde0de0c8b2", false, "management" },
                    { "a400f105-3a20-46f9-9ac6-aa38dc9be9fe", 0, "a077a142-3698-4ba1-aca4-f5d085725b06", "managerdoctor@hospital", false, false, null, "MANAGERDOCTOR@HOSPITAL", "MANAGERDOCTOR", "AQAAAAEAACcQAAAAEM5h4wynQ8jT31cH16AaeZnSWRy2Y5MEmhUM5T94NwA+0LH5t+fev9ZCIJJxNGSqKA==", null, false, "8da02fad-fa59-4748-a924-f354d8241886", false, "managerdoctor" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Administration", "c2438c5e-bc02-44ae-b016-b3a34167875c" },
                    { "Admission", "395a4a46-912b-4e88-a1bb-86029cd287ad" },
                    { "Reception", "b580b4f4-0234-4a21-a46c-fc5258476a6b" },
                    { "Laboratory", "2eab18c7-40b8-4a4e-abf1-d2c12713682d" },
                    { "Laboratory", "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9" },
                    { "Doctor", "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9" },
                    { "Management", "51e1bf75-3b3c-4145-898f-372fa01a562b" },
                    { "Management", "a400f105-3a20-46f9-9ac6-aa38dc9be9fe" },
                    { "Doctor", "a400f105-3a20-46f9-9ac6-aa38dc9be9fe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "2eab18c7-40b8-4a4e-abf1-d2c12713682d" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admission", "395a4a46-912b-4e88-a1bb-86029cd287ad" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "51e1bf75-3b3c-4145-898f-372fa01a562b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "a400f105-3a20-46f9-9ac6-aa38dc9be9fe" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "a400f105-3a20-46f9-9ac6-aa38dc9be9fe" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Reception", "b580b4f4-0234-4a21-a46c-fc5258476a6b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administration", "c2438c5e-bc02-44ae-b016-b3a34167875c" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2eab18c7-40b8-4a4e-abf1-d2c12713682d");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "395a4a46-912b-4e88-a1bb-86029cd287ad");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3fcc579e-f709-4d4c-ba9f-96bcef6c2ae9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "51e1bf75-3b3c-4145-898f-372fa01a562b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a400f105-3a20-46f9-9ac6-aa38dc9be9fe");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b580b4f4-0234-4a21-a46c-fc5258476a6b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c2438c5e-bc02-44ae-b016-b3a34167875c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Administration",
                column: "ConcurrencyStamp",
                value: "855c48d7-7d6a-40d0-a64e-82681dd0e0aa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Admission",
                column: "ConcurrencyStamp",
                value: "69d81875-703c-4011-b525-3f0e28b1b160");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "87be5950-2bae-42b5-8638-445f104b8223");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Laboratory",
                column: "ConcurrencyStamp",
                value: "e25d8922-d324-42eb-b0b8-a184c0b55359");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Management",
                column: "ConcurrencyStamp",
                value: "83775708-246a-4611-8b78-3d6cd09cc588");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Reception",
                column: "ConcurrencyStamp",
                value: "477fa4cc-fdd5-4e58-8cf4-132a14932d36");

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
        }
    }
}
