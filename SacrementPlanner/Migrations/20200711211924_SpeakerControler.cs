using Microsoft.EntityFrameworkCore.Migrations;

namespace SacrementPlanner.Migrations
{
    public partial class SpeakerControler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingID",
                table: "Speaker",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker",
                column: "MeetingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "MeetingID",
                table: "Speaker");
        }
    }
}
