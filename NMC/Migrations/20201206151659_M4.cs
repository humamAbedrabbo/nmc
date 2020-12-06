using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "Accounting",
                column: "ConcurrencyStamp",
                value: "7876f648-af33-4a2e-94a0-883a29397e1d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Administration",
                column: "ConcurrencyStamp",
                value: "05cd24f9-12cb-49b6-a8dc-01d508b6a443");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Admission",
                column: "ConcurrencyStamp",
                value: "fd18b843-4333-4dfa-acff-aad25fb80828");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "6c18262a-aafd-4458-b807-f881cad27ab7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Laboratory",
                column: "ConcurrencyStamp",
                value: "fce778ed-6738-43c9-805a-f62f7b6e7672");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Management",
                column: "ConcurrencyStamp",
                value: "fbc9c3b5-8ea0-4162-8537-2b566aab1589");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Reception",
                column: "ConcurrencyStamp",
                value: "af4610a0-efbf-4f16-8146-fbd335d2bf52");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "708438e0-7901-4c5b-acb5-099ba1291f1c", 0, "241cc58d-caa9-472c-8bba-ff7cbc27c13e", "admin@hospital", false, false, null, "ADMIN@HOSPITAL", "ADMIN", "AQAAAAEAACcQAAAAEFKMgukW4ZMUUDBgCCKpHi6gWm3cWnDkIXCZncudyTLH767cVRpw40u3/YT7T+2TvQ==", null, false, "ed1f3e31-15c3-4b11-8288-4c930cf98ebd", false, "admin" },
                    { "623996ed-beb4-46aa-b77a-222b09002157", 0, "f817649c-d5af-4262-88ea-bbb39261fc0d", "admission@hospital", false, false, null, "ADMISSION@HOSPITAL", "ADMISSION", "AQAAAAEAACcQAAAAEGAJvYvwE76DphYycdKKq7cEReAJB29V34BJ3F6WkTBY/aU+wROTLUwgrdi6xwYDvA==", null, false, "80041790-0133-494d-9526-73bf3f8bba27", false, "admission" },
                    { "65753b5f-86fa-4249-9fe3-c92715457f0f", 0, "0f6fc97e-3635-4f43-a583-0c3cddb61c1d", "reception@hospital", false, false, null, "RECEPTION@HOSPITAL", "RECEPTION", "AQAAAAEAACcQAAAAEBUQqBXLjZ/BnFoQGdEtsZNt6RQA1gDMglsfSw4C4oWy/vTcm1DV7DMIcU+PxdJJzg==", null, false, "2723ed2c-64fc-401c-8969-8a0ecdca1a92", false, "reception" },
                    { "a7585c6a-13d8-471b-8f35-457d8c0765b1", 0, "8671c9e1-8885-4032-96ea-b2cb0545af61", "lab@hospital", false, false, null, "LAB@HOSPITAL", "LAB", "AQAAAAEAACcQAAAAEMnOfy/1dQmxLZQK6HWBu4D1JKjC5+KoyvxMJpHuSeL8TtRBZmfCPW+YrzQbkKgaGQ==", null, false, "8c2ea19d-0c8e-4915-bc38-d4f661fae261", false, "lab" },
                    { "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13", 0, "592c29ea-bfca-4c3f-99a0-6f94d9145ca3", "labdoctor@hospital", false, false, null, "LABDOCTOR@HOSPITAL", "LABDOCTOR", "AQAAAAEAACcQAAAAEL4jtzXwgiguCLG1LutModvEMKREvby6UNTA9wkj2uaBUL+5rCO6AOZytjFkMr4+Jw==", null, false, "8748cf2e-51b6-45e0-84d0-f87e5bdb3328", false, "labdoctor" },
                    { "2d001c2b-2492-4084-9985-3cd200619df1", 0, "4e1c0818-f8b6-4577-88fe-c080e7e19f29", "management@hospital", false, false, null, "MANAGEMENT@HOSPITAL", "MANAGEMENT", "AQAAAAEAACcQAAAAEDZXOCng+DI43PBwertVoUKDl/kW53P067KNAljCaQEjuUR2UhYfngz2R1dpGsvvOQ==", null, false, "2cce605f-3743-484e-856c-cbf431d84852", false, "management" },
                    { "984b6162-8ad4-48e7-8367-d313a0dfcfe0", 0, "49da5ae2-3007-4f00-bbc3-99546adae37d", "managerdoctor@hospital", false, false, null, "MANAGERDOCTOR@HOSPITAL", "MANAGERDOCTOR", "AQAAAAEAACcQAAAAEL6aheEyqA0jfRGGMMGl639Xslbrd6YObOuzRp3z2fT1nOPKDgONmBhlVIrtirEOHQ==", null, false, "ee181c68-ade7-41dd-b527-86cecca4779e", false, "managerdoctor" },
                    { "cfadd3f4-6619-4d62-9dd9-6912b68ba25e", 0, "1a06100e-27b3-43dd-89a0-850c7a222e23", "accountant@hospital", false, false, null, "ACCOUNTANT@HOSPITAL", "ACCOUNTANT", "AQAAAAEAACcQAAAAEISQfWZsgi1nchHL0kwxqUQ+aqf5/btxVhKAb6bkOBWU5GkpExWPqz4L/DUyHX1JPA==", null, false, "e3d21836-49b6-4d42-8d6c-0886e7d9964f", false, "accountant" },
                    { "52ed9b9a-e54b-4de7-9fe0-04e0bcc7c732", 0, "0602ec25-1bde-43b8-84c1-de3cec57afa7", "doctor@hospital", false, false, null, "DOCTOR@HOSPITAL", "DOCTOR", "AQAAAAEAACcQAAAAEI1W45XTtwm36AWlHsUUhoQ1cGsTtEztkvBjSOaddN3EJYD3UHocNKEcgo45BXEIRg==", null, false, "d4ef07d8-688b-4f02-9736-382e9dc20ed0", false, "doctor" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Administration", "708438e0-7901-4c5b-acb5-099ba1291f1c" },
                    { "Admission", "623996ed-beb4-46aa-b77a-222b09002157" },
                    { "Reception", "65753b5f-86fa-4249-9fe3-c92715457f0f" },
                    { "Laboratory", "a7585c6a-13d8-471b-8f35-457d8c0765b1" },
                    { "Laboratory", "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13" },
                    { "Doctor", "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13" },
                    { "Management", "2d001c2b-2492-4084-9985-3cd200619df1" },
                    { "Management", "984b6162-8ad4-48e7-8367-d313a0dfcfe0" },
                    { "Doctor", "984b6162-8ad4-48e7-8367-d313a0dfcfe0" },
                    { "Accounting", "cfadd3f4-6619-4d62-9dd9-6912b68ba25e" },
                    { "Doctor", "52ed9b9a-e54b-4de7-9fe0-04e0bcc7c732" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "2d001c2b-2492-4084-9985-3cd200619df1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "52ed9b9a-e54b-4de7-9fe0-04e0bcc7c732" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admission", "623996ed-beb4-46aa-b77a-222b09002157" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Reception", "65753b5f-86fa-4249-9fe3-c92715457f0f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administration", "708438e0-7901-4c5b-acb5-099ba1291f1c" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Doctor", "984b6162-8ad4-48e7-8367-d313a0dfcfe0" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Management", "984b6162-8ad4-48e7-8367-d313a0dfcfe0" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Laboratory", "a7585c6a-13d8-471b-8f35-457d8c0765b1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Accounting", "cfadd3f4-6619-4d62-9dd9-6912b68ba25e" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2d001c2b-2492-4084-9985-3cd200619df1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "52ed9b9a-e54b-4de7-9fe0-04e0bcc7c732");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5fbdd3ae-8f9a-47b7-9492-b4b67c8dca13");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "623996ed-beb4-46aa-b77a-222b09002157");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "65753b5f-86fa-4249-9fe3-c92715457f0f");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "708438e0-7901-4c5b-acb5-099ba1291f1c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "984b6162-8ad4-48e7-8367-d313a0dfcfe0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a7585c6a-13d8-471b-8f35-457d8c0765b1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cfadd3f4-6619-4d62-9dd9-6912b68ba25e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Accounting",
                column: "ConcurrencyStamp",
                value: "f7740252-2b8c-4f22-8eab-97f27dda59ff");

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
    }
}
