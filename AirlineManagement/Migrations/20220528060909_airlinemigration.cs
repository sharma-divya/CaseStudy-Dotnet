using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineManagement.Migrations
{
    public partial class airlinemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineDetails",
                columns: table => new
                {
                    AirlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    DiscountCode = table.Column<string>(nullable: true),
                    DiscountAmount = table.Column<double>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineDetails", x => x.AirlineId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNo = table.Column<string>(nullable: true),
                    AirlineId = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: true),
                    PlaceFrom = table.Column<string>(nullable: true),
                    PlaceTo = table.Column<string>(nullable: true),
                    BusinessClassSeats = table.Column<int>(nullable: false),
                    NonBusinessClassSeats = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    Rows = table.Column<int>(nullable: false),
                    Meal = table.Column<string>(nullable: true),
                    ScheduleDays = table.Column<string>(nullable: true),
                    InstrumentUsed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_FlightDetails_AirlineDetails_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "AirlineDetails",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_AirlineId",
                table: "FlightDetails",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "AirlineDetails");
        }
    }
}
