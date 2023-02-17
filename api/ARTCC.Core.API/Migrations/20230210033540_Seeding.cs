using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registrations",
                table: "EventPositions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventPositions");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventRegistrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "EventPositions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "ARTCC.CORE.CREATE.AIRPORT" },
                    { 2, "ARTCC.CORE.UPDATE.AIRPORT" },
                    { 3, "ARTCC.CORE.DELETE.AIRPORT" },
                    { 4, "ARTCC.CORE.CREATE.COMMENT" },
                    { 5, "ARTCC.CORE.READ.COMMENT" },
                    { 6, "ARTCC.CORE.READ.CONFIDENTIAL.COMMENT" },
                    { 7, "ARTCC.CORE.DELETE.COMMENT" },
                    { 8, "ARTCC.CORE.CREATE.EVENT" },
                    { 9, "ARTCC.CORE.VIEW.CLOSED.EVENTS" },
                    { 10, "ARTCC.CORE.UPDATE.EVENT" },
                    { 11, "ARTCC.CORE.DELETE.EVENT" },
                    { 12, "ARTCC.CORE.CREATE.EVENT.POSITION" },
                    { 13, "ARTCC.CORE.DELETE.EVENT.POSITION" },
                    { 14, "ARTCC.CORE.CREATE.EVENT.REGISTRATION" },
                    { 15, "ARTCC.CORE.VIEW.EVENT.REGISTRATIONS" },
                    { 16, "ARTCC.CORE.ASSIGN.EVENT.REGISTRATIONS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Email", "IsStaff", "Name", "NameShort", "Priority" },
                values: new object[,]
                {
                    { 1, "atm@test.com", true, "Air Traffic Manager", "ATM", 1 },
                    { 2, "datm@test.com", true, "Deputy Air Traffic Manager", "DATM", 2 },
                    { 3, "ta@test.com", true, "Training Administrator", "TA", 3 },
                    { 4, "ata@test.com", true, "Assistant Training Administrator", "ATA", 4 },
                    { 5, "wm@test.com", true, "Webmaster", "WM", 5 },
                    { 6, "awm@test.com", true, "Assistant Webmaster", "AWM", 6 },
                    { 7, "ec@test.com", true, "Events Coordinator", "EC", 7 },
                    { 8, "aec@test.com", true, "Assistant Events Coordinator", "AEC", 8 },
                    { 9, "fe@test.com", true, "Facility Engineer", "FE", 9 },
                    { 10, "afe@test.com", true, "Assistant Facility Engineer", "AFE", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "EventPositions");

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
        }
    }
}
