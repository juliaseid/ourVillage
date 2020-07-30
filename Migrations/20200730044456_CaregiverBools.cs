using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class CaregiverBools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Emergency",
                table: "Caregivers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Evenings",
                table: "Caregivers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Weekdays",
                table: "Caregivers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Weekends",
                table: "Caregivers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emergency",
                table: "Caregivers");

            migrationBuilder.DropColumn(
                name: "Evenings",
                table: "Caregivers");

            migrationBuilder.DropColumn(
                name: "Weekdays",
                table: "Caregivers");

            migrationBuilder.DropColumn(
                name: "Weekends",
                table: "Caregivers");
        }
    }
}
