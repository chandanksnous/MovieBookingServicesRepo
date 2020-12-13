using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class addedCustomerBookingTableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "CustomersTicketBookingHistory");

            migrationBuilder.AddColumn<int>(
                name: "MovieIDFK",
                table: "CustomersTicketBookingHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTicketBookingHistory_MovieIDFK",
                table: "CustomersTicketBookingHistory",
                column: "MovieIDFK");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTicketBookingHistory_MovieVenueInfo_MovieIDFK",
                table: "CustomersTicketBookingHistory",
                column: "MovieIDFK",
                principalTable: "MovieVenueInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTicketBookingHistory_MovieVenueInfo_MovieIDFK",
                table: "CustomersTicketBookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTicketBookingHistory_MovieIDFK",
                table: "CustomersTicketBookingHistory");

            migrationBuilder.DropColumn(
                name: "MovieIDFK",
                table: "CustomersTicketBookingHistory");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "CustomersTicketBookingHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
