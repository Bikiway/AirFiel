﻿// <auto-generated />
using System;
using AirFiel_Mariana_Oliveira.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230904134844_updateUserAgeandExperienceForEmpl")]
    partial class updateUserAgeandExperienceForEmpl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capacity1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HowManyClasses")
                        .HasColumnType("int");

                    b.Property<string>("ImagePlane")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("usersId");

                    b.ToTable("airplains");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Airport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirplaneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoPilot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Depart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FullPrice")
                        .HasColumnType("float");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pilot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FullPrice")
                        .HasColumnType("float");

                    b.Property<int?>("RoutesId")
                        .HasColumnType("int");

                    b.Property<int>("TravelQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("airplanesId")
                        .HasColumnType("int");

                    b.Property<int?>("citysId")
                        .HasColumnType("int");

                    b.Property<int?>("employeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutesId");

                    b.HasIndex("airplanesId");

                    b.HasIndex("citysId");

                    b.HasIndex("employeesId");

                    b.ToTable("RouteDetails");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetailsTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TravelQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("airplanesId")
                        .HasColumnType("int");

                    b.Property<int?>("citiesId")
                        .HasColumnType("int");

                    b.Property<int?>("employeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("airplanesId");

                    b.HasIndex("citiesId");

                    b.HasIndex("employeesId");

                    b.ToTable("RoutesDetailsTemps");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TicketLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Experience")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUserProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId");

                    b.Navigation("users");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Cities", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Employees", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetails", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Routes", null)
                        .WithMany("Items")
                        .HasForeignKey("RoutesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "airplanes")
                        .WithMany()
                        .HasForeignKey("airplanesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "citys")
                        .WithMany()
                        .HasForeignKey("citysId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "employees")
                        .WithMany()
                        .HasForeignKey("employeesId");

                    b.Navigation("airplanes");

                    b.Navigation("citys");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetailsTemp", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "airplanes")
                        .WithMany()
                        .HasForeignKey("airplanesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "cities")
                        .WithMany()
                        .HasForeignKey("citiesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "employees")
                        .WithMany()
                        .HasForeignKey("employeesId");

                    b.Navigation("airplanes");

                    b.Navigation("cities");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Routes", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
