using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePerms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "CREATE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "UPDATE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: "DELETE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "CREATE.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: "READ.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Value",
                value: "READ.CONFIDENTIAL.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Value",
                value: "DELETE.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Value",
                value: "CREATE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Value",
                value: "VIEW.CLOSED.EVENTS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Value",
                value: "UPDATE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Value",
                value: "DELETE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Value",
                value: "CREATE.EVENT.POSITION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Value",
                value: "DELETE.EVENT.POSITION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Value",
                value: "CREATE.EVENT.REGISTRATION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Value",
                value: "VIEW.EVENT.REGISTRATIONS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Value",
                value: "ASSIGN.EVENT.REGISTRATIONS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Value",
                value: "CREATE.FAQ");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Value",
                value: "UPDATE.FAQ");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Value",
                value: "DELETE.FAQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "ARTCC.CORE.CREATE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "ARTCC.CORE.UPDATE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: "ARTCC.CORE.DELETE.AIRPORT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "ARTCC.CORE.CREATE.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: "ARTCC.CORE.READ.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Value",
                value: "ARTCC.CORE.READ.CONFIDENTIAL.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Value",
                value: "ARTCC.CORE.DELETE.COMMENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Value",
                value: "ARTCC.CORE.CREATE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Value",
                value: "ARTCC.CORE.VIEW.CLOSED.EVENTS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Value",
                value: "ARTCC.CORE.UPDATE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Value",
                value: "ARTCC.CORE.DELETE.EVENT");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Value",
                value: "ARTCC.CORE.CREATE.EVENT.POSITION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Value",
                value: "ARTCC.CORE.DELETE.EVENT.POSITION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Value",
                value: "ARTCC.CORE.CREATE.EVENT.REGISTRATION");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Value",
                value: "ARTCC.CORE.VIEW.EVENT.REGISTRATIONS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Value",
                value: "ARTCC.CORE.ASSIGN.EVENT.REGISTRATIONS");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Value",
                value: "ARTCC.CORE.CREATE.FAQ");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Value",
                value: "ARTCC.CORE.UPDATE.FAQ");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Value",
                value: "ARTCC.CORE.DELETE.FAQ");
        }
    }
}
