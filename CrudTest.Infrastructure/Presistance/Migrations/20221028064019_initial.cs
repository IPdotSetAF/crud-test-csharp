using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudTest.Infrastructure.Presistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankAccountNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BankAccountNumber", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"), 1212121212121212m, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "test2@gmail.com", "Hooshang", "Motahari", 989387016860m },
                    { new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"), 1212121212121212m, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ipdotsetaf@gmail.com", "Mahdi", "Nazari", 989387016860m },
                    { new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"), 1212121212121212m, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "testt@gmail.com", "Saeed", "Rezaii", 19387016860m },
                    { new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"), 1212121212121212m, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ipdotsetaf.work@gmail.com", "Ali", "Nazari", 989387016860m }
                });

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
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
