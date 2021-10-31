using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

        

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 809, DateTimeKind.Local).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 324, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 764, DateTimeKind.Local).AddTicks(9555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 290, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 808, DateTimeKind.Local).AddTicks(3809),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 323, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 786, DateTimeKind.Local).AddTicks(4090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 308, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 788, DateTimeKind.Local).AddTicks(4017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 309, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 789, DateTimeKind.Local).AddTicks(6536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 310, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 790, DateTimeKind.Local).AddTicks(9226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 311, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 810, DateTimeKind.Local).AddTicks(5113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 325, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 812, DateTimeKind.Local).AddTicks(3839),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 327, DateTimeKind.Local).AddTicks(4748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 796, DateTimeKind.Local).AddTicks(5760),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 315, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 792, DateTimeKind.Local).AddTicks(7336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 313, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 794, DateTimeKind.Local).AddTicks(1785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 313, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.AddColumn<int>(
                name: "ProcessTypes",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 803, DateTimeKind.Local).AddTicks(1539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 319, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.AddColumn<string>(
                name: "DonationCompanys",
                schema: "dbo",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InProcessDates",
                schema: "dbo",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 797, DateTimeKind.Local).AddTicks(9472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 316, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 799, DateTimeKind.Local).AddTicks(7045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 317, DateTimeKind.Local).AddTicks(6506));

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
                name: "ProcessTypes",
                schema: "dbo",
                table: "AppointmentProcess");

            migrationBuilder.DropColumn(
                name: "DonationCompanys",
                schema: "dbo",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "InProcessDates",
                schema: "dbo",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 324, DateTimeKind.Local).AddTicks(3713),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 809, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 290, DateTimeKind.Local).AddTicks(1284),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 764, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 323, DateTimeKind.Local).AddTicks(4249),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 808, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 308, DateTimeKind.Local).AddTicks(886),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 786, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 309, DateTimeKind.Local).AddTicks(5874),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 788, DateTimeKind.Local).AddTicks(4017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 310, DateTimeKind.Local).AddTicks(4678),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 789, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 311, DateTimeKind.Local).AddTicks(4983),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 790, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 325, DateTimeKind.Local).AddTicks(6405),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 810, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 327, DateTimeKind.Local).AddTicks(4748),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 812, DateTimeKind.Local).AddTicks(3839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 315, DateTimeKind.Local).AddTicks(3182),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 796, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 313, DateTimeKind.Local).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 792, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 313, DateTimeKind.Local).AddTicks(9492),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 794, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.AddColumn<int>(
                name: "ProcessType",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 319, DateTimeKind.Local).AddTicks(6781),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 803, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.AddColumn<string>(
                name: "DonationCompany",
                schema: "dbo",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InProcessDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 316, DateTimeKind.Local).AddTicks(4876),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 797, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 19, 43, 15, 317, DateTimeKind.Local).AddTicks(6506),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 9, 20, 4, 43, 799, DateTimeKind.Local).AddTicks(7045));

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
    }
}
