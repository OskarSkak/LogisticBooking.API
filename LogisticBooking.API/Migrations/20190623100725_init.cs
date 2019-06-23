using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticBooking.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    InternalId = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<int>(nullable: false),
                    TotalPallets = table.Column<int>(nullable: false),
                    BookingTime = table.Column<DateTime>(nullable: false),
                    TransporterName = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    ActualArrival = table.Column<DateTime>(nullable: false),
                    StartLoading = table.Column<DateTime>(nullable: false),
                    EndLoading = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    TransporterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.InternalId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transporters",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UtilBookings",
                columns: table => new
                {
                    bookingid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilBookings", x => x.bookingid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TotalPallets = table.Column<int>(nullable: false),
                    BottomPallets = table.Column<int>(nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    BookingId = table.Column<Guid>(nullable: false),
                    CustomerNumber = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    WareNumber = table.Column<int>(nullable: false),
                    InOut = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookingId",
                table: "Orders",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Transporters");

            migrationBuilder.DropTable(
                name: "UtilBookings");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
