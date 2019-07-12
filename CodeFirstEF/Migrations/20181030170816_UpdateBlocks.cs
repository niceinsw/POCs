using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEF.Migrations
{
    public partial class UpdateBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockedUserId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "BlockerUserId",
                table: "Blocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlockedUserId",
                table: "Blocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlockerUserId",
                table: "Blocks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
