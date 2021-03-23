using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class Rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "RentalCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalAddress_Number = table.Column<int>(type: "int", nullable: true),
                    RentalAddress_Letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalCars_RentalId",
                table: "RentalCars",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalCars_Rentals_RentalId",
                table: "RentalCars",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalCars_Rentals_RentalId",
                table: "RentalCars");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_RentalCars_RentalId",
                table: "RentalCars");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "RentalCars");
        }
    }
}
