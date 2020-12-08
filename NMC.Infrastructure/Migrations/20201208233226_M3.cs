using Microsoft.EntityFrameworkCore.Migrations;

namespace NMC.Infrastructure.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SBMenuItems",
                columns: new[] { "Id", "Enabled", "HRef", "Icon", "ParentId", "SortKey", "Text", "Visible" },
                values: new object[,]
                {
                    { 1, true, "/Index", "fa fa-dashboard", null, 1, "Dashboard", true },
                    { 27, true, "#", "fa fa-cog", null, 27, "Settings", true },
                    { 26, true, "#", "", 26, 25, "Report 2", true },
                    { 24, true, "#", "fa fa-flag-o", null, 24, "Reports", true },
                    { 17, true, "#", "fa fa-cogs", null, 17, "Types", true },
                    { 13, true, "#", "fa fa-money", null, 13, "Accounts", true },
                    { 10, true, "#", "fa fa-user", null, 10, "Employees", true },
                    { 9, true, "/UI1/Admissions/Index", "fa fa-bed", null, 9, "Admissions", true },
                    { 7, true, "/UI1/Rooms/Index", "fa fa-cube", null, 7, "Rooms", true },
                    { 6, true, "/UI1/Departments/Index", "fa fa-calendar-check-o", null, 6, "Departments", true },
                    { 5, true, "/UI1/Doctors/DoctorScheduleIndex", "fa fa-calendar-check-o", null, 5, "Doctor Schedules", true },
                    { 4, true, "/UI1/Appointments/Index", "fa fa-calendar", null, 4, "Appointments", true },
                    { 3, true, "/UI1/Patients/Index", "fa fa-wheelchair", null, 3, "Patients", true },
                    { 2, true, "/UI1/Doctors/Index", "fa fa-user-md", null, 2, "Doctors", true },
                    { 8, true, "/UI1/Reservations/Index", "fa fa-envelope-o", null, 8, "Reservations", true }
                });

            migrationBuilder.InsertData(
                table: "SBMenuSections",
                columns: new[] { "Id", "Role", "SortKey", "Text" },
                values: new object[] { 1, "Admin", 1, "Main" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddff63de-15c3-478b-87cb-0cbb39c9a6fc", "AQAAAAEAACcQAAAAELAB+T46yPqsflpdfdiInj6yTdMvwB3SDEV6B3uN5aMBTVw5YvjIx6m6cg7l3sgc2Q==", "f9bac2d4-b9f0-479b-8b53-3675eb5ff40b" });

            migrationBuilder.InsertData(
                table: "SBMenuItems",
                columns: new[] { "Id", "Enabled", "HRef", "Icon", "ParentId", "SortKey", "Text", "Visible" },
                values: new object[,]
                {
                    { 11, true, "/UI1/Employees/Index", "", 10, 11, "Employee List", true },
                    { 25, true, "#", "", 24, 25, "Report 1", true },
                    { 23, true, "/UI1/EmployeeTypes/Index", "", 17, 23, "Employee Types", true },
                    { 22, true, "/UI1/DischargeTypes/Index", "", 17, 22, "Discharge Types", true },
                    { 20, true, "/UI1/AppointmentTypes/Index", "", 17, 20, "Appointment Types", true },
                    { 19, true, "/UI1/RoomGrades/Index", "", 17, 19, "Room Grades", true },
                    { 21, true, "/UI1/AdmissionTypes/Index", "", 17, 21, "Admission Types", true },
                    { 16, true, "#", "", 13, 16, "Expenses", true },
                    { 15, true, "#", "", 13, 15, "Payments", true },
                    { 14, true, "#", "", 13, 14, "Invoices", true },
                    { 12, true, "#", "", 10, 12, "Attendance", true },
                    { 18, true, "/UI1/RoomTypes/Index", "", 17, 18, "Room Types", true }
                });

            migrationBuilder.InsertData(
                table: "SBMenuSectionItems",
                columns: new[] { "Id", "MenuItemId", "SectionId", "SortKey" },
                values: new object[,]
                {
                    { 8, 8, 1, 8 },
                    { 12, 17, 1, 12 },
                    { 11, 13, 1, 11 },
                    { 10, 10, 1, 10 },
                    { 9, 9, 1, 9 },
                    { 7, 7, 1, 7 },
                    { 1, 1, 1, 1 },
                    { 5, 5, 1, 5 },
                    { 4, 4, 1, 4 },
                    { 3, 3, 1, 3 },
                    { 2, 2, 1, 2 },
                    { 13, 24, 1, 13 },
                    { 6, 6, 1, 6 },
                    { 14, 27, 1, 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SBMenuSectionItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SBMenuItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SBMenuSections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f93cc88-d6fd-4009-a10a-01087a45c35e", "AQAAAAEAACcQAAAAENa6TUUNKWerFzUZqxjOXN2WEMHAG8cIcXJGh6oe+KkmQAQDJ+Y6BcDq/YAovd2I/A==", "ac71cda4-16f5-4a44-8f7c-652d7cb8275b" });
        }
    }
}
