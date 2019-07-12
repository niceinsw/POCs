using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEF.Migrations
{
    public partial class UpdatedStudentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");
        }
    }
}
