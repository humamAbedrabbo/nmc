﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    public partial class Create_Main_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserTokens",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserLogins",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserClaims",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "RoleClaims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateTable(
                name: "AdmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DischargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'15', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    TelecomCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    LanguageId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    NationalityName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NationalityNameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Consultant = table.Column<bool>(type: "boolean", nullable: false),
                    Referrer = table.Column<bool>(type: "boolean", nullable: false),
                    Surgeon = table.Column<bool>(type: "boolean", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    WardId = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    WardId = table.Column<int>(type: "integer", nullable: true),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    RoomGradeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNo);
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
                    table.ForeignKey(
                        name: "FK_Rooms_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SortKey = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    TelecomCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    MaritalStatus = table.Column<int>(type: "integer", nullable: false),
                    Children = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    IdentityNo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NationalityId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    BloodType = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Occupation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WorkPhone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    EmergencyContact = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmergencyPhone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    EmergencyMobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    EmergencyAddress = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    SponsorContact = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SponsorPhone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    SponsorMobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    SponsorAddress = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    DownPayment = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpeciality",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "integer", nullable: false),
                    SpecialitiesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpeciality", x => new { x.DoctorsId, x.SpecialitiesId });
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Specialities_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
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
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
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
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
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
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
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
                    WardId = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Appointments_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inpatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: true),
                    ReferrerId = table.Column<int>(type: "integer", nullable: true),
                    WardId = table.Column<int>(type: "integer", nullable: false),
                    RoomNo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    RoomGradeId = table.Column<int>(type: "integer", nullable: false),
                    GradeLevelFactor = table.Column<int>(type: "integer", nullable: false),
                    Bed = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BarCodeGenerated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BarCodeUrl = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    FileNo = table.Column<string>(type: "text", nullable: true),
                    AdmissionTypeId = table.Column<int>(type: "integer", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AdmissionNote = table.Column<string>(type: "text", nullable: true),
                    PoliceRef = table.Column<string>(type: "text", nullable: true),
                    DischargeTypeId = table.Column<int>(type: "integer", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DischargeNote = table.Column<string>(type: "text", nullable: true),
                    Deceased = table.Column<bool>(type: "boolean", nullable: false),
                    DeceasedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeceaseNote = table.Column<string>(type: "text", nullable: true),
                    Companion = table.Column<string>(type: "text", nullable: true),
                    Meals = table.Column<string>(type: "text", nullable: true),
                    MedicalAllergies = table.Column<string>(type: "text", nullable: true),
                    MedicalAllergyNote = table.Column<string>(type: "text", nullable: true),
                    FoodAllergies = table.Column<string>(type: "text", nullable: true),
                    FoodAllergyNote = table.Column<string>(type: "text", nullable: true),
                    Diabeties = table.Column<string>(type: "text", nullable: true),
                    DiabetiesNotes = table.Column<string>(type: "text", nullable: true),
                    Diseases = table.Column<string>(type: "text", nullable: true),
                    DiseasesNotes = table.Column<string>(type: "text", nullable: true),
                    Medicines = table.Column<string>(type: "text", nullable: true),
                    MedicinesNotes = table.Column<string>(type: "text", nullable: true),
                    Smoking = table.Column<string>(type: "text", nullable: true),
                    Alcohol = table.Column<string>(type: "text", nullable: true),
                    MinDownPayment = table.Column<int>(type: "integer", nullable: false),
                    GLAccount = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inpatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inpatients_AdmissionTypes_AdmissionTypeId",
                        column: x => x.AdmissionTypeId,
                        principalTable: "AdmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_DischargeTypes_DischargeTypeId",
                        column: x => x.DischargeTypeId,
                        principalTable: "DischargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Doctors_ReferrerId",
                        column: x => x.ReferrerId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inpatients_RoomGrades_RoomGradeId",
                        column: x => x.RoomGradeId,
                        principalTable: "RoomGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inpatients_Rooms_RoomNo",
                        column: x => x.RoomNo,
                        principalTable: "Rooms",
                        principalColumn: "RoomNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inpatients_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InpatientId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Inpatients_InpatientId",
                        column: x => x.InpatientId,
                        principalTable: "Inpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InpatientStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InpatientId = table.Column<int>(type: "integer", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InpatientStatuses_Inpatients_InpatientId",
                        column: x => x.InpatientId,
                        principalTable: "Inpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    InpatientId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Inpatients_InpatientId",
                        column: x => x.InpatientId,
                        principalTable: "Inpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAllocations_Rooms_RoomNo",
                        column: x => x.RoomNo,
                        principalTable: "Rooms",
                        principalColumn: "RoomNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillId = table.Column<int>(type: "integer", nullable: false),
                    ItemCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                        name: "FK_Expenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillId = table.Column<int>(type: "integer", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "money", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdmissionTypes",
                columns: new[] { "Id", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { 1, "Normal", "عادي", 0 },
                    { 2, "Emergency", "إسعاف", 0 },
                    { 3, "Accident", "حادث", 0 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "Id", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { 7, "Other", "نوع آخر", 0 },
                    { 6, "Referrals", "إحالة", 0 },
                    { 5, "Radiology", "تصوير شعاعي", 0 },
                    { 1, "Routine checkup", "فحص روتيني", 0 },
                    { 2, "Consulting", "استشارة طبية", 0 },
                    { 3, "Vaccinations", "لقاح", 0 },
                    { 4, "Eye Care", "عينية", 0 }
                });

            migrationBuilder.InsertData(
                table: "DischargeTypes",
                columns: new[] { "Id", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { 4, "Death", "وفاة", 0 },
                    { 3, "Ill", "سوء", 0 },
                    { 2, "Improvement", "تحسن", 0 },
                    { 1, "Healing", "شفاء", 0 },
                    { 5, "Other", "أخرى", 0 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { "en", "Emglish", "انجليزي", 0 },
                    { "ar", "Arabic", "عربي", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 5, "69a932c2-6c7a-4208-95f6-aad8fbaf265b", "Doctor", "DOCTOR" },
                    { 4, "dae65000-7c65-4e5d-8a27-d59e87d8273b", "Accountant", "ACCOUNTANT" },
                    { 3, "55b3518b-715c-48f2-9870-2cbbe26e975e", "Receptionist", "RECEPTIONIST" },
                    { 2, "989cb316-dbfa-4d9a-a7f2-9c104dc7cdf1", "Admission Officer", "ADMISSION OFFICER" },
                    { 1, "faa95a6b-5c3e-46d4-b265-364a5b361b8f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RoomGrades",
                columns: new[] { "Id", "Capacity", "Level", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { 1, 1, 10, "Suite", "جناح", 0 },
                    { 2, 1, 9, "Excellent Class", "درجة ممتازة", 0 },
                    { 3, 1, 8, "First Class", "درجة أولى", 0 },
                    { 4, 2, 2, "Second Class", "درجة ثانية", 0 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name", "NameAr", "SortKey" },
                values: new object[] { 1, "Patient Room", "غرفة مريض", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38d58f58-fbe7-400e-9c2c-b6b14fac1d3c", "admin@nmc", "ADMIN@NMC", "AQAAAAEAACcQAAAAEF1/IZIw3ZtqhiabjXY0IBgrgVs/KaWzb+sLZUXpFkVjgOVeAfFc8PFsvOGi8UDQAg==", "e572cbdb-80bb-4269-a21d-043199cbe0f6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorId", "Email", "EmailConfirmed", "Language", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 3, 0, "d8e6e7a6-dd96-4850-8d3d-75c63443812f", null, "acc@nmc", false, null, false, null, "ACC@NMC", "ACC", "AQAAAAEAACcQAAAAEN3tpuw68CMTYCg8xO1a4eLwoM0f8yuFbsxChZSFRpCrolh0S7ZGRSq43QD2FWIIrQ==", null, false, "5c94b16d-8f57-43bd-be79-24d16e7990bc", false, "acc" },
                    { 2, 0, "24c51a31-326d-4a3d-ad30-fd85f06507bd", null, "adm@nmc", false, null, false, null, "ADM@NMC", "ADM", "AQAAAAEAACcQAAAAEEdavvXz1IfpJeSg354gyJX7UPj0zVSuHw4LO2IORYNSoZYlt4ot9aqKxv74id1ZIw==", null, false, "516ae177-3d42-4888-817e-6d0519272f92", false, "adm" }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "Floor", "Name", "NameAr", "SortKey" },
                values: new object[,]
                {
                    { 2, 2, "Internal Medicine", "قسم الداخلية الباطنية", 0 },
                    { 3, 3, "Intensive Care Unite (ICU)", "قسم العناية المشددة", 0 },
                    { 4, 4, "Obstetric & Genecology", "جناح النسائية والمخاض", 0 },
                    { 5, 5, "Dialysis", "قسم غسيل الكلى", 0 },
                    { 6, 6, "Arthroscopy", "قسم التنظير", 0 },
                    { 7, 6, "Cath Lab - Cardiovascular (CCU)", "قسم العناية القلبة والقثطرة القلبية", 0 },
                    { 8, 6, "Blood vessels", "قسم الأوعية", 0 },
                    { 9, -1, "Urology", "قسم البولية", 0 },
                    { 10, 0, "Respiratory System Diseases", "أمراض الجهاز التنفسي", 0 },
                    { 11, 4, "Emergency (ER)", "قسم الإسعاف والطوارئ", 0 },
                    { 12, -1, "Laboratory", "المخبر", 0 },
                    { 13, -1, "Radiography", "قسم التصوير الشعاعي", 0 },
                    { 14, -2, "Operation Rooms (OR)", "جناح العمليات", 0 },
                    { 1, 1, "Pediatric Department -  Incubators section (NICU)", "جناح الأطفال - قسم الحواضن", 0 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "LanguageId", "Name", "NameAr", "NationalityName", "NationalityNameAr", "SortKey", "TelecomCode" },
                values: new object[,]
                {
                    { "US", "en", "USA", "أمريكي", "American", "أمريكي", 0, "1" },
                    { "SY", "ar", "Syria", "سورية", "Syrian", "سوري", 0, "963" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNo", "Floor", "RoomGradeId", "RoomTypeId", "WardId" },
                values: new object[,]
                {
                    { "33", 3, 4, 1, 3 },
                    { "40", 4, 2, 1, 4 },
                    { "41", 4, 3, 1, 4 },
                    { "42", 4, 3, 1, 4 },
                    { "43", 4, 4, 1, 4 },
                    { "44", 4, 4, 1, 4 },
                    { "45", 4, 1, 1, 4 },
                    { "50", 5, 4, 1, 5 },
                    { "51", 5, 3, 1, 5 },
                    { "52", 5, 3, 1, 5 },
                    { "53", 5, 2, 1, 5 },
                    { "54", 5, 2, 1, 5 },
                    { "55", 5, 2, 1, 5 },
                    { "56", 5, 1, 1, 5 },
                    { "60", 6, 1, 1, 6 },
                    { "61", 6, 1, 1, 6 },
                    { "62", 6, 2, 1, 6 },
                    { "63", 6, 2, 1, 6 },
                    { "64", 6, 3, 1, 6 },
                    { "35", 3, 2, 1, 3 },
                    { "34", 3, 1, 1, 3 },
                    { "66", 6, 4, 1, 6 },
                    { "32", 3, 4, 1, 3 },
                    { "10", 1, 2, 1, 1 },
                    { "11", 1, 3, 1, 1 },
                    { "12", 1, 3, 1, 1 },
                    { "13", 1, 4, 1, 1 },
                    { "65", 6, 3, 1, 6 },
                    { "15", 1, 4, 1, 1 },
                    { "20", 2, 4, 1, 2 },
                    { "14", 1, 4, 1, 1 },
                    { "22", 2, 3, 1, 2 },
                    { "23", 2, 1, 1, 2 },
                    { "24", 2, 2, 1, 2 },
                    { "25", 2, 3, 1, 2 },
                    { "30", 3, 3, 1, 3 },
                    { "31", 3, 3, 1, 3 },
                    { "21", 2, 4, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 3, "Language", "en", 3, null },
                    { 2, "Language", "en", 2, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "NameAr", "SortKey", "TelecomCode" },
                values: new object[] { 1, "SY", "Damascus", "دمشق", 0, "11" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId1",
                table: "UserTokens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DoctorId",
                table: "Users",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId1",
                table: "UserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId1",
                table: "UserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId1",
                table: "RoleClaims",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionTypes_Name",
                table: "AdmissionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionTypes_NameAr",
                table: "AdmissionTypes",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDate",
                table: "Appointments",
                column: "AppointmentDate");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Phone",
                table: "Appointments",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WardId",
                table: "Appointments",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTypes_Name",
                table: "AppointmentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTypes_NameAr",
                table: "AppointmentTypes",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillNo",
                table: "Bills",
                column: "BillNo");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CreatedOn",
                table: "Bills",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DueDate",
                table: "Bills",
                column: "DueDate");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_InpatientId",
                table: "Bills",
                column: "InpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Status",
                table: "Bills",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorId",
                table: "Bookings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Name",
                table: "Bookings",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RequestDate",
                table: "Bookings",
                column: "RequestDate");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_NameAr",
                table: "Cities",
                column: "NameAr");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameAr",
                table: "Countries",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NationalityName",
                table: "Countries",
                column: "NationalityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NationalityNameAr",
                table: "Countries",
                column: "NationalityNameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DischargeTypes_Name",
                table: "DischargeTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DischargeTypes_NameAr",
                table: "DischargeTypes",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_FirstName",
                table: "Doctors",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LastName",
                table: "Doctors",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Mobile",
                table: "Doctors",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Phone",
                table: "Doctors",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WardId",
                table: "Doctors",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_SpecialitiesId",
                table: "DoctorSpeciality",
                column: "SpecialitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_DoctorId",
                table: "Educations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BillId",
                table: "Expenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ItemCode",
                table: "Expenses",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PurchaseDate",
                table: "Expenses",
                column: "PurchaseDate");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RoomNo",
                table: "Expenses",
                column: "RoomNo");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Status",
                table: "Expenses",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_DoctorId",
                table: "Experiences",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_Active",
                table: "Inpatients",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_AdmissionDate",
                table: "Inpatients",
                column: "AdmissionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_AdmissionTypeId",
                table: "Inpatients",
                column: "AdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_Bed",
                table: "Inpatients",
                column: "Bed");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_BookingId",
                table: "Inpatients",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_DischargeDate",
                table: "Inpatients",
                column: "DischargeDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_DischargeTypeId",
                table: "Inpatients",
                column: "DischargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_FileNo",
                table: "Inpatients",
                column: "FileNo");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_GLAccount",
                table: "Inpatients",
                column: "GLAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_PatientId",
                table: "Inpatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_PoliceRef",
                table: "Inpatients",
                column: "PoliceRef");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_ReferrerId",
                table: "Inpatients",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_RoomGradeId",
                table: "Inpatients",
                column: "RoomGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_RoomNo",
                table: "Inpatients",
                column: "RoomNo");

            migrationBuilder.CreateIndex(
                name: "IX_Inpatients_WardId",
                table: "Inpatients",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientStatuses_InpatientId",
                table: "InpatientStatuses",
                column: "InpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientStatuses_Name",
                table: "InpatientStatuses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientStatuses_StatusTime",
                table: "InpatientStatuses",
                column: "StatusTime");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_NameAr",
                table: "Languages",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FirstName",
                table: "Patients",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentityNo",
                table: "Patients",
                column: "IdentityNo");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LastName",
                table: "Patients",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Mobile",
                table: "Patients",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NationalityId",
                table: "Patients",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Phone",
                table: "Patients",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillId",
                table: "Payments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaidDate",
                table: "Payments",
                column: "PaidDate");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_BookingId",
                table: "RoomAllocations",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_Date",
                table: "RoomAllocations",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_InpatientId",
                table: "RoomAllocations",
                column: "InpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_PatientId",
                table: "RoomAllocations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_RoomNo",
                table: "RoomAllocations",
                column: "RoomNo");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_Status",
                table: "RoomAllocations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGrades_Name",
                table: "RoomGrades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomGrades_NameAr",
                table: "RoomGrades",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomGradeId",
                table: "Rooms",
                column: "RoomGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomNo",
                table: "Rooms",
                column: "RoomNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardId",
                table: "Rooms",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_Name",
                table: "RoomTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_NameAr",
                table: "RoomTypes",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FromDate",
                table: "Schedules",
                column: "FromDate");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ThruDate",
                table: "Schedules",
                column: "ThruDate");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_Name",
                table: "Specialities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_NameAr",
                table: "Specialities",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_Name",
                table: "Wards",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_NameAr",
                table: "Wards",
                column: "NameAr",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId1",
                table: "RoleClaims",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId1",
                table: "UserClaims",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId1",
                table: "UserLogins",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Doctors_DoctorId",
                table: "Users",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId1",
                table: "UserTokens",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId1",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId1",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId1",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Doctors_DoctorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId1",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "DoctorSpeciality");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "InpatientStatuses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoomAllocations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Inpatients");

            migrationBuilder.DropTable(
                name: "AdmissionTypes");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "DischargeTypes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "RoomGrades");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId1",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_Users_DoctorId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId1",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_UserId1",
                table: "UserClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_RoleId1",
                table: "RoleClaims");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "RoleClaims");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04ebd99a-8baf-444e-9ff0-faa08977c59d", "admin@localhost", "ADMIN@LOCALHOST", "AQAAAAEAACcQAAAAEEnEbErArHnDJbFuBNC4psA6NvW54pN5fKG0KAGX7xxW5FYt6LGrKLIi0tM7aYmyow==", "f47c6cae-dd6e-467d-b154-dd0c902716da" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }
    }
}