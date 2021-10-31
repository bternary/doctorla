using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v32DailyChecks6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 755, DateTimeKind.Local).AddTicks(7662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 334, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 712, DateTimeKind.Local).AddTicks(5181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 299, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 754, DateTimeKind.Local).AddTicks(1962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 333, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 729, DateTimeKind.Local).AddTicks(6117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 313, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 730, DateTimeKind.Local).AddTicks(9103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 314, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 765, DateTimeKind.Local).AddTicks(541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 343, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 731, DateTimeKind.Local).AddTicks(6736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 315, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 732, DateTimeKind.Local).AddTicks(6995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 316, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 756, DateTimeKind.Local).AddTicks(9448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 335, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 762, DateTimeKind.Local).AddTicks(8674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 341, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 741, DateTimeKind.Local).AddTicks(1510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 324, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 738, DateTimeKind.Local).AddTicks(4315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 321, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 739, DateTimeKind.Local).AddTicks(2887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 322, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 750, DateTimeKind.Local).AddTicks(5972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 331, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 752, DateTimeKind.Local).AddTicks(4841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 333, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 745, DateTimeKind.Local).AddTicks(4848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 327, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 742, DateTimeKind.Local).AddTicks(2956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 325, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 743, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 326, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 1, "fa fa-user", 139.0, 89.0, "Kronik Tansiyon" },
                    { 27, "fa fa-user", 291.0, 100.0, "Ferritin" },
                    { 28, "fa fa-user", 270.0, 120.0, "Demir Bağlama Kapasitesi" },
                    { 29, "fa fa-user", 911.0, 211.0, "B12" },
                    { 30, "fa fa-user", 17.0, 3.0, "Folat" },
                    { 31, "fa fa-user", 80.0, 21.0, "D Vit" },
                    { 32, "fa fa-user", 3.8999999999999999, 2.5, "Serbest t3" },
                    { 33, "fa fa-user", 1.76, 0.89000000000000001, "Serbest t4" },
                    { 34, "fa fa-user", 5.5, 0.34999999999999998, "TSH" },
                    { 35, "fa fa-user", 49.0, 10.0, "ALT" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[] { 36, "fa fa-user", 36.0, "AST" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 37, "fa fa-user", 23.0, 9.0, "BUN" },
                    { 38, "fa fa-user", 50.0, 20.0, "ÜRE" },
                    { 39, "fa fa-user", 1.1000000000000001, 0.5, "Kreatin" },
                    { 40, "fa fa-user", 1.2, 0.29999999999999999, "Total Bilirubin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[] { 41, "fa fa-user", 0.29999999999999999, "Direk Bilirubin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 42, "fa fa-user", 76.0, 14.0, "Total Testesteron" },
                    { 43, "fa fa-user", 29.199999999999999, 28.0, "Prolaktin" },
                    { 44, "fa fa-user", 25.0, 3.0, "İnsülin" },
                    { 1000, "fa fa-user", 25.0, 3.0, "Hasta Notu" },
                    { 1001, "fa fa-user", 25.0, 3.0, "Hemşire Notu" },
                    { 1002, "fa fa-user", 25.0, 3.0, "Dosyalar" },
                    { 26, "fa fa-user", 200.0, 40.0, "Trigliserit" },
                    { 25, "fa fa-user", 70.0, 35.0, "HDL" },
                    { 45, "fa fa-user", 1000.0, 4.0, "WBC" },
                    { 23, "fa fa-user", 200.0, 140.0, "Total Kolestrol" },
                    { 2, "fa fa-user", 120.0, 80.0, "Tansiyon" },
                    { 3, "fa fa-user", 37.5, 35.5, "Ateş" },
                    { 4, "fa fa-user", 100.0, 70.0, "Açlık Şekeri" },
                    { 24, "fa fa-user", 125.0, 90.0, "LDL" },
                    { 5, "fa fa-user", 140.0, 100.0, "Tokluk Şekeri" },
                    { 6, "fa fa-user", 100.0, 60.0, "Nabız" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[,]
                {
                    { 7, "fa fa-user", 0.80000000000000004, "CRP" },
                    { 9, "fa fa-user", 0.040000000000000001, "Troponin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[] { 10, "fa fa-user", 125.0, 74.0, "BNP" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[,]
                {
                    { 11, "fa fa-user", 25.0, "CK-MB" },
                    { 8, "fa fa-user", 20.0, "Sedimantasyon" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 13, "fa fa-user", 5.0, 2.0, "Su Kullanımı" },
                    { 22, "fa fa-user", 40.0, 20.0, "LYMPH % (Lenfosit)" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[] { 12, "fa fa-user", 500.0, "D-Dimer" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 20, "fa fa-user", 52000.0, 4.0, "RBC" },
                    { 19, "fa fa-user", 115.0, 77.0, "MCV" },
                    { 18, "fa fa-user", 1000.0, 4.0, "WBC" },
                    { 21, "fa fa-user", 400000.0, 100.0, "PLT (Trombosit)" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "Name" },
                values: new object[] { 16, "fa fa-user", 10.0, "Beta-HCG" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 15, "fa fa-user", "Mental Durum" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "MaxValue", "MinValue", "Name" },
                values: new object[] { 14, "fa fa-user", 24.899999999999999, 19.0, "Vücut Kitle İndeksi" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 17, "fa fa-user", "İlaç Kullanımı" });

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
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "UserDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 334, DateTimeKind.Local).AddTicks(7480),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 755, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 299, DateTimeKind.Local).AddTicks(9040),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 712, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Sick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 333, DateTimeKind.Local).AddTicks(8978),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 754, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "RelUserDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 313, DateTimeKind.Local).AddTicks(3387),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 729, DateTimeKind.Local).AddTicks(6117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Referance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 314, DateTimeKind.Local).AddTicks(7449),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 730, DateTimeKind.Local).AddTicks(9103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "NotifyTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 343, DateTimeKind.Local).AddTicks(9816),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 765, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "MenuType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 315, DateTimeKind.Local).AddTicks(5513),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 731, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 316, DateTimeKind.Local).AddTicks(5106),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 732, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "DoctorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 335, DateTimeKind.Local).AddTicks(7863),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 756, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 341, DateTimeKind.Local).AddTicks(4213),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 762, DateTimeKind.Local).AddTicks(8674));

            migrationBuilder.AlterColumn<float>(
                name: "MinValue",
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<float>(
                name: "MaxValue",
                schema: "dbo",
                table: "DailyCheckPackagesValues",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "County",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 324, DateTimeKind.Local).AddTicks(552),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 741, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 321, DateTimeKind.Local).AddTicks(8357),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 738, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 322, DateTimeKind.Local).AddTicks(7898),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 739, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 331, DateTimeKind.Local).AddTicks(8973),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 750, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AppointmentFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 333, DateTimeKind.Local).AddTicks(571),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 752, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 327, DateTimeKind.Local).AddTicks(9672),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 745, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "AddressType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 325, DateTimeKind.Local).AddTicks(821),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 742, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 13, 30, 56, 326, DateTimeKind.Local).AddTicks(972),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 0, 0, 35, 743, DateTimeKind.Local).AddTicks(4131));

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
