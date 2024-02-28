using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBack.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTextLecture",
                columns: table => new
                {
                    CompleatedTextLecturesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LearnedPeopleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTextLecture", x => new { x.CompleatedTextLecturesId, x.LearnedPeopleId });
                    table.ForeignKey(
                        name: "FK_PersonTextLecture_People_LearnedPeopleId",
                        column: x => x.LearnedPeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTextLecture_TextLectures_CompleatedTextLecturesId",
                        column: x => x.CompleatedTextLecturesId,
                        principalTable: "TextLectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonVideoLecture",
                columns: table => new
                {
                    CompleatedVideoLecturesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LearnedPeopleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVideoLecture", x => new { x.CompleatedVideoLecturesId, x.LearnedPeopleId });
                    table.ForeignKey(
                        name: "FK_PersonVideoLecture_People_LearnedPeopleId",
                        column: x => x.LearnedPeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVideoLecture_VideoLectures_CompleatedVideoLecturesId",
                        column: x => x.CompleatedVideoLecturesId,
                        principalTable: "VideoLectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTextLecture_LearnedPeopleId",
                table: "PersonTextLecture",
                column: "LearnedPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVideoLecture_LearnedPeopleId",
                table: "PersonVideoLecture",
                column: "LearnedPeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTextLecture");

            migrationBuilder.DropTable(
                name: "PersonVideoLecture");
        }
    }
}
