using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v44DailyCheckDetailValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 989, DateTimeKind.Local).AddTicks(436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 48, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 550, DateTimeKind.Local).AddTicks(4449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 415, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 972, DateTimeKind.Local).AddTicks(49),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 40, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 617, DateTimeKind.Local).AddTicks(6288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 507, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 636, DateTimeKind.Local).AddTicks(7659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 517, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 797, DateTimeKind.Local).AddTicks(6612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 486, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 290, DateTimeKind.Local).AddTicks(9352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 180, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 647, DateTimeKind.Local).AddTicks(1298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 525, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 661, DateTimeKind.Local).AddTicks(752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 533, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 58, DateTimeKind.Local).AddTicks(747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 74, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 180, DateTimeKind.Local).AddTicks(3269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 148, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.AlterColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetailValues",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 705, DateTimeKind.Local).AddTicks(9536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 693, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 675, DateTimeKind.Local).AddTicks(7247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 560, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 689, DateTimeKind.Local).AddTicks(5855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 616, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 890, DateTimeKind.Local).AddTicks(5053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 977, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 913, DateTimeKind.Local).AddTicks(2098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 995, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 777, DateTimeKind.Local).AddTicks(3666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 939, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 724, DateTimeKind.Local).AddTicks(9237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 753, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 745, DateTimeKind.Local).AddTicks(2799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 867, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AddressType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "İş Adresi");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 48, DateTimeKind.Local).AddTicks(2180),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 989, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 415, DateTimeKind.Local).AddTicks(4040),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 550, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 40, DateTimeKind.Local).AddTicks(8980),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 972, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 507, DateTimeKind.Local).AddTicks(5030),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 617, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 517, DateTimeKind.Local).AddTicks(490),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 636, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 486, DateTimeKind.Local).AddTicks(3910),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 797, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 180, DateTimeKind.Local).AddTicks(1850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 290, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 525, DateTimeKind.Local).AddTicks(7830),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 647, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 533, DateTimeKind.Local).AddTicks(9770),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 661, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 74, DateTimeKind.Local).AddTicks(7160),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 58, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 46, 148, DateTimeKind.Local).AddTicks(5850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 22, 180, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.AlterColumn<int>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetailValues",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 693, DateTimeKind.Local).AddTicks(4960),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 705, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 560, DateTimeKind.Local).AddTicks(3610),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 675, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 616, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 689, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 977, DateTimeKind.Local).AddTicks(7910),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 890, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 995, DateTimeKind.Local).AddTicks(740),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 913, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 939, DateTimeKind.Local).AddTicks(4880),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 777, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 753, DateTimeKind.Local).AddTicks(1650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 724, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 17, 16, 45, 867, DateTimeKind.Local).AddTicks(7670),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 18, 21, 745, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AddressType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "�� Adresi");

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
