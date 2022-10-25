using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class made_email_and_names_and_date_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customer",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "test2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ipdotsetaf@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "testt@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"),
                column: "DateOfBirth",
                value: new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FirstName_LastName_DateOfBirth",
                table: "Customer",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Email",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_FirstName_LastName_DateOfBirth",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4883), "ipdotsetaf.work@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4859), "ipdotsetaf.work@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"),
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4871), "ipdotsetaf.work@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"),
                column: "DateOfBirth",
                value: new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4817));
        }
    }
}
