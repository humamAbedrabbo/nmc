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
                value: "5f60c984-4f5e-4c87-a50d-641ff778cfcc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Admission",
                column: "ConcurrencyStamp",
                value: "6788f53d-8cbe-42e9-89f1-7999b9b3380c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "985f85f6-5df2-42c8-97e1-5c9288c69fb7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Laboratory",
                column: "ConcurrencyStamp",
                value: "868b3660-a039-41e9-a681-4d34a7901f37");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Management",
                column: "ConcurrencyStamp",
                value: "6b26f929-801c-460c-83e3-665a64bd54ca");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Reception",
                column: "ConcurrencyStamp",
                value: "e8a46a12-d44c-498f-8c5c-234cc2b59fcc");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Accounting", "f7740252-2b8c-4f22-8eab-97f27dda59ff", "Accounting", "Accounting" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "203e1859-dce6-4160-b40b-47b08f1f1ae8", 0, "b5849cb0-a0d2-44a0-941a-085c605c03fc", "admin@hospital", false, false, null, "ADMIN@HOSPITAL", "ADMIN", "AQAAAAEAACcQAAAAEH3K8uKYltHixEvKjXgtapTIGPwExhgqmylkKoxOXha0kHtasVJzF+1fn9dLq88W/w==", null, false, "7f82e8ec-6dc1-47ed-942b-0bb887a567c0", false, "admin" },
                    { "c5125370-766e-4241-92e5-a500438d42d2", 0, "baadae77-d406-4cf1-8408-1923cc02a701", "admission@hospital", false, false, null, "ADMISSION@HOSPITAL", "ADMISSION", "AQAAAAEAACcQAAAAECeZIpUpcZMnxzO/h2M600ti7GHA/qSTEvZKzjiiLvwsC5PArrXXGxqTn73VkIwtJA==", null, false, "0ff18d5c-9d01-482a-ac3c-4ca720c1389e", false, "admission" },
                    { "50977287-d6f2-467f-8eb6-afac28ca526f", 0, "1d8044ba-a2e4-46f3-a7d5-a2b6a60bc22d", "reception@hospital", false, false, null, "RECEPTION@HOSPITAL", "RECEPTION", "AQAAAAEAACcQAAAAEHCTlP7mmQLTGrPyF+jpBjxPw34JadfJA5zpLej2B5GNh2bIMu7zCUbS22lBYa8ltQ==", null, false, "05f31e90-bfdd-493d-b40d-8f0e63f60cee", false, "reception" },
                    { "cf987f03-fff1-44f6-b73f-076c1dd5c6cd", 0, "d549bccb-1ebc-4fec-9f0d-9172158d93e1", "lab@hospital", false, false, null, "LAB@HOSPITAL", "LAB", "AQAAAAEAACcQAAAAEE9/055CwnhOldo2qiAfdqfIQfVKcQYrw5/klleO9SHf8Y+2dz8rhwpvavYjENpNwQ==", null, false, "3c15607c-a262-4aff-bab7-fd0f7512ecfc", false, "lab" },
                    { "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66", 0, "5663b3f7-26ed-468e-8729-c6718e20a728", "labdoctor@hospital", false, false, null, "LABDOCTOR@HOSPITAL", "LABDOCTOR", "AQAAAAEAACcQAAAAEPD7CwTEwu5YMIC/Ioweq27i4lswnEVYB7fRe8UHOsX4Eoqgndrx3Pkp0NpaB8ySQw==", null, false, "ae06d2ef-f2bc-4779-98a9-6e31f69898d4", false, "labdoctor" },
                    { "c612bf59-eb90-41f5-8896-045e2a9bec8c", 0, "b840ef6e-4576-4e47-8d3a-260374e0aeb9", "management@hospital", false, false, null, "MANAGEMENT@HOSPITAL", "MANAGEMENT", "AQAAAAEAACcQAAAAEFIxqwnb5sKPrqa9lBywOJPxxopNR72Ey/GJmvU894gSaV4USIBnc/wfj/sm2riijw==", null, false, "c90568f3-71b2-4deb-9e47-2b697a59a313", false, "management" },
                    { "6401f52a-d001-45d0-a7f1-0b7e6ee25114", 0, "9bcb1eed-c135-44f8-9121-40fd26301e79", "managerdoctor@hospital", false, false, null, "MANAGERDOCTOR@HOSPITAL", "MANAGERDOCTOR", "AQAAAAEAACcQAAAAEFl5iHRfbVDPIfKGHjLqT45P8rikqZCQnYptBOrZV1o7bjm6rOjZtg+pUI20bJIW6g==", null, false, "98a80da8-b7c1-4e81-b28e-c224217f54bd", false, "managerdoctor" },
                    { "cdef69ac-c872-48d7-81cd-ac450eb07ced", 0, "dc89c719-6f98-454b-8fba-5a8e95221074", "accountant@hospital", false, false, null, "ACCOUNTANT@HOSPITAL", "ACCOUNTANT", "AQAAAAEAACcQAAAAEBWIXlLIYik/FZaQJUdFUofD4+Basth5vqlOzbeGhfgwfDa4CPsXBzQRhIu3WrUF9g==", null, false, "6740279b-7410-4183-a76f-8104241f0c9d", false, "accountant" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Administration", "203e1859-dce6-4160-b40b-47b08f1f1ae8" },
                    { "Admission", "c5125370-766e-4241-92e5-a500438d42d2" },
                    { "Reception", "50977287-d6f2-467f-8eb6-afac28ca526f" },
                    { "Laboratory", "cf987f03-fff1-44f6-b73f-076c1dd5c6cd" },
                    { "Laboratory", "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66" },
                    { "Doctor", "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66" },
                    { "Management", "c612bf59-eb90-41f5-8896-045e2a9bec8c" },
                    { "Management", "6401f52a-d001-45d0-a7f1-0b7e6ee25114" },
                    { "Doctor", "6401f52a-d001-45d0-a7f1-0b7e6ee25114" },
                    { "Accounting", "cdef69ac-c872-48d7-81cd-ac450eb07ced" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administration", "203e1859-dce6-4160-b40b-47b08f1f1ae8" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Reception", "50977287-d6f2-467f-8eb6-afac28ca526f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "6401f52a-d001-45d0-a7f1-0b7e6ee25114" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "6401f52a-d001-45d0-a7f1-0b7e6ee25114" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admission", "c5125370-766e-4241-92e5-a500438d42d2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "c612bf59-eb90-41f5-8896-045e2a9bec8c" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Accounting", "cdef69ac-c872-48d7-81cd-ac450eb07ced" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "cf987f03-fff1-44f6-b73f-076c1dd5c6cd" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Accounting");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203e1859-dce6-4160-b40b-47b08f1f1ae8");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "50977287-d6f2-467f-8eb6-afac28ca526f");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6401f52a-d001-45d0-a7f1-0b7e6ee25114");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c5125370-766e-4241-92e5-a500438d42d2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c612bf59-eb90-41f5-8896-045e2a9bec8c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cdef69ac-c872-48d7-81cd-ac450eb07ced");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cf987f03-fff1-44f6-b73f-076c1dd5c6cd");

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
    }
}
