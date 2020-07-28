using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourVillage.Migrations
{
    public partial class CaregiverFamilies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caregivers",
                columns: table => new
                {
                    CaregiverId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caregivers", x => x.CaregiverId);
                });

            migrationBuilder.CreateTable(
                name: "CaregiverFamilies",
                columns: table => new
                {
                    CaregiverFamilyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CaregiverId = table.Column<string>(nullable: true),
                    FamilyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverFamilies", x => x.CaregiverFamilyId);
                    table.ForeignKey(
                        name: "FK_CaregiverFamilies_Caregivers_CaregiverId",
                        column: x => x.CaregiverId,
                        principalTable: "Caregivers",
                        principalColumn: "CaregiverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaregiverFamilies_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverFamilies_CaregiverId",
                table: "CaregiverFamilies",
                column: "CaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverFamilies_FamilyId",
                table: "CaregiverFamilies",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaregiverFamilies");

            migrationBuilder.DropTable(
                name: "Caregivers");
        }
    }
}
