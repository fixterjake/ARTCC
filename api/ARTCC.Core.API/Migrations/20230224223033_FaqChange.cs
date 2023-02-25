using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class FaqChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fact",
                table: "Faq",
                newName: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Faq",
                newName: "Fact");
        }
    }
}
