using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class RentalCarsContext : DbContext
    {
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalCar> RentalCars { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public RentalCarsContext(DbContextOptions<RentalCarsContext> opt): base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>(rental =>
            {
                rental.OwnsOne(r => r.RentalAddress, ra =>
                {
                    ra.Property(p => p.City).IsRequired();
                    ra.Property(p => p.Street).IsRequired();
                    ra.Property(p => p.Number).IsRequired();
                });

                rental.Navigation(r => r.RentalAddress).IsRequired();
                
            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.OwnsOne(r => r.Address, ca =>
                {
                    ca.Property(p => p.City).IsRequired();
                    ca.Property(p => p.Street).IsRequired();
                    ca.Property(p => p.Number).IsRequired();
                });

                customer.Navigation(r => r.Address).IsRequired();

            });
        }
    }
}
