using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBack.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Embed",
                table: "VideoLectures",
                newName: "Source");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Source",
                table: "VideoLectures",
                newName: "Embed");
        }
    }
}
