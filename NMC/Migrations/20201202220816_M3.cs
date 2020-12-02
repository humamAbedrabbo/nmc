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
                keyValues: new object[] { "ADMIN", "098c3aac-d697-4428-a74a-8d08cb5a247e" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FD", "2ce4de5d-c57f-4988-8b8e-7d4d496cc8b7" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ACT", "54143932-f9d0-430c-9756-c62441a1c08a" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "MGT", "93de76c0-6e25-4a33-a25c-41eb999af4a6" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "098c3aac-d697-4428-a74a-8d08cb5a247e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2ce4de5d-c57f-4988-8b8e-7d4d496cc8b7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "54143932-f9d0-430c-9756-c62441a1c08a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "93de76c0-6e25-4a33-a25c-41eb999af4a6");

            migrationBuilder.InsertData(
                table: "RoleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "DEPT", "Department" },
                    { "DOCTOR", "Doctor" },
                    { "IN-PATIENT", "In-Patient" },
                    { "OUT-PATIENT", "Out-Patient" },
                    { "EMP", "Employee" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ACT",
                column: "ConcurrencyStamp",
                value: "3a3d16ce-6333-4419-9487-03a06da89c02");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "7b676a2c-e579-4a02-a0a9-64cb1c36d2aa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "DOCTOR",
                column: "ConcurrencyStamp",
                value: "2614c86c-ede7-4c08-bc1d-5e8aa702400b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "FD",
                column: "ConcurrencyStamp",
                value: "f794d6a1-b85e-4f66-bb0f-14ce67339780");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABD",
                column: "ConcurrencyStamp",
                value: "5183416b-8a8d-4ed3-adf5-c602f4b718d7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABT",
                column: "ConcurrencyStamp",
                value: "e19d262a-1264-483c-9b6f-3aab3d910eec");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "MGT",
                column: "ConcurrencyStamp",
                value: "d4a1863a-b4a4-4f69-b29a-16c4800469ef");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b24f0228-9ae8-4263-8686-8c0075e6569c", 0, "e8508279-366c-485e-abb8-e172e2afe8c2", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAEPTB/bGCF0GqiDRLHStKfnP9GrwxQvuly0b9GPMQ7pSD7CCmQizEvpl3YJs4calShA==", null, false, "4550b461-25a8-49b1-8c6c-b43c2eb491f1", false, "admin" },
                    { "82e3f6ad-c780-4d51-bab5-1f003257aece", 0, "424cca19-984d-48a1-97ae-27d02e816271", "fd@localhost", false, false, null, "FD@LOCALHOST", "FD", "AQAAAAEAACcQAAAAEF8JniAP6rfi91Yb0UjKhX5qav9s3OkT/1NPQ/5w9d9bnhYe6p54Il/rJAvgf0KtKw==", null, false, "151a4318-e2af-4556-9509-f28ea3fa3e9d", false, "fd" },
                    { "a51de5bf-cc8a-474c-b332-241da3dd08e2", 0, "7b8d8e9d-9d60-426d-91c1-0e3ab4fc62d0", "act@localhost", false, false, null, "ACT@LOCALHOST", "ACT", "AQAAAAEAACcQAAAAEM9rtyTJv/X5mOt4kMktT13NWDtXZHRbXDkP7LRobhQASvzQLXUZu/DfS1/urBnCEg==", null, false, "00e125c1-630f-4cd4-9853-0f212f89d6d1", false, "act" },
                    { "fdef25cb-6284-4598-9732-f050f5745d7b", 0, "49f3e79c-bfe7-4504-8d1e-714ab5b91d54", "mgt@localhost", false, false, null, "MGT@LOCALHOST", "MGT", "AQAAAAEAACcQAAAAEOW/MRg2xtq43sjsJvWu5tOilyZLFvBr5u3Ljk/NAfdeXZm7PSBQfc+nhGRH8KXeRA==", null, false, "2ca97d23-de80-4a17-b76a-c3ca2bfb23f8", false, "mgt" }
                });

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "b24f0228-9ae8-4263-8686-8c0075e6569c");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "82e3f6ad-c780-4d51-bab5-1f003257aece");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "a51de5bf-cc8a-474c-b332-241da3dd08e2");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "fdef25cb-6284-4598-9732-f050f5745d7b");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ADMIN", "b24f0228-9ae8-4263-8686-8c0075e6569c" },
                    { "FD", "82e3f6ad-c780-4d51-bab5-1f003257aece" },
                    { "ACT", "a51de5bf-cc8a-474c-b332-241da3dd08e2" },
                    { "MGT", "fdef25cb-6284-4598-9732-f050f5745d7b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleTypes",
                keyColumn: "Id",
                keyValue: "DEPT");

            migrationBuilder.DeleteData(
                table: "RoleTypes",
                keyColumn: "Id",
                keyValue: "DOCTOR");

            migrationBuilder.DeleteData(
                table: "RoleTypes",
                keyColumn: "Id",
                keyValue: "EMP");

            migrationBuilder.DeleteData(
                table: "RoleTypes",
                keyColumn: "Id",
                keyValue: "IN-PATIENT");

            migrationBuilder.DeleteData(
                table: "RoleTypes",
                keyColumn: "Id",
                keyValue: "OUT-PATIENT");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FD", "82e3f6ad-c780-4d51-bab5-1f003257aece" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ACT", "a51de5bf-cc8a-474c-b332-241da3dd08e2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN", "b24f0228-9ae8-4263-8686-8c0075e6569c" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "MGT", "fdef25cb-6284-4598-9732-f050f5745d7b" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "82e3f6ad-c780-4d51-bab5-1f003257aece");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a51de5bf-cc8a-474c-b332-241da3dd08e2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b24f0228-9ae8-4263-8686-8c0075e6569c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "fdef25cb-6284-4598-9732-f050f5745d7b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ACT",
                column: "ConcurrencyStamp",
                value: "4d13f57e-6c8b-45e1-8560-faeef23bb880");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "ded154fe-491e-46c3-abf1-01c3d2068e80");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "DOCTOR",
                column: "ConcurrencyStamp",
                value: "d0db8c15-f779-4d5f-932f-534063926611");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "FD",
                column: "ConcurrencyStamp",
                value: "1992849a-3423-4e64-a405-a89ec9d4ee3a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABD",
                column: "ConcurrencyStamp",
                value: "a0c7d4e6-49ef-430d-8fea-3b631b2a0f45");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "LABT",
                column: "ConcurrencyStamp",
                value: "87b586e4-9571-45cf-9836-9e842d2a9e49");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "MGT",
                column: "ConcurrencyStamp",
                value: "a9fa75f7-9984-4db8-be62-ef9263eae5d1");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "098c3aac-d697-4428-a74a-8d08cb5a247e", 0, "c4e7a49b-9677-46a5-b31d-c50e1f5f55f5", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAECz462bKW7kEidNB6BCjGod+PUsQ+8INkfFkdukslaVS9U1ziHqikN7g72gZXna7JQ==", null, false, "436712fb-78aa-4e50-85bb-e466559013f9", false, "admin" },
                    { "2ce4de5d-c57f-4988-8b8e-7d4d496cc8b7", 0, "fbfff2b2-6354-40c6-8214-4c02da3e10a5", "fd@localhost", false, false, null, "FD@LOCALHOST", "FD", "AQAAAAEAACcQAAAAEHXcMylYkbhQW9/HldVq/yA/9MNIk+ha5932Rd7MNT8/7vm/IPAfPRLLrYLDZyW4Bw==", null, false, "0a018329-1d31-4451-be70-e94b89123b53", false, "fd" },
                    { "54143932-f9d0-430c-9756-c62441a1c08a", 0, "10397911-45d1-4f5a-821f-f7b7a4dde029", "act@localhost", false, false, null, "ACT@LOCALHOST", "ACT", "AQAAAAEAACcQAAAAEOyK/0exLHZ015o2xkQXTiVPK4+2S1FXrnOa4qIN2wL0wcOwvQc1E5lqzaUedU8XSA==", null, false, "9f89be2d-13e5-4652-821a-f68ce40e4000", false, "act" },
                    { "93de76c0-6e25-4a33-a25c-41eb999af4a6", 0, "5568b232-a14a-4618-9f00-5796ba37e65e", "mgt@localhost", false, false, null, "MGT@LOCALHOST", "MGT", "AQAAAAEAACcQAAAAEGL+rhXaXX4h3WUpxhuNa3qKv8GrJL0VNffxApBgc42M2YQCXDy+pbKCE71NlAvGVA==", null, false, "40c18e42-8b00-47c4-b262-f4d2e68a0e8c", false, "mgt" }
                });

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "098c3aac-d697-4428-a74a-8d08cb5a247e");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "2ce4de5d-c57f-4988-8b8e-7d4d496cc8b7");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "54143932-f9d0-430c-9756-c62441a1c08a");

            migrationBuilder.UpdateData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "93de76c0-6e25-4a33-a25c-41eb999af4a6");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ADMIN", "098c3aac-d697-4428-a74a-8d08cb5a247e" },
                    { "FD", "2ce4de5d-c57f-4988-8b8e-7d4d496cc8b7" },
                    { "ACT", "54143932-f9d0-430c-9756-c62441a1c08a" },
                    { "MGT", "93de76c0-6e25-4a33-a25c-41eb999af4a6" }
                });
        }
    }
}
