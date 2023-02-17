using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class MiscUpdatesI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Uploads_UploadId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Uploads_BannerId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Uploads_IconId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Uploads_LogoId",
                table: "Settings");

            migrationBuilder.DropTable(
                name: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Settings_BannerId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_IconId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_LogoId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Files_UploadId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Events_UploadId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "BannerId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UploadId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UploadId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "BannerUrl",
                table: "Settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Files",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerUrl",
                table: "Events",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_Title",
                table: "Events",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_Title",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "BannerUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "BannerUrl",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "BannerId",
                table: "Settings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "Settings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Settings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UploadId",
                table: "Files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UploadId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BannerId",
                table: "Settings",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IconId",
                table: "Settings",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_LogoId",
                table: "Settings",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UploadId",
                table: "Files",
                column: "UploadId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UploadId",
                table: "Events",
                column: "UploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Uploads_UploadId",
                table: "Events",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Uploads_UploadId",
                table: "Files",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Uploads_BannerId",
                table: "Settings",
                column: "BannerId",
                principalTable: "Uploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Uploads_IconId",
                table: "Settings",
                column: "IconId",
                principalTable: "Uploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Uploads_LogoId",
                table: "Settings",
                column: "LogoId",
                principalTable: "Uploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
