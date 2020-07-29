using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class SecretCodepublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecretCode",
                table: "Families",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretCode",
                table: "Families");
        }
    }
}
