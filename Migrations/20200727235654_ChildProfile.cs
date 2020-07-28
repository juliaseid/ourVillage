using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class ChildProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildNote_Children_ChildId",
                table: "ChildNote");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildNote_Note_NoteId",
                table: "ChildNote");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_UserId",
                table: "Note");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildNote",
                table: "ChildNote");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "ChildNote",
                newName: "ChildNotes");

            migrationBuilder.RenameIndex(
                name: "IX_Note_UserId",
                table: "Notes",
                newName: "IX_Notes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildNote_NoteId",
                table: "ChildNotes",
                newName: "IX_ChildNotes_NoteId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildNote_ChildId",
                table: "ChildNotes",
                newName: "IX_ChildNotes_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildNotes",
                table: "ChildNotes",
                column: "ChildNoteId");

            migrationBuilder.CreateTable(
                name: "ChildProfiles",
                columns: table => new
                {
                    ChildProfileId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChildId = table.Column<int>(nullable: false),
                    MedicalConditions = table.Column<string>(nullable: true),
                    Medications = table.Column<string>(nullable: true),
                    Allergies = table.Column<string>(nullable: true),
                    Dietary = table.Column<string>(nullable: true),
                    Snacks = table.Column<string>(nullable: true),
                    Meals = table.Column<string>(nullable: true),
                    Bedtime = table.Column<string>(nullable: true),
                    Naptime = table.Column<string>(nullable: true),
                    Behavior = table.Column<string>(nullable: true),
                    Rewards = table.Column<string>(nullable: true),
                    Consequences = table.Column<string>(nullable: true),
                    PackForSchool = table.Column<string>(nullable: true),
                    SchoolMeals = table.Column<string>(nullable: true),
                    SchoolDetails = table.Column<string>(nullable: true),
                    Homework = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildProfiles", x => x.ChildProfileId);
                    table.ForeignKey(
                        name: "FK_ChildProfiles_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildProfiles_ChildId",
                table: "ChildProfiles",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildNotes_Children_ChildId",
                table: "ChildNotes",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildNotes_Notes_NoteId",
                table: "ChildNotes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "NoteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildNotes_Children_ChildId",
                table: "ChildNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildNotes_Notes_NoteId",
                table: "ChildNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "ChildProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildNotes",
                table: "ChildNotes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameTable(
                name: "ChildNotes",
                newName: "ChildNote");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_UserId",
                table: "Note",
                newName: "IX_Note_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildNotes_NoteId",
                table: "ChildNote",
                newName: "IX_ChildNote_NoteId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildNotes_ChildId",
                table: "ChildNote",
                newName: "IX_ChildNote_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildNote",
                table: "ChildNote",
                column: "ChildNoteId");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChildId = table.Column<int>(nullable: true),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ChildId",
                table: "Schedules",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildNote_Children_ChildId",
                table: "ChildNote",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildNote_Note_NoteId",
                table: "ChildNote",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "NoteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_AspNetUsers_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
