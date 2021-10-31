using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v34dailycheck8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 934, DateTimeKind.Local).AddTicks(7623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 87, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 615, DateTimeKind.Local).AddTicks(8373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 45, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 925, DateTimeKind.Local).AddTicks(9118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 86, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 767, DateTimeKind.Local).AddTicks(7218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 58, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 779, DateTimeKind.Local).AddTicks(3002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 60, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 1, 6, DateTimeKind.Local).AddTicks(825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 97, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 787, DateTimeKind.Local).AddTicks(6518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 61, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 800, DateTimeKind.Local).AddTicks(8522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 63, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 944, DateTimeKind.Local).AddTicks(2428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 88, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 988, DateTimeKind.Local).AddTicks(7145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 95, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 836, DateTimeKind.Local).AddTicks(667),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 72, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 816, DateTimeKind.Local).AddTicks(742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 70, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 824, DateTimeKind.Local).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 71, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 908, DateTimeKind.Local).AddTicks(4913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 84, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 919, DateTimeKind.Local).AddTicks(509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 85, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 874, DateTimeKind.Local).AddTicks(3717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 79, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 845, DateTimeKind.Local).AddTicks(8935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 74, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 855, DateTimeKind.Local).AddTicks(8888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 75, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-blood-pressure-meter", 139.0, 89.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-blood-pressure-gauge", 120.0, 80.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-fever", 37.5, 35.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-diabetes-1", 100.0, 70.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-diabetes-1", 140.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heart-2", 100.0, 60.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 0.80000000000000004 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 0.040000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 125.0, 74.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 25.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 500.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-drinking-water", 5.0, 2.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-weighing-machine", 24.899999999999999, 19.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "Icon",
                value: "flaticon-mental-health-2");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "Icon",
                value: "flaticon-drugs");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 115.0, 77.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 52000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 400000.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 40.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-blood-test-1", 200.0, 140.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 125.0, 90.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 70.0, 35.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 200.0, 40.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 291.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 270.0, 120.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-vitamins", 911.0, 211.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 17.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-vitamins", 80.0, 21.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 3.8999999999999999, 2.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 1.76, 0.89000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 5.5, 0.34999999999999998 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 49.0, 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon-heartbeat", 36.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 23.0, 9.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 50.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 1.1000000000000001, 0.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 1.2, 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "flaticon - heartbeat", 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[] { "flaticon-heartbeat", 76.0, 14.0, "Total Testosteron" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 29.199999999999999, 28.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-insulin", 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "flaticon-heartbeat", 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "far fa-clipboard", true, 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "far fa-clipboard", true, 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "fas fa-file-upload", true, 25.0, 3.0 });

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
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 87, DateTimeKind.Local).AddTicks(6968),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 934, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 45, DateTimeKind.Local).AddTicks(202),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 615, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 86, DateTimeKind.Local).AddTicks(6961),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 925, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 58, DateTimeKind.Local).AddTicks(5420),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 767, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 60, DateTimeKind.Local).AddTicks(1663),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 779, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 97, DateTimeKind.Local).AddTicks(9587),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 1, 6, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 61, DateTimeKind.Local).AddTicks(4159),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 787, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 63, DateTimeKind.Local).AddTicks(3538),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 800, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 88, DateTimeKind.Local).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 944, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 95, DateTimeKind.Local).AddTicks(4338),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 988, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 72, DateTimeKind.Local).AddTicks(7298),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 836, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 70, DateTimeKind.Local).AddTicks(1869),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 816, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 71, DateTimeKind.Local).AddTicks(3026),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 824, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 84, DateTimeKind.Local).AddTicks(1096),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 908, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 85, DateTimeKind.Local).AddTicks(7220),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 919, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 79, DateTimeKind.Local).AddTicks(3507),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 874, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 74, DateTimeKind.Local).AddTicks(358),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 845, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 6, 18, 75, DateTimeKind.Local).AddTicks(3063),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 15, 20, 0, 855, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 139.0, 89.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 120.0, 80.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 37.5, 35.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 100.0, 70.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 140.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 100.0, 60.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 0.80000000000000004 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 0.040000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 125.0, 74.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 25.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 500.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 5.0, 2.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 24.899999999999999, 19.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "Icon",
                value: "fa fa-user");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "Icon",
                value: "fa fa-user");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 115.0, 77.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 52000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 400000.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 40.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 200.0, 140.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 125.0, 90.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 70.0, 35.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 200.0, 40.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 291.0, 100.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 270.0, 120.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 911.0, 211.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 17.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 80.0, 21.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 3.8999999999999999, 2.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 1.76, 0.89000000000000001 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 5.5, 0.34999999999999998 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 49.0, 10.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 36.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 23.0, 9.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 50.0, 20.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 1.1000000000000001, 0.5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 1.2, 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Icon", "MaxValue" },
                values: new object[] { "fa fa-user", 0.29999999999999999 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[] { "fa fa-user", 76.0, 14.0, "Total Testesteron" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 29.199999999999999, 28.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Icon", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", 1000.0, 4.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", false, 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", false, 25.0, 3.0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Icon", "IsDefault", "MaxValue", "MinValue" },
                values: new object[] { "fa fa-user", false, 25.0, 3.0 });

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
