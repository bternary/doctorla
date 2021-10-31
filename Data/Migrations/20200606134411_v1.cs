using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 436, DateTimeKind.Local).AddTicks(2084)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 432, DateTimeKind.Local).AddTicks(7969)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 446, DateTimeKind.Local).AddTicks(4495)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    SessionTime = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 430, DateTimeKind.Local).AddTicks(3915)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referance",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 429, DateTimeKind.Local).AddTicks(5658)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroup",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sick",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 442, DateTimeKind.Local).AddTicks(7490)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sick", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 433, DateTimeKind.Local).AddTicks(7051)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 431, DateTimeKind.Local).AddTicks(3910)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_MenuType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "MenuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 412, DateTimeKind.Local).AddTicks(1939)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    TypeId = table.Column<short>(nullable: false),
                    TC = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true, defaultValue: "defaultuser.png"),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    RoleGroupId = table.Column<short>(nullable: false),
                    UserDetailId = table.Column<int>(nullable: false),
                    DoctorDetailId = table.Column<int>(nullable: false),
                    AccountBalance = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenEndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_RoleGroup_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalSchema: "dbo",
                        principalTable: "RoleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "County",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DefaultName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 435, DateTimeKind.Local).AddTicks(470)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 439, DateTimeKind.Local).AddTicks(2076)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    SessionKey = table.Column<string>(nullable: true),
                    SessionCode = table.Column<string>(nullable: true),
                    SessionPrice = table.Column<int>(nullable: false),
                    AppointmentNote = table.Column<string>(nullable: true),
                    AppointmentDoctorNote = table.Column<string>(nullable: true),
                    AppointmentRate = table.Column<int>(nullable: false),
                    AppointmentRateNote = table.Column<string>(nullable: true),
                    UserCancelReason = table.Column<string>(nullable: true),
                    DoctorDeleteReason = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false, defaultValue: false),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    AppointmentFinishDate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    SickId = table.Column<int>(nullable: false),
                    DepartmentId1 = table.Column<int>(nullable: true),
                    SickId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Department_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Sick_SickId",
                        column: x => x.SickId,
                        principalSchema: "dbo",
                        principalTable: "Sick",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Sick_SickId1",
                        column: x => x.SickId1,
                        principalSchema: "dbo",
                        principalTable: "Sick",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "UserAppointmen_FK",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 444, DateTimeKind.Local).AddTicks(5793)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    HospitalName = table.Column<string>(nullable: true),
                    UniverstyName = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    PageView = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelUserDepartment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IDate = table.Column<DateTime>(nullable: false),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelUserDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelUserDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelUserDepartment_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 443, DateTimeKind.Local).AddTicks(6068)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    UserJob = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Bloodtype = table.Column<string>(nullable: true),
                    ChronicDiseases = table.Column<string>(nullable: true),
                    FamilyDiseases = table.Column<string>(nullable: true),
                    RegularlyMedicines = table.Column<string>(nullable: true),
                    SurgicalHistory = table.Column<string>(nullable: true),
                    HearUs = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 6, 16, 44, 11, 437, DateTimeKind.Local).AddTicks(3416)),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CountyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressDetail = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_County_CountyId",
                        column: x => x.CountyId,
                        principalSchema: "dbo",
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_AddressType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false),
                    IUser = table.Column<int>(nullable: false),
                    UUDate = table.Column<DateTime>(nullable: true),
                    UUser = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsDoctor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentFiles_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "dbo",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentProcess",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDate = table.Column<DateTime>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false),
                    IsDoctor = table.Column<bool>(nullable: false),
                    ProcessMessage = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentProcess_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "dbo",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentProcess_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEducations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DoctorDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducations_DoctorDetail_DoctorDetailId",
                        column: x => x.DoctorDetailId,
                        principalSchema: "dbo",
                        principalTable: "DoctorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorExperiences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: true),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DoctorDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorExperiences_DoctorDetail_DoctorDetailId",
                        column: x => x.DoctorDetailId,
                        principalSchema: "dbo",
                        principalTable: "DoctorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalInterests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: true),
                    DoctorDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalInterests_DoctorDetail_DoctorDetailId",
                        column: x => x.DoctorDetailId,
                        principalSchema: "dbo",
                        principalTable: "DoctorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorScientificMembership",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DefaultName = table.Column<string>(nullable: true),
                    BeginDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DoctorDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorScientificMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorScientificMembership_DoctorDetail_DoctorDetailId",
                        column: x => x.DoctorDetailId,
                        principalSchema: "dbo",
                        principalTable: "DoctorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AddressType",
                columns: new[] { "Id", "DefaultName", "IUser", "IsDeleted", "Name", "UUDate", "UUser" },
                values: new object[,]
                {
                    { 1, "Home Address", 0, false, "Ev Adresi", null, null },
                    { 2, "Work Address", 0, false, "İş Adresi", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Department",
                columns: new[] { "Id", "DefaultName", "IUser", "Image", "IsActive", "Name", "ParentId", "SessionTime", "UUDate", "UUser" },
                values: new object[,]
                {
                    { 23, null, 0, "flaticon-gynecology", true, "Jinekolojik Onkoloji", 0, 10, null, null },
                    { 24, null, 0, "flaticon-sexual-health", true, "Kadın Hastalıkları ve Doğum", 0, 10, null, null },
                    { 25, null, 0, "flaticon-heart-1", true, "Kalp ve Damar Cerrahisi", 0, 10, null, null },
                    { 26, null, 0, "flaticon-cardiology", true, "Kardiyoloji", 0, 10, null, null },
                    { 27, null, 0, "flaticon-kulakburunbugaz", true, "Kulak Burun Boğaz", 0, 10, null, null },
                    { 28, null, 0, "flaticon-kidney", true, "Nefroloji", 0, 10, null, null },
                    { 29, null, 0, "flaticon-neurology-1", true, "Nöroloji", 0, 10, null, null },
                    { 30, null, 0, "flaticon-broken-arm", true, "Ortopedi", 0, 10, null, null },
                    { 31, null, 0, "flaticon-surgery", true, "Plastik Cerrahi", 0, 10, null, null },
                    { 32, null, 0, "flaticon-mental-health-2", true, "Psikiyatri", 0, 10, null, null },
                    { 33, null, 0, "flaticon-radiation", true, "Radyasyon Onkolojisi", 0, 10, null, null },
                    { 34, null, 0, "flaticon-joint-1", true, "Romatoloji", 0, 10, null, null },
                    { 35, null, 0, "flaticon-quit-smoking-1", true, "Sigarayı Bıraktırma", 0, 10, null, null },
                    { 36, null, 0, "flaticon-radiotherapy-1", true, "Tıbbi Onkoloji", 0, 10, null, null },
                    { 37, null, 0, "flaticon-uroloji", true, "Üroloji", 0, 10, null, null },
                    { 38, null, 0, "flaticon-burn", true, "Yanık Polikliniği", 0, 10, null, null },
                    { 22, null, 0, "flaticon-stomach", true, "İç Hastalıkları", 0, 10, null, null },
                    { 19, null, 0, "flaticon-eye", true, "Göz Hastalıkları", 0, 10, null, null },
                    { 21, null, 0, "flaticon-test", true, "Hematoloji", 0, 10, null, null },
                    { 7, null, 0, "flaticon-care", true, "Çocuk Kardiyolojisi", 0, 10, null, null },
                    { 1, null, 0, "flaticon-protection", true, "Alerji ve İmmünoloji", 0, 10, null, null },
                    { 2, null, 0, "flaticon-neurosurgery", true, "Beyin ve Sinir Cerrahisi", 0, 10, null, null },
                    { 3, null, 0, "flaticon-surgery-1", true, "Cerrahi Onkoloji", 0, 10, null, null },
                    { 4, null, 0, "flaticon-baby", true, "Çocuk Cerrahisi", 0, 10, null, null },
                    { 5, null, 0, "flaticon-digestive-system", true, "Çocuk Gastroenterolojisi", 0, 10, null, null },
                    { 6, null, 0, "flaticon-blood-sample", true, "Çocuk Hematolojisi", 0, 10, null, null },
                    { 18, null, 0, "flaticon-lung", true, "Göğüs Hastalıkları", 0, 10, null, null },
                    { 8, null, 0, "flaticon-babies", true, "Çocuk Psiyikatri", 0, 10, null, null },
                    { 9, null, 0, "flaticon-x-ray", true, "Çocuk Romatolojisi", 0, 10, null, null },
                    { 10, null, 0, "flaticon-baby-boy", true, "Çocuk Sağlığı ve Hastalıkları", 0, 10, null, null },
                    { 11, null, 0, "flaticon-kidneys-1", true, "Çocuk Ürolojisi", 0, 10, null, null },
                    { 12, null, 0, "flaticon-dermatology", true, "Dermatoloji", 0, 10, null, null },
                    { 13, null, 0, "flaticon-adrenal-gland", true, "Endokrinoloji", 0, 10, null, null },
                    { 14, null, 0, "flaticon-infected-lungs", true, "Enfeksiyon", 0, 10, null, null },
                    { 15, null, 0, "flaticon-physical", true, "Fizik Tedavi", 0, 10, null, null },
                    { 16, null, 0, "flaticon-medical-tools", true, "Genel Cerrahi", 0, 10, null, null },
                    { 17, null, 0, "flaticon-chest-pain", true, "Göğüs Cerrahisi", 0, 10, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleGroup",
                columns: new[] { "Id", "DefaultName", "Name" },
                values: new object[,]
                {
                    { (short)1, "Admin", "Admin" },
                    { (short)3, "User", "User" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserType",
                columns: new[] { "Id", "DefaultName", "Name" },
                values: new object[,]
                {
                    { (short)2, "Nurse", "Hemşire" },
                    { (short)1, "Doctor", "Doktor" },
                    { (short)3, "Patient", "Hasta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                schema: "dbo",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "dbo",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountyId",
                schema: "dbo",
                table: "Address",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TypeId",
                schema: "dbo",
                table: "Address",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "dbo",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DepartmentId",
                schema: "dbo",
                table: "Appointment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DepartmentId1",
                schema: "dbo",
                table: "Appointment",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SickId",
                schema: "dbo",
                table: "Appointment",
                column: "SickId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SickId1",
                schema: "dbo",
                table: "Appointment",
                column: "SickId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                schema: "dbo",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentFiles_AppointmentId",
                schema: "dbo",
                table: "AppointmentFiles",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProcess_AppointmentId",
                schema: "dbo",
                table: "AppointmentProcess",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProcess_UserId",
                schema: "dbo",
                table: "AppointmentProcess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                schema: "dbo",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_County_CityId",
                schema: "dbo",
                table: "County",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetail_UserId",
                schema: "dbo",
                table: "DoctorDetail",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducations_DoctorDetailId",
                schema: "dbo",
                table: "DoctorEducations",
                column: "DoctorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorExperiences_DoctorDetailId",
                schema: "dbo",
                table: "DoctorExperiences",
                column: "DoctorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalInterests_DoctorDetailId",
                schema: "dbo",
                table: "DoctorMedicalInterests",
                column: "DoctorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorScientificMembership_DoctorDetailId",
                schema: "dbo",
                table: "DoctorScientificMembership",
                column: "DoctorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_TypeId",
                schema: "dbo",
                table: "Menu",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RelUserDepartment_DepartmentId",
                schema: "dbo",
                table: "RelUserDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RelUserDepartment_UserId",
                schema: "dbo",
                table: "RelUserDepartment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleGroupId",
                schema: "dbo",
                table: "User",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeId",
                schema: "dbo",
                table: "User",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserId",
                schema: "dbo",
                table: "UserDetail",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppointmentFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppointmentProcess",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorEducations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorExperiences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorMedicalInterests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorScientificMembership",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Referance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RelUserDepartment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "County",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MenuType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sick",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "dbo");
        }
    }
}
