using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    /// <inheritdoc />
    public partial class Training : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SetupDone",
                table: "Settings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TrainingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SubmitterId = table.Column<int>(type: "integer", nullable: false),
                    InstructorId = table.Column<int>(type: "integer", nullable: true),
                    TrainingRequestId = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Facility = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ots_TrainingRequests_TrainingRequestId",
                        column: x => x.TrainingRequestId,
                        principalTable: "TrainingRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ots_Users_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ots_Users_SubmitterId",
                        column: x => x.SubmitterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ots_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    TrainingRequestId = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Facility = table.Column<string>(type: "text", nullable: false),
                    Performance = table.Column<int>(type: "integer", nullable: false),
                    UserNotes = table.Column<string>(type: "text", nullable: false),
                    TrainingNotes = table.Column<string>(type: "text", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingTickets_TrainingRequests_TrainingRequestId",
                        column: x => x.TrainingRequestId,
                        principalTable: "TrainingRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingTickets_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ots_InstructorId",
                table: "Ots",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ots_Position",
                table: "Ots",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Ots_Status",
                table: "Ots",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Ots_SubmitterId",
                table: "Ots",
                column: "SubmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ots_TrainingRequestId",
                table: "Ots",
                column: "TrainingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Ots_UserId",
                table: "Ots",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequests_Start",
                table: "TrainingRequests",
                column: "Start");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequests_Status",
                table: "TrainingRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequests_UserId",
                table: "TrainingRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTickets_Performance",
                table: "TrainingTickets",
                column: "Performance");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTickets_Position",
                table: "TrainingTickets",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTickets_TrainerId",
                table: "TrainingTickets",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTickets_TrainingRequestId",
                table: "TrainingTickets",
                column: "TrainingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTickets_UserId",
                table: "TrainingTickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ots");

            migrationBuilder.DropTable(
                name: "TrainingTickets");

            migrationBuilder.DropTable(
                name: "TrainingRequests");

            migrationBuilder.DropColumn(
                name: "SetupDone",
                table: "Settings");
        }
    }
}
