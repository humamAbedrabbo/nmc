﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NMC.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NMC.Migrations
{
    [DbContext(typeof(MedContext))]
    partial class MedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "203e1859-dce6-4160-b40b-47b08f1f1ae8",
                            RoleId = "Administration"
                        },
                        new
                        {
                            UserId = "c5125370-766e-4241-92e5-a500438d42d2",
                            RoleId = "Admission"
                        },
                        new
                        {
                            UserId = "50977287-d6f2-467f-8eb6-afac28ca526f",
                            RoleId = "Reception"
                        },
                        new
                        {
                            UserId = "cf987f03-fff1-44f6-b73f-076c1dd5c6cd",
                            RoleId = "Laboratory"
                        },
                        new
                        {
                            UserId = "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66",
                            RoleId = "Laboratory"
                        },
                        new
                        {
                            UserId = "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66",
                            RoleId = "Doctor"
                        },
                        new
                        {
                            UserId = "c612bf59-eb90-41f5-8896-045e2a9bec8c",
                            RoleId = "Management"
                        },
                        new
                        {
                            UserId = "6401f52a-d001-45d0-a7f1-0b7e6ee25114",
                            RoleId = "Management"
                        },
                        new
                        {
                            UserId = "6401f52a-d001-45d0-a7f1-0b7e6ee25114",
                            RoleId = "Doctor"
                        },
                        new
                        {
                            UserId = "cdef69ac-c872-48d7-81cd-ac450eb07ced",
                            RoleId = "Accounting"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("NMC.Models.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "Administration",
                            ConcurrencyStamp = "5f60c984-4f5e-4c87-a50d-641ff778cfcc",
                            Name = "Administration",
                            NormalizedName = "Administration"
                        },
                        new
                        {
                            Id = "Admission",
                            ConcurrencyStamp = "6788f53d-8cbe-42e9-89f1-7999b9b3380c",
                            Name = "Admission",
                            NormalizedName = "Admission"
                        },
                        new
                        {
                            Id = "Reception",
                            ConcurrencyStamp = "e8a46a12-d44c-498f-8c5c-234cc2b59fcc",
                            Name = "Reception",
                            NormalizedName = "Reception"
                        },
                        new
                        {
                            Id = "Accounting",
                            ConcurrencyStamp = "f7740252-2b8c-4f22-8eab-97f27dda59ff",
                            Name = "Accounting",
                            NormalizedName = "Accounting"
                        },
                        new
                        {
                            Id = "Doctor",
                            ConcurrencyStamp = "985f85f6-5df2-42c8-97e1-5c9288c69fb7",
                            Name = "Doctor",
                            NormalizedName = "Doctor"
                        },
                        new
                        {
                            Id = "Laboratory",
                            ConcurrencyStamp = "868b3660-a039-41e9-a681-4d34a7901f37",
                            Name = "Laboratory",
                            NormalizedName = "Laboratory"
                        },
                        new
                        {
                            Id = "Management",
                            ConcurrencyStamp = "6b26f929-801c-460c-83e3-665a64bd54ca",
                            Name = "Management",
                            NormalizedName = "Management"
                        });
                });

            modelBuilder.Entity("NMC.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName")
                        .HasName("AK_Username");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "203e1859-dce6-4160-b40b-47b08f1f1ae8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b5849cb0-a0d2-44a0-941a-085c605c03fc",
                            Email = "admin@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@HOSPITAL",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEH3K8uKYltHixEvKjXgtapTIGPwExhgqmylkKoxOXha0kHtasVJzF+1fn9dLq88W/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f82e8ec-6dc1-47ed-942b-0bb887a567c0",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "c5125370-766e-4241-92e5-a500438d42d2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "baadae77-d406-4cf1-8408-1923cc02a701",
                            Email = "admission@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMISSION@HOSPITAL",
                            NormalizedUserName = "ADMISSION",
                            PasswordHash = "AQAAAAEAACcQAAAAECeZIpUpcZMnxzO/h2M600ti7GHA/qSTEvZKzjiiLvwsC5PArrXXGxqTn73VkIwtJA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0ff18d5c-9d01-482a-ac3c-4ca720c1389e",
                            TwoFactorEnabled = false,
                            UserName = "admission"
                        },
                        new
                        {
                            Id = "50977287-d6f2-467f-8eb6-afac28ca526f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1d8044ba-a2e4-46f3-a7d5-a2b6a60bc22d",
                            Email = "reception@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "RECEPTION@HOSPITAL",
                            NormalizedUserName = "RECEPTION",
                            PasswordHash = "AQAAAAEAACcQAAAAEHCTlP7mmQLTGrPyF+jpBjxPw34JadfJA5zpLej2B5GNh2bIMu7zCUbS22lBYa8ltQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "05f31e90-bfdd-493d-b40d-8f0e63f60cee",
                            TwoFactorEnabled = false,
                            UserName = "reception"
                        },
                        new
                        {
                            Id = "cf987f03-fff1-44f6-b73f-076c1dd5c6cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d549bccb-1ebc-4fec-9f0d-9172158d93e1",
                            Email = "lab@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "LAB@HOSPITAL",
                            NormalizedUserName = "LAB",
                            PasswordHash = "AQAAAAEAACcQAAAAEE9/055CwnhOldo2qiAfdqfIQfVKcQYrw5/klleO9SHf8Y+2dz8rhwpvavYjENpNwQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3c15607c-a262-4aff-bab7-fd0f7512ecfc",
                            TwoFactorEnabled = false,
                            UserName = "lab"
                        },
                        new
                        {
                            Id = "6587bcbd-af7e-4ee1-868f-d5f57e0a7c66",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5663b3f7-26ed-468e-8729-c6718e20a728",
                            Email = "labdoctor@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "LABDOCTOR@HOSPITAL",
                            NormalizedUserName = "LABDOCTOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEPD7CwTEwu5YMIC/Ioweq27i4lswnEVYB7fRe8UHOsX4Eoqgndrx3Pkp0NpaB8ySQw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ae06d2ef-f2bc-4779-98a9-6e31f69898d4",
                            TwoFactorEnabled = false,
                            UserName = "labdoctor"
                        },
                        new
                        {
                            Id = "c612bf59-eb90-41f5-8896-045e2a9bec8c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b840ef6e-4576-4e47-8d3a-260374e0aeb9",
                            Email = "management@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGEMENT@HOSPITAL",
                            NormalizedUserName = "MANAGEMENT",
                            PasswordHash = "AQAAAAEAACcQAAAAEFIxqwnb5sKPrqa9lBywOJPxxopNR72Ey/GJmvU894gSaV4USIBnc/wfj/sm2riijw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c90568f3-71b2-4deb-9e47-2b697a59a313",
                            TwoFactorEnabled = false,
                            UserName = "management"
                        },
                        new
                        {
                            Id = "6401f52a-d001-45d0-a7f1-0b7e6ee25114",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9bcb1eed-c135-44f8-9121-40fd26301e79",
                            Email = "managerdoctor@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGERDOCTOR@HOSPITAL",
                            NormalizedUserName = "MANAGERDOCTOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEFl5iHRfbVDPIfKGHjLqT45P8rikqZCQnYptBOrZV1o7bjm6rOjZtg+pUI20bJIW6g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "98a80da8-b7c1-4e81-b28e-c224217f54bd",
                            TwoFactorEnabled = false,
                            UserName = "managerdoctor"
                        },
                        new
                        {
                            Id = "cdef69ac-c872-48d7-81cd-ac450eb07ced",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dc89c719-6f98-454b-8fba-5a8e95221074",
                            Email = "accountant@hospital",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ACCOUNTANT@HOSPITAL",
                            NormalizedUserName = "ACCOUNTANT",
                            PasswordHash = "AQAAAAEAACcQAAAAEBWIXlLIYik/FZaQJUdFUofD4+Basth5vqlOzbeGhfgwfDa4CPsXBzQRhIu3WrUF9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6740279b-7410-4183-a76f-8104241f0c9d",
                            TwoFactorEnabled = false,
                            UserName = "accountant"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("NMC.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NMC.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NMC.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("NMC.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NMC.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NMC.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
