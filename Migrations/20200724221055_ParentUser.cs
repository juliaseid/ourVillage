using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class ParentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentUserId",
                table: "Families",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_ParentUserId",
                table: "Families",
                column: "ParentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_AspNetUsers_ParentUserId",
                table: "Families",
                column: "ParentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_AspNetUsers_ParentUserId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_ParentUserId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "ParentUserId",
                table: "Families");
        }
    }
}
