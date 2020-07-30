using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class ParentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_AspNetUsers_ParentUserId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_ParentUserId",
                table: "Families");

            migrationBuilder.RenameColumn(
                name: "ParentUserId",
                table: "Families",
                newName: "ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Families",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Families",
                newName: "ParentUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ParentUserId",
                table: "Families",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
