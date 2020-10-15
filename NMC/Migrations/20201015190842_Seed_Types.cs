using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Migrations
{
    public partial class Seed_Types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdmissionTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Normal", "عادي" },
                    { 2, "Emergency", "إسعاف" },
                    { 3, "Accident", "حادث" }
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 6, "Referrals", "إحالة" },
                    { 5, "Radiology", "تصوير شعاعي" },
                    { 4, "Eye Care", "عينية" },
                    { 7, "Other", "نوع آخر" },
                    { 2, "Consulting", "استشارة طبية" },
                    { 1, "Routine checkup", "فحص روتيني" },
                    { 3, "Vaccinations", "لقاح" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 12, "Chest", "قسم الصدرية" },
                    { 20, "Surgery", "قسم العمليات" },
                    { 19, "Pharmacy", "الصيدلية" },
                    { 18, "Warehouse", "المستودع" },
                    { 16, "Lab", "المخبر" },
                    { 15, "Maintenance", "قسم الصيانة" },
                    { 14, "Emergency", "الطوارئ" },
                    { 13, "Kitchen", "المطبخ" },
                    { 11, "Urine", "قسم البولية" },
                    { 17, "Radiology", "الصور الشعاعية" },
                    { 9, "Cardiac and catheter", "قسم القلبية والقسطرة" },
                    { 10, "Blood vessels", "قسم الأوعية" },
                    { 2, "Accounting", "قسم المحاسبة" },
                    { 3, "Pediatrics and Baby incubator", "قسم طب الأطفال وال الحاضنات" },
                    { 4, "Internal", "قسم الداخلية" },
                    { 1, "Administration", "الادارة" },
                    { 6, "Women", "قسم النسائية" },
                    { 7, "Dialysis", "قسم غسيل الكلى" },
                    { 8, "Arthroscopy", "قسم التنظير" },
                    { 5, "Care", "قسم العناية" }
                });

            migrationBuilder.InsertData(
                table: "DischargeTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Healing", "شفاء" },
                    { 2, "Improvement", "تحسن" },
                    { 3, "Ill", "سوء" },
                    { 4, "Death", "وفاة" },
                    { 5, "Other", "أخرى" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 10, "Cleaner", "عامل تنظيف" },
                    { 7, "Administrator", "إداري" },
                    { 9, "Pharmacist", "صيدلي" },
                    { 8, "Maintenance", "صيانة" },
                    { 6, "Accountant", "محاسب" },
                    { 2, "Nurse", "ممرض" },
                    { 4, "Secretary", "سكرتيرة" },
                    { 3, "Laboratorist", "مخبري" },
                    { 1, "Doctor", "طبيب" },
                    { 5, "Receptionist", "موظف استقبال" }
                });

            migrationBuilder.InsertData(
                table: "RoomGrades",
                columns: new[] { "Id", "Description", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, null, "Suite", "جناح" },
                    { 2, null, "Excellent Class", "درجة ممتازة" },
                    { 3, null, "First Class", "درجة أولى" },
                    { 4, null, "Second Class", "درجة ثانية" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 3, "Care Room", "غرفة عناية" },
                    { 1, "Patient Room", "غرفة مريض" },
                    { 2, "Emergency Room", "غرفة طوارئ" },
                    { 4, "Baby Incubator Room", "غرفة حاضنات" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdmissionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdmissionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdmissionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DischargeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DischargeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DischargeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DischargeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DischargeTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomGrades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomGrades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomGrades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomGrades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
