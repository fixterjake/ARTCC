using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class EventStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "EventPositions");

            migrationBuilder.AddColumn<int>(
                name: "EventPositionId",
                table: "EventRegistrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Registrations",
                table: "EventPositions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EventPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventPositionId",
                table: "EventRegistrations",
                column: "EventPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_EventPositions_EventPositionId",
                table: "EventRegistrations",
                column: "EventPositionId",
                principalTable: "EventPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_EventPositions_EventPositionId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventPositionId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventPositionId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "Registrations",
                table: "EventPositions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventPositions");

            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "EventPositions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
