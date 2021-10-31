using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v18adminpanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 668, DateTimeKind.Local).AddTicks(4157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 11, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 638, DateTimeKind.Local).AddTicks(6389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 981, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 667, DateTimeKind.Local).AddTicks(6511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 10, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 652, DateTimeKind.Local).AddTicks(2302),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 995, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 653, DateTimeKind.Local).AddTicks(4956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 996, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 675, DateTimeKind.Local).AddTicks(3445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 18, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 654, DateTimeKind.Local).AddTicks(2298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 997, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 655, DateTimeKind.Local).AddTicks(1610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 998, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 669, DateTimeKind.Local).AddTicks(3578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 12, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 673, DateTimeKind.Local).AddTicks(6544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 16, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 658, DateTimeKind.Local).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 1, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 656, DateTimeKind.Local).AddTicks(4132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 999, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 657, DateTimeKind.Local).AddTicks(3669),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 0, DateTimeKind.Local).AddTicks(6901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 665, DateTimeKind.Local).AddTicks(8081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 9, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 666, DateTimeKind.Local).AddTicks(8637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 10, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 662, DateTimeKind.Local).AddTicks(3683),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 5, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 659, DateTimeKind.Local).AddTicks(5438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 2, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 660, DateTimeKind.Local).AddTicks(5894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 3, DateTimeKind.Local).AddTicks(8978));

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserType",
                columns: new[] { "Id", "DefaultName", "Name" },
                values: new object[] { (short)4, "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 11, DateTimeKind.Local).AddTicks(7555),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 668, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 981, DateTimeKind.Local).AddTicks(9596),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 638, DateTimeKind.Local).AddTicks(6389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 10, DateTimeKind.Local).AddTicks(9797),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 667, DateTimeKind.Local).AddTicks(6511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 995, DateTimeKind.Local).AddTicks(5002),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 652, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 996, DateTimeKind.Local).AddTicks(9006),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 653, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 18, DateTimeKind.Local).AddTicks(6184),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 675, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 997, DateTimeKind.Local).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 654, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 998, DateTimeKind.Local).AddTicks(5856),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 655, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 12, DateTimeKind.Local).AddTicks(6143),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 669, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 16, DateTimeKind.Local).AddTicks(9339),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 673, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 1, DateTimeKind.Local).AddTicks(8890),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 658, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 17, 999, DateTimeKind.Local).AddTicks(8449),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 656, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 0, DateTimeKind.Local).AddTicks(6901),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 657, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 9, DateTimeKind.Local).AddTicks(1754),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 665, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 10, DateTimeKind.Local).AddTicks(2226),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 666, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 5, DateTimeKind.Local).AddTicks(7164),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 662, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 2, DateTimeKind.Local).AddTicks(9039),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 659, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 16, 24, 18, 3, DateTimeKind.Local).AddTicks(8978),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 23, 16, 35, 30, 660, DateTimeKind.Local).AddTicks(5894));

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
