using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class VariousUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCid",
                table: "WebsiteLogs");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "WebsiteLogs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Before",
                table: "WebsiteLogs",
                newName: "OldData");

            migrationBuilder.RenameColumn(
                name: "After",
                table: "WebsiteLogs",
                newName: "NewData");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "WebsiteLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cid",
                table: "WebsiteLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UploadId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Certifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                table: "Certifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status",
                table: "Users",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "WebsiteLogs");

            migrationBuilder.DropColumn(
                name: "Cid",
                table: "WebsiteLogs");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "OldData",
                table: "WebsiteLogs",
                newName: "Before");

            migrationBuilder.RenameColumn(
                name: "NewData",
                table: "WebsiteLogs",
                newName: "After");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WebsiteLogs",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserCid",
                table: "WebsiteLogs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UploadId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
