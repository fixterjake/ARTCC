using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class AddFaqOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Faq",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Faq");
        }
    }
}
