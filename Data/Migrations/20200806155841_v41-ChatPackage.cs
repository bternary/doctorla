using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v41ChatPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 988, DateTimeKind.Local).AddTicks(7674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 19, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 955, DateTimeKind.Local).AddTicks(8500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 42, 986, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 987, DateTimeKind.Local).AddTicks(8672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 18, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 970, DateTimeKind.Local).AddTicks(1469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 1, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 971, DateTimeKind.Local).AddTicks(5907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 2, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 41, 9, DateTimeKind.Local).AddTicks(3119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 39, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 996, DateTimeKind.Local).AddTicks(5555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 26, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 972, DateTimeKind.Local).AddTicks(4583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 3, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 973, DateTimeKind.Local).AddTicks(4309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 4, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 989, DateTimeKind.Local).AddTicks(7719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 20, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 994, DateTimeKind.Local).AddTicks(4924),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 24, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.AddColumn<DateTime>(
                name: "LiveEndDate",
                schema: "dbo",
                table: "DailyCheck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LiveRoomName",
                schema: "dbo",
                table: "DailyCheck",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LiveStartDate",
                schema: "dbo",
                table: "DailyCheck",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 977, DateTimeKind.Local).AddTicks(2227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 8, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 975, DateTimeKind.Local).AddTicks(344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 5, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 975, DateTimeKind.Local).AddTicks(9425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 6, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 985, DateTimeKind.Local).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 16, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 986, DateTimeKind.Local).AddTicks(9830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 17, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 981, DateTimeKind.Local).AddTicks(5512),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 12, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 978, DateTimeKind.Local).AddTicks(3142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 9, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 979, DateTimeKind.Local).AddTicks(4504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 10, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.CreateTable(
                name: "PackageChat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DailyCheckId = table.Column<int>(nullable: false),
                    IsDoctor = table.Column<bool>(nullable: false),
                    IsFile = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageChat_DailyCheck_DailyCheckId",
                        column: x => x.DailyCheckId,
                        principalSchema: "dbo",
                        principalTable: "DailyCheck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 139.0, 89.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 120.0, 80.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 37.5, 35.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 100.0, 70.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 140.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 100.0, 60.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "MaxValue",
                value: 0.80000000000000004);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "MaxValue",
                value: 20.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "MaxValue",
                value: 0.040000000000000001);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 125.0, 74.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "MaxValue",
                value: 25.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "MaxValue",
                value: 500.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 5.0, 2.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 24.899999999999999, 19.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "MaxValue",
                value: 10.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 115.0, 77.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 52000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 400000.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 40.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 200.0, 140.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 125.0, 90.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 70.0, 35.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 200.0, 40.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 291.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 270.0, 120.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 911.0, 211.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 17.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 80.0, 21.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 3.8999999999999999, 2.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.76, 0.89000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 5.5, 0.34999999999999998 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 49.0, 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "MaxValue",
                value: 36.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 23.0, 9.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 50.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.1000000000000001, 0.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.2, 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "MaxValue",
                value: 0.29999999999999999);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 76.0, 14.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 29.199999999999999, 28.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1100,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1101,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1102,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 26,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 27,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 28,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 29,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 30,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 31,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 32,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 33,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 35,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 36,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 37,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 38,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 47,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 48,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 49,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 50,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 51,
                column: "IsActive",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageChat_DailyCheckId",
                schema: "dbo",
                table: "PackageChat",
                column: "DailyCheckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageChat",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "LiveEndDate",
                schema: "dbo",
                table: "DailyCheck");

            migrationBuilder.DropColumn(
                name: "LiveRoomName",
                schema: "dbo",
                table: "DailyCheck");

            migrationBuilder.DropColumn(
                name: "LiveStartDate",
                schema: "dbo",
                table: "DailyCheck");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 19, DateTimeKind.Local).AddTicks(532),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 988, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 42, 986, DateTimeKind.Local).AddTicks(8157),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 955, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 18, DateTimeKind.Local).AddTicks(2127),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 987, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 1, DateTimeKind.Local).AddTicks(1810),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 970, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 2, DateTimeKind.Local).AddTicks(6261),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 971, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 39, DateTimeKind.Local).AddTicks(4857),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 41, 9, DateTimeKind.Local).AddTicks(3119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 26, DateTimeKind.Local).AddTicks(9481),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 996, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 3, DateTimeKind.Local).AddTicks(4687),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 972, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 4, DateTimeKind.Local).AddTicks(4256),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 973, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 20, DateTimeKind.Local).AddTicks(91),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 989, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 24, DateTimeKind.Local).AddTicks(6707),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 994, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 8, DateTimeKind.Local).AddTicks(1229),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 977, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 5, DateTimeKind.Local).AddTicks(9293),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 975, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 6, DateTimeKind.Local).AddTicks(8470),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 975, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 16, DateTimeKind.Local).AddTicks(2598),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 985, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 17, DateTimeKind.Local).AddTicks(3914),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 986, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 12, DateTimeKind.Local).AddTicks(3918),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 981, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 9, DateTimeKind.Local).AddTicks(2274),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 978, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 6, 18, 35, 43, 10, DateTimeKind.Local).AddTicks(4687),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 6, 18, 58, 40, 979, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 139.0, 89.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 120.0, 80.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 37.5, 35.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 100.0, 70.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 140.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 100.0, 60.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "MaxValue",
                value: 0.80000000000000004);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "MaxValue",
                value: 20.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "MaxValue",
                value: 0.040000000000000001);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 125.0, 74.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "MaxValue",
                value: 25.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "MaxValue",
                value: 500.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 5.0, 2.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 24.899999999999999, 19.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "MaxValue",
                value: 10.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 115.0, 77.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 52000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 400000.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 40.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 200.0, 140.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 125.0, 90.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 70.0, 35.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 200.0, 40.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 291.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 270.0, 120.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 911.0, 211.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 17.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 80.0, 21.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 3.8999999999999999, 2.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.76, 0.89000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 5.5, 0.34999999999999998 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 49.0, 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "MaxValue",
                value: 36.0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 23.0, 9.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 50.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.1000000000000001, 0.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1.2, 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "MaxValue",
                value: 0.29999999999999999);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 76.0, 14.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 29.199999999999999, 28.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1100,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1101,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1102,
                columns: new[] { "MaxValue", "MinValue" },
                values: new object[] { 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 26,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 27,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 28,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 29,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 30,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 31,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 32,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 33,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 35,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 36,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 37,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 38,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 47,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 48,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 49,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 50,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 51,
                column: "IsActive",
                value: true);
        }
    }
}
