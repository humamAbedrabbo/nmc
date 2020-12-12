using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Infrastructure.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    DepartmentType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DischargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Speciality = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Consultant = table.Column<bool>(type: "boolean", nullable: false),
                    Surgeon = table.Column<bool>(type: "boolean", nullable: false),
                    Referrer = table.Column<bool>(type: "boolean", nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Module = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ReceiveNotification = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Unread = table.Column<bool>(type: "boolean", nullable: false),
                    Module = table.Column<int>(type: "integer", nullable: false),
                    RelatedId = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    FatherName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    MotherName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Married = table.Column<bool>(type: "boolean", nullable: false),
                    Children = table.Column<int>(type: "integer", nullable: true),
                    NationalID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PassportID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExternalID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Occupation = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    WorkPhone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SBMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    HRef = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SBMenuItems_SBMenuItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SBMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SBMenuSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: true),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBMenuSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "DepartmentDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentDoctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Institution = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Degree = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Grade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StartingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorExperiences_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ThruDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Days = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EndTime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    EmployeeNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PhotoPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Unread = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentTypeId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StartTime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EndTime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Visitor = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    FloorNo = table.Column<int>(type: "integer", nullable: false),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    RoomGradeId = table.Column<int>(type: "integer", nullable: true),
                    WardId = table.Column<int>(type: "integer", nullable: true),
                    BedCount = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.UniqueConstraint("AK_Rooms_RoomNo", x => x.RoomNo);
                    table.ForeignKey(
                        name: "FK_Rooms_Departments_WardId",
                        column: x => x.WardId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomGrades_RoomGradeId",
                        column: x => x.RoomGradeId,
                        principalTable: "RoomGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SBMenuSectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: true),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBMenuSectionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SBMenuSectionItems_SBMenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "SBMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBMenuSectionItems_SBMenuSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SBMenuSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
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
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AttendanceSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceSheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentRooms_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    GradeId = table.Column<int>(type: "integer", nullable: true),
                    BedNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ReservedBeds = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StartTime = table.Column<string>(type: "text", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<string>(type: "text", nullable: true),
                    Requestor = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_RoomGrades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "RoomGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomNo",
                        column: x => x.RoomNo,
                        principalTable: "Rooms",
                        principalColumn: "RoomNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AdmissionTypeId = table.Column<int>(type: "integer", nullable: false),
                    FileNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PoliceCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ReferrerDoctorId = table.Column<int>(type: "integer", nullable: true),
                    ReferralLetter = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ReservationId = table.Column<int>(type: "integer", nullable: true),
                    Meals = table.Column<string>(type: "text", nullable: true),
                    Companion = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalAllergy = table.Column<string>(type: "text", nullable: true),
                    FoodAllergy = table.Column<string>(type: "text", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdmissionTime = table.Column<string>(type: "text", nullable: true),
                    DischargeTypeId = table.Column<int>(type: "integer", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DischargeTime = table.Column<string>(type: "text", nullable: true),
                    ActiveThru = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_AdmissionTypes_AdmissionTypeId",
                        column: x => x.AdmissionTypeId,
                        principalTable: "AdmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_DischargeTypes_DischargeTypeId",
                        column: x => x.DischargeTypeId,
                        principalTable: "DischargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admissions_Doctors_ReferrerDoctorId",
                        column: x => x.ReferrerDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReservationId = table.Column<int>(type: "integer", nullable: true),
                    AdmissionId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PurchaseFrom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PurchasedBy = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    RoomNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "money", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 2, "Consulting", "استشارة طبية" },
                    { 7, "Other", "نوع آخر" },
                    { 1, "Routine checkup", "فحص روتيني" },
                    { 6, "Referrals", "إحالة" },
                    { 3, "Vaccinations", "لقاح" },
                    { 4, "Eye Care", "عينية" },
                    { 5, "Radiology", "تصوير شعاعي" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Name", "NameAr" },
                values: new object[,]
                {
                    { 9, 2, "Cath Lab - Cardiovascular (CCU)", "قسم العناية القلبة والقثطرة القلبية" },
                    { 10, 1, "Blood vessels", "قسم الأوعية" },
                    { 11, 1, "Urology", "قسم البولية" },
                    { 12, 1, "Respiratory System Diseases", "أمراض الجهاز التنفسي" },
                    { 7, 1, "Dialysis", "قسم غسيل الكلى" },
                    { 13, 0, "Catering section", "قسم الإطعام" },
                    { 14, 1, "Emergency (ER)", "قسم الإسعاف والطوارئ" },
                    { 15, 0, "Maintenance Department", "قسم الصيانة" },
                    { 16, 2, "Laboratory", "المخبر" },
                    { 17, 2, "Radiography", "قسم التصوير الشعاعي" },
                    { 8, 1, "Arthroscopy", "قسم التنظير" },
                    { 20, 1, "Operation Rooms (OR)", "جناح العمليات" },
                    { 2, 0, "Financial and Accounting Department ", "الإدارة المالية و قسم المحاسبة" },
                    { 5, 1, "Intensive Care Unite (ICU)", "قسم العناية المشددة" },
                    { 4, 1, "Internal Medicine", "قسم الداخلية الباطنية" },
                    { 3, 1, "Pediatric Department -  Incubators section (NICU)", "جناح الأطفال - قسم الحواضن" },
                    { 18, 0, "Medical warehouse", "المستودع الطبي" },
                    { 1, 0, "Administration", "الادارة" },
                    { 6, 1, "Obstetric & Genecology", "جناح النسائية والمخاض" },
                    { 19, 0, "Pharmacy", "الصيدلية" }
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
                table: "Doctors",
                columns: new[] { "Id", "Active", "Address", "Biography", "Consultant", "Email", "FirstName", "Gender", "JoiningDate", "LastName", "Mobile", "Phone", "PhotoPath", "Referrer", "Speciality", "Surgeon", "Username" },
                values: new object[] { 1, true, "Planet Earth", "Greate personality", true, "an.example@localhost", "An", 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Example", "+963-993-555555", "+963-11-5555555", "user.jpg", true, "Cancer", false, "doctor" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 6, "Accountant", "محاسب" },
                    { 7, "Administrator", "إداري" },
                    { 8, "Maintenance", "صيانة" },
                    { 9, "Pharmacist", "صيدلي" },
                    { 10, "Cleaner", "عامل تنظيف" },
                    { 5, "Receptionist", "موظف استقبال" },
                    { 1, "Doctor", "طبيب" },
                    { 2, "Nurse", "ممرض" },
                    { 3, "Laboratorist", "مخبري" },
                    { 4, "Secretary", "سكرتيرة" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "b32ca899-c8ec-4486-be19-3790950daae3", "Admin", "ADMIN" },
                    { 3, "27ad3d0f-2e7a-4e2a-b94c-725fa9b78983", "Doctor", "DOCTOR" },
                    { 2, "2f71f003-c54e-4d33-bb47-bc0fbfed2c17", "Admission", "ADMISSION" }
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
                    { 1, "Patient Room", "غرفة مريض" },
                    { 2, "Emergency Room", "غرفة طوارئ" },
                    { 3, "Care Room", "غرفة عناية" },
                    { 4, "Baby Incubator Room", "غرفة حاضنات" }
                });

            migrationBuilder.InsertData(
                table: "SBMenuItems",
                columns: new[] { "Id", "Enabled", "HRef", "Icon", "ParentId", "SortKey", "Text", "Visible" },
                values: new object[,]
                {
                    { 10, true, "#", "fa fa-user", null, 10, "Employees", true },
                    { 13, true, "#", "fa fa-money", null, 13, "Accounts", true },
                    { 17, true, "#", "fa fa-cogs", null, 17, "Types", true },
                    { 24, true, "#", "fa fa-flag-o", null, 24, "Reports", true },
                    { 5, true, "/UI1/Doctors/DoctorScheduleIndex", "fa fa-calendar-check-o", null, 5, "Doctor Schedules", true },
                    { 9, true, "/UI1/Admissions/Index", "fa fa-bed", null, 9, "Admissions", true },
                    { 27, true, "#", "fa fa-cog", null, 27, "Settings", true },
                    { 28, true, "/UI1/Admissions/Index", "fa fa-bed", null, 28, "Inpatients", true },
                    { 26, true, "#", "", 26, 25, "Report 2", true },
                    { 8, true, "/UI1/Reservations/Index", "fa fa-envelope-o", null, 8, "Reservations", true },
                    { 3, true, "/UI1/Patients/Index", "fa fa-wheelchair", null, 3, "Patients", true },
                    { 6, true, "/UI1/Departments/Index", "fa fa-calendar-check-o", null, 6, "Departments", true },
                    { 31, true, "/UI1/Admissions/Index", "fa fa-bed", null, 31, "Inpatients", true },
                    { 4, true, "/UI1/Appointments/Index", "fa fa-calendar", null, 4, "Appointments", true },
                    { 29, true, "/UI1/Reservations/Index", "fa fa-envelope-o", null, 29, "Bookings", true },
                    { 2, true, "/UI1/Doctors/Index", "fa fa-user-md", null, 2, "Doctors", true },
                    { 1, true, "/Index", "fa fa-dashboard", null, 1, "Dashboard", true },
                    { 32, true, "/UI1/Reservations/Index", "fa fa-envelope-o", null, 32, "Bookings", true },
                    { 7, true, "/UI1/Rooms/Index", "fa fa-cube", null, 7, "Rooms", true },
                    { 30, true, "/UI1/Doctors/Index", "fa fa-user-md", null, 30, "Doctors", true }
                });

            migrationBuilder.InsertData(
                table: "SBMenuSections",
                columns: new[] { "Id", "Role", "SortKey", "Text" },
                values: new object[,]
                {
                    { 1, "Admin", 1, "Main" },
                    { 3, "Doctor", 3, "Doctor" },
                    { 2, "Admission", 2, "Admission" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5bfc777d-ba3f-48ae-8026-88fb1e9514f8", "admin@localhost", false, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAEAACcQAAAAEDcZYFwaC4WnGxmBeDj6cgjh8b3DLrsguj69pFeMjPsXDK1F2U0aGbEvVEz2ZRiKsg==", null, false, "38c10d8b-7b56-48c1-a6d3-bb7fbadaf71b", false, "admin" },
                    { 2, 0, "8372423d-b131-4386-bf88-766f5b2ab540", "admission@localhost", false, false, null, "ADMISSION@LOCALHOST", "ADMISSION", "AQAAAAEAACcQAAAAEJHwQp5wfAAR4TN8o43RsOwRc816duN/01z5i5+r9xAJTKDskCpEq/qS/7hFSAsbJQ==", null, false, "2f5e2402-1359-4e69-b4ba-15ea6cc45e64", false, "admission" },
                    { 3, 0, "683a5a13-3aba-4ef5-8211-17a83edc3817", "doctor@localhost", false, false, null, "DOCTOR@LOCALHOST", "DOCTOR", "AQAAAAEAACcQAAAAEPBL1wJvzXvcHc7HZcYYwxdrMgVm/hN2bj9tB0J5BVZZYi9ADxgBLhPx2rH737SMMw==", null, false, "eefc6915-dcaf-4119-874b-fa9b401bc455", false, "doctor" }
                });

            migrationBuilder.InsertData(
                table: "DoctorEducations",
                columns: new[] { "Id", "CompleteDate", "Degree", "DoctorId", "Grade", "Institution", "StartingDate", "Subject" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Degree 1", 1, "A", "University 1", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancer" },
                    { 2, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Degree 2", 1, "A", "University 2", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancer2" }
                });

            migrationBuilder.InsertData(
                table: "DoctorExperiences",
                columns: new[] { "Id", "Company", "DoctorId", "Location", "PeriodFrom", "PeriodTo", "Position" },
                values: new object[,]
                {
                    { 3, "NMC", 1, "SYRIA", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doctor" },
                    { 1, "Company 1", 1, "UK", new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor" },
                    { 2, "Company 2", 1, "UK", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedCount", "FloorNo", "RoomGradeId", "RoomNo", "RoomTypeId", "WardId" },
                values: new object[,]
                {
                    { 13, false, 1, 2, 1, "24", 1, 4 },
                    { 14, false, 1, 2, 2, "25", 1, 4 },
                    { 15, false, 1, 2, 1, "26", 1, 4 },
                    { 16, false, 1, 2, 1, "27", 1, 4 },
                    { 18, false, 1, 2, 1, "29", 1, 4 },
                    { 19, false, 1, 3, 1, "31", 1, 5 },
                    { 20, false, 1, 3, 3, "32", 1, 5 },
                    { 24, false, 1, 3, 3, "36", 1, 5 },
                    { 12, false, 1, 2, 1, "23", 1, 4 },
                    { 22, false, 1, 3, 1, "34", 1, 5 },
                    { 23, false, 1, 3, 1, "35", 1, 5 },
                    { 25, false, 1, 3, 1, "37", 1, 5 },
                    { 26, false, 1, 3, 1, "38", 1, 5 },
                    { 27, false, 1, 3, 2, "39", 1, 5 },
                    { 21, false, 1, 3, 1, "33", 1, 5 },
                    { 11, false, 1, 2, 2, "22", 1, 4 },
                    { 17, false, 1, 2, 1, "28", 1, 4 },
                    { 9, false, 1, 1, 1, "19", 1, 3 },
                    { 10, false, 1, 2, 1, "21", 1, 4 },
                    { 2, false, 1, 1, 1, "12", 1, 3 },
                    { 3, false, 1, 1, 2, "13", 1, 3 },
                    { 4, false, 1, 1, 1, "14", 1, 3 },
                    { 1, false, 1, 1, 1, "11", 1, 3 },
                    { 5, false, 1, 1, 2, "15", 1, 3 },
                    { 6, false, 1, 1, 1, "16", 1, 3 },
                    { 7, false, 1, 1, 1, "17", 1, 3 },
                    { 8, false, 1, 1, 1, "18", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "SBMenuItems",
                columns: new[] { "Id", "Enabled", "HRef", "Icon", "ParentId", "SortKey", "Text", "Visible" },
                values: new object[,]
                {
                    { 16, true, "#", "", 13, 16, "Expenses", true },
                    { 23, true, "/UI1/EmployeeTypes/Index", "", 17, 23, "Employee Types", true },
                    { 22, true, "/UI1/DischargeTypes/Index", "", 17, 22, "Discharge Types", true },
                    { 21, true, "/UI1/AdmissionTypes/Index", "", 17, 21, "Admission Types", true },
                    { 20, true, "/UI1/AppointmentTypes/Index", "", 17, 20, "Appointment Types", true },
                    { 19, true, "/UI1/RoomGrades/Index", "", 17, 19, "Room Grades", true },
                    { 18, true, "/UI1/RoomTypes/Index", "", 17, 18, "Room Types", true },
                    { 25, true, "#", "", 24, 25, "Report 1", true },
                    { 15, true, "#", "", 13, 15, "Payments", true },
                    { 11, true, "/UI1/Employees/Index", "", 10, 11, "Employee List", true },
                    { 12, true, "#", "", 10, 12, "Attendance", true },
                    { 14, true, "#", "", 13, 14, "Invoices", true }
                });

            migrationBuilder.InsertData(
                table: "SBMenuSectionItems",
                columns: new[] { "Id", "MenuItemId", "SectionId", "SortKey" },
                values: new object[,]
                {
                    { 17, 30, 2, 17 },
                    { 16, 29, 2, 16 },
                    { 15, 28, 2, 15 },
                    { 12, 17, 1, 12 },
                    { 14, 27, 1, 14 },
                    { 13, 24, 1, 13 },
                    { 8, 8, 1, 8 },
                    { 11, 13, 1, 11 },
                    { 10, 10, 1, 10 },
                    { 9, 9, 1, 9 },
                    { 7, 7, 1, 7 },
                    { 34, 32, 3, 34 },
                    { 5, 5, 1, 5 },
                    { 4, 4, 1, 4 },
                    { 3, 3, 1, 3 },
                    { 2, 2, 1, 2 },
                    { 1, 1, 1, 1 },
                    { 33, 31, 3, 33 },
                    { 6, 6, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 3, "Language", "en", 3 },
                    { 2, "Language", "en", 2 },
                    { 1, "Language", "en", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AdmissionTypeId",
                table: "Admissions",
                column: "AdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DepartmentId",
                table: "Admissions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DischargeTypeId",
                table: "Admissions",
                column: "DischargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_ReferrerDoctorId",
                table: "Admissions",
                column: "ReferrerDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_ReservationId",
                table: "Admissions",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DepartmentId",
                table: "Appointments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSheets_EmployeeId",
                table: "AttendanceSheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDoctors_DepartmentId",
                table: "DepartmentDoctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDoctors_DoctorId",
                table: "DepartmentDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRooms_DepartmentId",
                table: "DepartmentRooms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRooms_RoomId",
                table: "DepartmentRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducations_DoctorId",
                table: "DoctorEducations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorExperiences_DoctorId",
                table: "DoctorExperiences",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_InvoiceId",
                table: "Expenses",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AdmissionId",
                table: "Invoices",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GradeId",
                table: "Reservations",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomNo",
                table: "Reservations",
                column: "RoomNo");

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
                name: "IX_Rooms_RoomGradeId",
                table: "Rooms",
                column: "RoomGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardId",
                table: "Rooms",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_SBMenuItems_ParentId",
                table: "SBMenuItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SBMenuSectionItems_MenuItemId",
                table: "SBMenuSectionItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SBMenuSectionItems_SectionId",
                table: "SBMenuSectionItems",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

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
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AttendanceSheets");

            migrationBuilder.DropTable(
                name: "DepartmentDoctors");

            migrationBuilder.DropTable(
                name: "DepartmentRooms");

            migrationBuilder.DropTable(
                name: "DoctorEducations");

            migrationBuilder.DropTable(
                name: "DoctorExperiences");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ModuleUsers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SBMenuSectionItems");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "SBMenuItems");

            migrationBuilder.DropTable(
                name: "SBMenuSections");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "AdmissionTypes");

            migrationBuilder.DropTable(
                name: "DischargeTypes");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "RoomGrades");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
