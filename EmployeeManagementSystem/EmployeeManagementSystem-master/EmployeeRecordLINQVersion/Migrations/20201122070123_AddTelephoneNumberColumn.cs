using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRecordLINQVersion.Migrations
{
    public partial class AddTelephoneNumberColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Employees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Employees");
        }
    }
}
