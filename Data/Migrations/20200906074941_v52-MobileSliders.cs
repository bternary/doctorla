using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v52MobileSliders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyCheckAlerts_DailyCheck_DailyCheckId",
                schema: "dbo",
                table: "DailyCheckAlerts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 166, DateTimeKind.Local).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 370, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 60, DateTimeKind.Local).AddTicks(779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 261, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 163, DateTimeKind.Local).AddTicks(9227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 368, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 111, DateTimeKind.Local).AddTicks(3754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 308, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 118, DateTimeKind.Local).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 311, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 218, DateTimeKind.Local).AddTicks(536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 434, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 187, DateTimeKind.Local).AddTicks(1820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 398, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 121, DateTimeKind.Local).AddTicks(1934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 314, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 124, DateTimeKind.Local).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 317, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 168, DateTimeKind.Local).AddTicks(9473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 375, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 180, DateTimeKind.Local).AddTicks(5481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 391, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 138, DateTimeKind.Local).AddTicks(9321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 329, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 129, DateTimeKind.Local).AddTicks(343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 321, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 132, DateTimeKind.Local).AddTicks(3023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 324, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 159, DateTimeKind.Local).AddTicks(4458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 362, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 162, DateTimeKind.Local).AddTicks(1241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 366, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 151, DateTimeKind.Local).AddTicks(432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 345, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 142, DateTimeKind.Local).AddTicks(3581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 333, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 146, DateTimeKind.Local).AddTicks(154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 337, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.CreateTable(
                name: "Slider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 222, DateTimeKind.Local).AddTicks(841)),
                    Text = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyCheckAlerts_DailyCheck_DailyCheckId",
                schema: "dbo",
                table: "DailyCheckAlerts",
                column: "DailyCheckId",
                principalSchema: "dbo",
                principalTable: "DailyCheck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyCheckAlerts_DailyCheck_DailyCheckId",
                schema: "dbo",
                table: "DailyCheckAlerts");

            migrationBuilder.DropTable(
                name: "Slider",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 370, DateTimeKind.Local).AddTicks(8148),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 166, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 261, DateTimeKind.Local).AddTicks(7404),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 60, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 368, DateTimeKind.Local).AddTicks(2731),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 163, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 308, DateTimeKind.Local).AddTicks(896),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 111, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 311, DateTimeKind.Local).AddTicks(9401),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 118, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "PaymentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 434, DateTimeKind.Local).AddTicks(7772),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 218, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 398, DateTimeKind.Local).AddTicks(5601),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 187, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 314, DateTimeKind.Local).AddTicks(2768),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 121, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 317, DateTimeKind.Local).AddTicks(3657),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 124, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 375, DateTimeKind.Local).AddTicks(3177),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 168, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 391, DateTimeKind.Local).AddTicks(2847),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 180, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 329, DateTimeKind.Local).AddTicks(2395),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 138, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 321, DateTimeKind.Local).AddTicks(9728),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 129, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 324, DateTimeKind.Local).AddTicks(9819),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 132, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 362, DateTimeKind.Local).AddTicks(2567),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 159, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 366, DateTimeKind.Local).AddTicks(430),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 162, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 345, DateTimeKind.Local).AddTicks(8657),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 151, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 333, DateTimeKind.Local).AddTicks(6438),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 142, DateTimeKind.Local).AddTicks(3581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 28, 23, 17, 1, 337, DateTimeKind.Local).AddTicks(5189),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 6, 10, 49, 40, 146, DateTimeKind.Local).AddTicks(154));

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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyCheckAlerts_DailyCheck_DailyCheckId",
                schema: "dbo",
                table: "DailyCheckAlerts",
                column: "DailyCheckId",
                principalSchema: "dbo",
                principalTable: "DailyCheck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
