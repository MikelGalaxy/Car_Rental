using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseRentCost = table.Column<float>(type: "real", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCapacity = table.Column<float>(type: "real", nullable: false),
                    Mileage = table.Column<long>(type: "bigint", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalCars");
        }
    }
}
