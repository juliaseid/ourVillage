using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class parentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Families");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Families",
                nullable: false,
                defaultValue: 0);
        }
    }
}
