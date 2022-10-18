using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class seed_customer_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BankAccountNumber", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"), 1212121212121212m, new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4883), "ipdotsetaf.work@gmail.com", "Hooshang", "Motahari", 989387016860m },
                    { new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"), 1212121212121212m, new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4859), "ipdotsetaf.work@gmail.com", "Mahdi", "Nazari", 989387016860m },
                    { new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"), 1212121212121212m, new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4871), "ipdotsetaf.work@gmail.com", "Saeed", "Rezaii", 19387016860m },
                    { new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"), 1212121212121212m, new DateTime(2022, 10, 18, 16, 30, 16, 289, DateTimeKind.Local).AddTicks(4817), "ipdotsetaf.work@gmail.com", "Ali", "Nazari", 989387016860m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"));
        }
    }
}
