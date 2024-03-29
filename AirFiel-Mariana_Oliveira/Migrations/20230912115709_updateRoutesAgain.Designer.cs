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
    [Migration("20230912115709_updateRoutesAgain")]
    partial class updateRoutesAgain
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

                    b.Property<int>("Capacity1")
                        .HasColumnType("int");

                    b.Property<int>("Capacity2")
                        .HasColumnType("int");

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

                    b.ToTable("airplanes");
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

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
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

                    b.Property<int?>("AirplaneNameId")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity2Id")
                        .HasColumnType("int");

                    b.Property<int?>("CoPilotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Depart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<double>("Discounts")
                        .HasColumnType("float");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<int?>("PilotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.Property<string>("usersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneNameId");

                    b.HasIndex("Capacity1Id");

                    b.HasIndex("Capacity2Id");

                    b.HasIndex("CoPilotId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.HasIndex("PilotId");

                    b.HasIndex("usersId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Depart")
                        .HasColumnType("datetime2");

                    b.Property<int>("FullPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoutesId")
                        .HasColumnType("int");

                    b.Property<int>("TravelsPerMonth")
                        .HasColumnType("int");

                    b.Property<int?>("airplanesId")
                        .HasColumnType("int");

                    b.Property<int?>("capacity1Id")
                        .HasColumnType("int");

                    b.Property<int?>("capacity2Id")
                        .HasColumnType("int");

                    b.Property<int?>("coPilotEmployeesId")
                        .HasColumnType("int");

                    b.Property<int?>("destinationCitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("originCitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("pilotEmployeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutesId");

                    b.HasIndex("airplanesId");

                    b.HasIndex("capacity1Id");

                    b.HasIndex("capacity2Id");

                    b.HasIndex("coPilotEmployeesId");

                    b.HasIndex("destinationCitiesId");

                    b.HasIndex("originCitiesId");

                    b.HasIndex("pilotEmployeesId");

                    b.ToTable("RouteDetails");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetailsTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Depart")
                        .HasColumnType("datetime2");

                    b.Property<double>("FullPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.Property<int>("TravelsPerMonth")
                        .HasColumnType("int");

                    b.Property<int?>("airplanesId")
                        .HasColumnType("int");

                    b.Property<int?>("capacity1Id")
                        .HasColumnType("int");

                    b.Property<int?>("capacity2Id")
                        .HasColumnType("int");

                    b.Property<int?>("coPilotEmployeesId")
                        .HasColumnType("int");

                    b.Property<int?>("destinationCitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("originCitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("pilotEmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("airplanesId");

                    b.HasIndex("capacity1Id");

                    b.HasIndex("capacity2Id");

                    b.HasIndex("coPilotEmployeesId");

                    b.HasIndex("destinationCitiesId");

                    b.HasIndex("originCitiesId");

                    b.HasIndex("pilotEmployeesId");

                    b.HasIndex("userId");

                    b.ToTable("RoutesDetailsTemps");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowManyPassengers")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("routesId")
                        .HasColumnType("int");

                    b.Property<string>("usersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("routesId");

                    b.HasIndex("usersId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.TicketsDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerTicket")
                        .HasColumnType("float");

                    b.Property<int>("QuantityOfPassengers")
                        .HasColumnType("int");

                    b.Property<int?>("TicketsId")
                        .HasColumnType("int");

                    b.Property<int?>("routesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketsId");

                    b.HasIndex("routesId");

                    b.ToTable("TicketDetails");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.TicketsDetailsTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IdaEVolta")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Passengers")
                        .HasColumnType("int");

                    b.Property<double>("PricePerTicket")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("routesIdId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("routesIdId");

                    b.HasIndex("userId");

                    b.ToTable("TicketDetailsTemps");
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

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Routes", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "AirplaneName")
                        .WithMany()
                        .HasForeignKey("AirplaneNameId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "Capacity1")
                        .WithMany()
                        .HasForeignKey("Capacity1Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "Capacity2")
                        .WithMany()
                        .HasForeignKey("Capacity2Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "CoPilot")
                        .WithMany()
                        .HasForeignKey("CoPilotId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId");

                    b.Navigation("AirplaneName");

                    b.Navigation("Capacity1");

                    b.Navigation("Capacity2");

                    b.Navigation("CoPilot");

                    b.Navigation("Destination");

                    b.Navigation("Origin");

                    b.Navigation("Pilot");

                    b.Navigation("users");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetails", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Routes", null)
                        .WithMany("Items")
                        .HasForeignKey("RoutesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "airplanes")
                        .WithMany()
                        .HasForeignKey("airplanesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "capacity1")
                        .WithMany()
                        .HasForeignKey("capacity1Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "capacity2")
                        .WithMany()
                        .HasForeignKey("capacity2Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "coPilotEmployees")
                        .WithMany()
                        .HasForeignKey("coPilotEmployeesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "destinationCities")
                        .WithMany()
                        .HasForeignKey("destinationCitiesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "originCities")
                        .WithMany()
                        .HasForeignKey("originCitiesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "pilotEmployees")
                        .WithMany()
                        .HasForeignKey("pilotEmployeesId");

                    b.Navigation("airplanes");

                    b.Navigation("capacity1");

                    b.Navigation("capacity2");

                    b.Navigation("coPilotEmployees");

                    b.Navigation("destinationCities");

                    b.Navigation("originCities");

                    b.Navigation("pilotEmployees");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.RoutesDetailsTemp", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "airplanes")
                        .WithMany()
                        .HasForeignKey("airplanesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "capacity1")
                        .WithMany()
                        .HasForeignKey("capacity1Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Airplanes", "capacity2")
                        .WithMany()
                        .HasForeignKey("capacity2Id");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "coPilotEmployees")
                        .WithMany()
                        .HasForeignKey("coPilotEmployeesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "destinationCities")
                        .WithMany()
                        .HasForeignKey("destinationCitiesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Cities", "originCities")
                        .WithMany()
                        .HasForeignKey("originCitiesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Employees", "pilotEmployees")
                        .WithMany()
                        .HasForeignKey("pilotEmployeesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("airplanes");

                    b.Navigation("capacity1");

                    b.Navigation("capacity2");

                    b.Navigation("coPilotEmployees");

                    b.Navigation("destinationCities");

                    b.Navigation("originCities");

                    b.Navigation("pilotEmployees");

                    b.Navigation("user");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Tickets", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Routes", "routes")
                        .WithMany()
                        .HasForeignKey("routesId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId");

                    b.Navigation("routes");

                    b.Navigation("users");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.TicketsDetails", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Tickets", null)
                        .WithMany("Items")
                        .HasForeignKey("TicketsId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Routes", "routes")
                        .WithMany()
                        .HasForeignKey("routesId");

                    b.Navigation("routes");
                });

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.TicketsDetailsTemp", b =>
                {
                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Routes", "routesId")
                        .WithMany()
                        .HasForeignKey("routesIdId");

                    b.HasOne("AirFiel_Mariana_Oliveira.Data.Entities.Users", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("routesId");

                    b.Navigation("user");
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

            modelBuilder.Entity("AirFiel_Mariana_Oliveira.Data.Entities.Tickets", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
