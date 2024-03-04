using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBack.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreThen10Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonRoleMany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: true),
                    AccessLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRoleMany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRoleMany_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectAnswerExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectAnswerExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectAnswerExersiseAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    IsRightAnswer = table.Column<bool>(type: "INTEGER", nullable: false),
                    SelectAnswerExerciseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectAnswerExersiseAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectAnswerExersiseAnswers_SelectAnswerExercises_SelectAnswerExerciseId",
                        column: x => x.SelectAnswerExerciseId,
                        principalTable: "SelectAnswerExercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoleMany_PersonId",
                table: "PersonRoleMany",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectAnswerExersiseAnswers_SelectAnswerExerciseId",
                table: "SelectAnswerExersiseAnswers",
                column: "SelectAnswerExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRoleMany");

            migrationBuilder.DropTable(
                name: "SelectAnswerExersiseAnswers");

            migrationBuilder.DropTable(
                name: "SelectAnswerExercises");
        }
    }
}
