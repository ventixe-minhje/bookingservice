using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingAdresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAdresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingOwner",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingAdressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingOwner_BookingAdresses_BookingAdressId",
                        column: x => x.BookingAdressId,
                        principalTable: "BookingAdresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketQuantity = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingOwner_BookingOwnerId",
                        column: x => x.BookingOwnerId,
                        principalTable: "BookingOwner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingOwner_BookingAdressId",
                table: "BookingOwner",
                column: "BookingAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingOwnerId",
                table: "Bookings",
                column: "BookingOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingOwner");

            migrationBuilder.DropTable(
                name: "BookingAdresses");
        }
    }
}
