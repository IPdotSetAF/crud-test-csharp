using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudTest.Infrastructure.Presistance.Migrations
{
    public partial class switch_to_VO : Migration
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
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "BankAccountNumber", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3dde6799-7063-d42e-ba04-85ff4e664534"), new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hooshang", "Motahari", 1212121212121212m, "test2@gmail.com", 989387016860m },
                    { new Guid("5c740a82-5dab-dd83-8452-e4299aaad12f"), new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahdi", "Nazari", 1212121212121212m, "ipdotsetaf@gmail.com", 989387016860m },
                    { new Guid("b2c3a9ba-f1a9-2627-dce1-c0101ddfff08"), new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saeed", "Rezaii", 1212121212121212m, "testt@gmail.com", 19387016860m },
                    { new Guid("ff336907-0499-11d1-0d89-6e2c525e39e5"), new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", "Nazari", 1212121212121212m, "ipdotsetaf.work@gmail.com", 989387016860m }
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
