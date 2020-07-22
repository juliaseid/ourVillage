using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
  public partial class ParentOverload : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Parent1ZipCode",
          table: "Families");

      migrationBuilder.RenameColumn(
          name: "Parent1AddressLine2",
          table: "Families",
          newName: "Parent2Relationship");

      migrationBuilder.RenameColumn(
          name: "Parent1AddressLine1",
          table: "Families",
          newName: "Parent2Phone");

      migrationBuilder.AddColumn<string>(
          name: "Parent2FirstName",
          table: "Families",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "Parent2LastName",
          table: "Families",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Parent2FirstName",
          table: "Families");

      migrationBuilder.DropColumn(
          name: "Parent2LastName",
          table: "Families");

      migrationBuilder.RenameColumn(
          name: "Parent2Relationship",
          table: "Families",
          newName: "Parent1AddressLine2");

      migrationBuilder.RenameColumn(
          name: "Parent2Phone",
          table: "Families",
          newName: "Parent1AddressLine1");

      migrationBuilder.AddColumn<int>(
          name: "Parent1ZipCode",
          table: "Families",
          nullable: false,
          defaultValue: 0);
    }
  }
}
