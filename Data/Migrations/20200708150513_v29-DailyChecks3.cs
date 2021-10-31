using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v29DailyChecks3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyCheckDetail_ValuesTitleId",
                schema: "dbo",
                table: "DailyCheckDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 292, DateTimeKind.Local).AddTicks(1178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 897, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 254, DateTimeKind.Local).AddTicks(6851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 861, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 291, DateTimeKind.Local).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 897, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 270, DateTimeKind.Local).AddTicks(5976),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 876, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 272, DateTimeKind.Local).AddTicks(1292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 878, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 299, DateTimeKind.Local).AddTicks(7636),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 904, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 273, DateTimeKind.Local).AddTicks(106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 878, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 274, DateTimeKind.Local).AddTicks(457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 880, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 293, DateTimeKind.Local).AddTicks(1273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 898, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 297, DateTimeKind.Local).AddTicks(7859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 903, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 281, DateTimeKind.Local).AddTicks(1154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 887, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 275, DateTimeKind.Local).AddTicks(5661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 881, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 276, DateTimeKind.Local).AddTicks(4820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 882, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 289, DateTimeKind.Local).AddTicks(2336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 895, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 290, DateTimeKind.Local).AddTicks(4507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 896, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 285, DateTimeKind.Local).AddTicks(3153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 891, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 282, DateTimeKind.Local).AddTicks(1847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 888, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 283, DateTimeKind.Local).AddTicks(2079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 889, DateTimeKind.Local).AddTicks(5581));

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
                name: "IX_DailyCheckDetail_ValuesTitleId",
                schema: "dbo",
                table: "DailyCheckDetail",
                column: "ValuesTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyCheckDetail_ValuesTitleId",
                schema: "dbo",
                table: "DailyCheckDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 897, DateTimeKind.Local).AddTicks(8143),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 292, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 861, DateTimeKind.Local).AddTicks(6368),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 254, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 897, DateTimeKind.Local).AddTicks(125),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 291, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 876, DateTimeKind.Local).AddTicks(6600),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 270, DateTimeKind.Local).AddTicks(5976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 878, DateTimeKind.Local).AddTicks(823),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 272, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 904, DateTimeKind.Local).AddTicks(8776),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 299, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 878, DateTimeKind.Local).AddTicks(8458),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 273, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 880, DateTimeKind.Local).AddTicks(389),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 274, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 898, DateTimeKind.Local).AddTicks(7900),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 293, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 903, DateTimeKind.Local).AddTicks(1476),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 297, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 887, DateTimeKind.Local).AddTicks(3973),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 281, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 881, DateTimeKind.Local).AddTicks(5835),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 275, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 882, DateTimeKind.Local).AddTicks(4683),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 276, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 895, DateTimeKind.Local).AddTicks(1302),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 289, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 896, DateTimeKind.Local).AddTicks(2051),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 290, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 891, DateTimeKind.Local).AddTicks(5272),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 285, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 888, DateTimeKind.Local).AddTicks(4630),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 282, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 17, 55, 52, 889, DateTimeKind.Local).AddTicks(5581),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 18, 5, 13, 283, DateTimeKind.Local).AddTicks(2079));

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
                name: "IX_DailyCheckDetail_ValuesTitleId",
                schema: "dbo",
                table: "DailyCheckDetail",
                column: "ValuesTitleId",
                unique: true);
        }
    }
}
