using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticBooking.API.Migrations
{
    public partial class init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SecondaryBookingId",
                table: "Intervals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryBookingId",
                table: "Intervals");
        }
    }
}
