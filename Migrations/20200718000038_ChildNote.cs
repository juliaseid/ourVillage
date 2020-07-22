using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
  public partial class ChildNote : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Note",
          columns: table => new
          {
            NoteId = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Text = table.Column<string>(nullable: true),
            UserId = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Note", x => x.NoteId);
            table.ForeignKey(
                      name: "FK_Note_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "ChildNote",
          columns: table => new
          {
            ChildNoteId = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            ChildId = table.Column<int>(nullable: false),
            NoteId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ChildNote", x => x.ChildNoteId);
            table.ForeignKey(
                      name: "FK_ChildNote_Children_ChildId",
                      column: x => x.ChildId,
                      principalTable: "Children",
                      principalColumn: "ChildId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ChildNote_Note_NoteId",
                      column: x => x.NoteId,
                      principalTable: "Note",
                      principalColumn: "NoteId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_ChildNote_ChildId",
          table: "ChildNote",
          column: "ChildId");

      migrationBuilder.CreateIndex(
          name: "IX_ChildNote_NoteId",
          table: "ChildNote",
          column: "NoteId");

      migrationBuilder.CreateIndex(
          name: "IX_Note_UserId",
          table: "Note",
          column: "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ChildNote");

      migrationBuilder.DropTable(
          name: "Note");
    }
  }
}
