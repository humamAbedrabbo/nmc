using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations.Postgres
{
    public partial class Update_Departments_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Financial and Accounting Department ", "الإدارة المالية و قسم المحاسبة" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Pediatric Department -  Incubators section (NICU)", "جناح الأطفال - قسم الحواضن" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Internal Medicine", "قسم الداخلية الباطنية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Intensive Care Unite (ICU)", "قسم العناية المشددة" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Obstetric & Genecology", "جناح النسائية والمخاض" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Cath Lab - Cardiovascular (CCU)", "قسم العناية القلبة والقثطرة القلبية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Urology");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Respiratory System Diseases", "أمراض الجهاز التنفسي" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Catering section", "قسم الإطعام" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Emergency (ER)", "قسم الإسعاف والطوارئ" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Maintenance Department");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Laboratory");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Radiography", "قسم التصوير الشعاعي" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Medical warehouse", "المستودع الطبي" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Operation Rooms (OR)", "جناح العمليات" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d72dd19-bacd-497e-b401-321eb6d40ee6", "AQAAAAEAACcQAAAAEJWkaf1vWa+4ojgF8o1E5DxswUKnk8NR7hsBnYk1kkriBBY4iJ3lQQ9+ZsPR77ptPA==", "e6dac8f9-5a06-469c-96d7-de4ac6acbd81" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Accounting", "قسم المحاسبة" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Pediatrics and Baby incubator", "قسم طب الأطفال وال الحاضنات" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Internal", "قسم الداخلية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Care", "قسم العناية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Women", "قسم النسائية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Cardiac and catheter", "قسم القلبية والقسطرة" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Urine");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Chest", "قسم الصدرية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Kitchen", "المطبخ" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Emergency", "الطوارئ" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Lab");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Radiology", "الصور الشعاعية" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Warehouse", "المستودع" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "NameAr" },
                values: new object[] { "Surgery", "قسم العمليات" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1985a683-094b-465e-be38-7edc7894f692", "AQAAAAEAACcQAAAAEDYgxQhsrR5biifnliABb6QlpSjyicsuT/1O4bWnXNTD+Rfjr5VpspANZtvFR7bJqg==", "996bee0b-bfe8-4532-a4d2-5ffa365bd57e" });
        }
    }
}
