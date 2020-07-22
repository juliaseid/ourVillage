using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
  public partial class ProfileName : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "ProfileName",
          table: "Families",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "ProfileName",
          table: "Families");
    }
  }
}
