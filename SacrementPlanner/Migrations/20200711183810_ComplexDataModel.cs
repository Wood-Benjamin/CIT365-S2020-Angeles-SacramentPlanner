using Microsoft.EntityFrameworkCore.Migrations;

namespace SacrementPlanner.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeakerAssignment",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false),
                    SpeakerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerAssignment", x => new { x.MeetingID, x.SpeakerID });
                    table.ForeignKey(
                        name: "FK_SpeakerAssignment_Meeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meeting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerAssignment_Speaker_SpeakerID",
                        column: x => x.SpeakerID,
                        principalTable: "Speaker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerAssignment_SpeakerID",
                table: "SpeakerAssignment",
                column: "SpeakerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeakerAssignment");
        }
    }
}
