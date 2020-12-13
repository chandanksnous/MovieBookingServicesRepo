using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class RemovedSeatCountFromMovieVenueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeatsCount",
                table: "MovieVenueInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeatsCount",
                table: "MovieVenueInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
