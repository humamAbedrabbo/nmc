using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class RoomGrade_Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inpatients_RoomGrades_RoomGradeId",
                table: "Inpatients");

            migrationBuilder.AlterColumn<int>(
                name: "RoomGradeId",
                table: "Inpatients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d7d549b9-dc63-4110-aba0-9c45a709cf42");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d278270c-7a5d-4740-aef3-bf975543fd35");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2b357080-abc0-4e12-bb61-4da52ce36852");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "386d2ae2-aabe-46b7-aa67-d6d588219c5a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "b09fadd4-f3a7-4487-be4a-961d728bb1f1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67acb405-b4fd-43a0-9ca8-b6dd997d0e62", "AQAAAAEAACcQAAAAEB8IYABlmPYrjXvsqHGvAVsGLXyOVOyR+JhI2MFap3Ter3ms1f6zWSFGIo6y5ls05w==", "bf7f5c1e-2641-46da-a8d4-016ed74568f1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b78019-fbe8-431d-9038-9cccd40b73aa", "AQAAAAEAACcQAAAAEGxsqgNrWR4xMeSWBB4UNXqmFqhX4G62269U7hGUvIDpojU8yr+Ia8EW9HV8MZ2Kyg==", "c6424914-491a-4c38-b8d3-cb521689201c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35bf789c-3b92-4a0d-af39-17bc9ea07e25", "AQAAAAEAACcQAAAAEImqPIZ7KcIGqfxPdrJr7VWWA8xp14wpKKIky7rl15vtGsV2LWdpFrxXoZMP+vapJg==", "a1225f20-a4a9-4f92-8d62-2d11252cc0fa" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inpatients_RoomGrades_RoomGradeId",
                table: "Inpatients",
                column: "RoomGradeId",
                principalTable: "RoomGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inpatients_RoomGrades_RoomGradeId",
                table: "Inpatients");

            migrationBuilder.AlterColumn<int>(
                name: "RoomGradeId",
                table: "Inpatients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "faa95a6b-5c3e-46d4-b265-364a5b361b8f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "989cb316-dbfa-4d9a-a7f2-9c104dc7cdf1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "55b3518b-715c-48f2-9870-2cbbe26e975e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "dae65000-7c65-4e5d-8a27-d59e87d8273b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "69a932c2-6c7a-4208-95f6-aad8fbaf265b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38d58f58-fbe7-400e-9c2c-b6b14fac1d3c", "AQAAAAEAACcQAAAAEF1/IZIw3ZtqhiabjXY0IBgrgVs/KaWzb+sLZUXpFkVjgOVeAfFc8PFsvOGi8UDQAg==", "e572cbdb-80bb-4269-a21d-043199cbe0f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24c51a31-326d-4a3d-ad30-fd85f06507bd", "AQAAAAEAACcQAAAAEEdavvXz1IfpJeSg354gyJX7UPj0zVSuHw4LO2IORYNSoZYlt4ot9aqKxv74id1ZIw==", "516ae177-3d42-4888-817e-6d0519272f92" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e6e7a6-dd96-4850-8d3d-75c63443812f", "AQAAAAEAACcQAAAAEN3tpuw68CMTYCg8xO1a4eLwoM0f8yuFbsxChZSFRpCrolh0S7ZGRSq43QD2FWIIrQ==", "5c94b16d-8f57-43bd-be79-24d16e7990bc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inpatients_RoomGrades_RoomGradeId",
                table: "Inpatients",
                column: "RoomGradeId",
                principalTable: "RoomGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
