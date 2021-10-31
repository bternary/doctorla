using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v46DailyCheckDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 796, DateTimeKind.Local).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 744, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 718, DateTimeKind.Local).AddTicks(3587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 659, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 795, DateTimeKind.Local).AddTicks(1647),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 742, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 754, DateTimeKind.Local).AddTicks(8129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 699, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 758, DateTimeKind.Local).AddTicks(3666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 704, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 835, DateTimeKind.Local).AddTicks(2375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 800, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 810, DateTimeKind.Local).AddTicks(6444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 762, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 760, DateTimeKind.Local).AddTicks(7617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 706, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 762, DateTimeKind.Local).AddTicks(8931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 709, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 798, DateTimeKind.Local).AddTicks(2992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 746, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 806, DateTimeKind.Local).AddTicks(6010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 756, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.AlterColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetailValues",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequest",
                schema: "dbo",
                table: "DailyCheck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 770, DateTimeKind.Local).AddTicks(5652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 718, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 765, DateTimeKind.Local).AddTicks(4358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 713, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 767, DateTimeKind.Local).AddTicks(9908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 715, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 791, DateTimeKind.Local).AddTicks(5252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 737, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 793, DateTimeKind.Local).AddTicks(7059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 740, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 782, DateTimeKind.Local).AddTicks(396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 728, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 773, DateTimeKind.Local).AddTicks(5556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 721, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 776, DateTimeKind.Local).AddTicks(5216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 723, DateTimeKind.Local).AddTicks(9769));

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
            migrationBuilder.DropColumn(
                name: "IsRequest",
                schema: "dbo",
                table: "DailyCheck");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 744, DateTimeKind.Local).AddTicks(713),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 796, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 659, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 718, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 742, DateTimeKind.Local).AddTicks(3150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 795, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 699, DateTimeKind.Local).AddTicks(2872),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 754, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 704, DateTimeKind.Local).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 758, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 800, DateTimeKind.Local).AddTicks(9605),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 835, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 762, DateTimeKind.Local).AddTicks(7100),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 810, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 706, DateTimeKind.Local).AddTicks(7496),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 760, DateTimeKind.Local).AddTicks(7617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 709, DateTimeKind.Local).AddTicks(4537),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 762, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 746, DateTimeKind.Local).AddTicks(3078),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 798, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 756, DateTimeKind.Local).AddTicks(6853),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 806, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.AlterColumn<int>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetailValues",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "IsNew",
                schema: "dbo",
                table: "DailyCheckDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 718, DateTimeKind.Local).AddTicks(3333),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 770, DateTimeKind.Local).AddTicks(5652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 713, DateTimeKind.Local).AddTicks(2240),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 765, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 715, DateTimeKind.Local).AddTicks(928),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 767, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 737, DateTimeKind.Local).AddTicks(5524),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 791, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 740, DateTimeKind.Local).AddTicks(1417),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 793, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 728, DateTimeKind.Local).AddTicks(4819),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 782, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 721, DateTimeKind.Local).AddTicks(5046),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 773, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 15, 20, 42, 7, 723, DateTimeKind.Local).AddTicks(9769),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 15, 21, 26, 52, 776, DateTimeKind.Local).AddTicks(5216));

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
