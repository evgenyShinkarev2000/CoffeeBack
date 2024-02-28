using CoffeeBack.Data;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBack.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentKind_HealthBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("DocumentKinds", ["Id", "Name"], [KnownDocumentKind.HealthBookCopyId, KnownDocumentKind.HealthBookCopy]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("DocumentKinds", "Id", KnownDocumentKind.HealthBookCopyId);
        }
    }
}
