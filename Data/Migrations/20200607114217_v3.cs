using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                schema: "dbo",
                table: "Department");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 360, DateTimeKind.Local).AddTicks(5945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 801, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 327, DateTimeKind.Local).AddTicks(1582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 770, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 359, DateTimeKind.Local).AddTicks(6937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 800, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "SessionTime",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 345, DateTimeKind.Local).AddTicks(5538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 787, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 346, DateTimeKind.Local).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 788, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 347, DateTimeKind.Local).AddTicks(5129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 789, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 361, DateTimeKind.Local).AddTicks(6809),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 802, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 363, DateTimeKind.Local).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 804, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 351, DateTimeKind.Local).AddTicks(4047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 792, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 349, DateTimeKind.Local).AddTicks(375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 790, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 350, DateTimeKind.Local).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 791, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 355, DateTimeKind.Local).AddTicks(8088),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 797, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.AddColumn<int>(
                name: "SessionTime",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 352, DateTimeKind.Local).AddTicks(5768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 794, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 353, DateTimeKind.Local).AddTicks(7909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 795, DateTimeKind.Local).AddTicks(1579));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "RelUserDepartment");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                schema: "dbo",
                table: "RelUserDepartment");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                schema: "dbo",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 801, DateTimeKind.Local).AddTicks(4574),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 360, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 770, DateTimeKind.Local).AddTicks(5289),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 327, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 800, DateTimeKind.Local).AddTicks(6224),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 359, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 787, DateTimeKind.Local).AddTicks(6343),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 345, DateTimeKind.Local).AddTicks(5538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 788, DateTimeKind.Local).AddTicks(4446),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 346, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 789, DateTimeKind.Local).AddTicks(4207),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 347, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 802, DateTimeKind.Local).AddTicks(4083),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 361, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 804, DateTimeKind.Local).AddTicks(1938),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 363, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                schema: "dbo",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionTime",
                schema: "dbo",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 792, DateTimeKind.Local).AddTicks(9374),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 351, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 790, DateTimeKind.Local).AddTicks(7807),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 349, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 791, DateTimeKind.Local).AddTicks(6726),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 350, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 797, DateTimeKind.Local).AddTicks(1858),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 355, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 794, DateTimeKind.Local).AddTicks(156),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 352, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 6, 20, 55, 49, 795, DateTimeKind.Local).AddTicks(1579),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 14, 42, 17, 353, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Department",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "IsActive", "SessionTime" },
                values: new object[] { true, 10 });
        }
    }
}
