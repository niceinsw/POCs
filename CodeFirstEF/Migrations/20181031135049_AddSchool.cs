using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEF.Migrations
{
    public partial class AddSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(maxLength: 200, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Teachers");
        }
    }
}
