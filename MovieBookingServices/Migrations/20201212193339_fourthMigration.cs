using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "MovieVenueInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(nullable: true),
                    MovieLanguage = table.Column<string>(nullable: true),
                    MovieType = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    MultiplexName = table.Column<string>(nullable: true),
                    AvailableSeatsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVenueInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieVenueInfo");

            migrationBuilder.CreateTable(
                name: "MoviesInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesInfo", x => x.ID);
                });
        }
    }
}
