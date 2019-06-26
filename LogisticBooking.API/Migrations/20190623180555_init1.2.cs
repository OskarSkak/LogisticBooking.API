using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticBooking.API.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false),
                    ScheduleDay = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    MischellaneousPallets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Intervals",
                columns: table => new
                {
                    IntervalId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsBooked = table.Column<bool>(nullable: false),
                    BottomPallets = table.Column<int>(nullable: false),
                    BookingId = table.Column<Guid>(nullable: false),
                    TransporterId = table.Column<Guid>(nullable: false),
                    RemainingPallets = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervals", x => x.IntervalId);
                    table.ForeignKey(
                        name: "FK_Intervals_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervals_ScheduleId",
                table: "Intervals",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervals");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
