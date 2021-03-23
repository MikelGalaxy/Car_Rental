using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class RentalCarsContext : DbContext
    {
        public RentalCarsContext(DbContextOptions<RentalCarsContext> opt): base(opt)
        {

        }

        public DbSet<Rental> Rentals { get; set; }


        public DbSet<RentalCar> RentalCars { get; set; }

    }
}
