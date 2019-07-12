using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEF.Migrations
{
    public partial class AddedUsersAndBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockerUserId = table.Column<int>(nullable: false),
                    BlockedUserId = table.Column<int>(nullable: false),
                    BlockerId = table.Column<int>(nullable: true),
                    BlockedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockedId",
                table: "Blocks",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockerId",
                table: "Blocks",
                column: "BlockerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
