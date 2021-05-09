using CarRent.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<RentalCarsContext>());
            }
        }

        public static void SeedData(RentalCarsContext context)
        {
            Console.WriteLine("Applying migrations");
            context.Database.Migrate();

            if (!context.Rentals.Any())
            {
                Console.WriteLine("Adding data - retnals - seeeding");

                var rental = new Rental
                {
                    Name = "OX-RENTAL",
                    RentalAddress = new Address { City = "WARSAW", Street = "MAZOWIECKA", Number = 1 }
                };

                context.Rentals.Add(rental);
                context.SaveChanges();
            }

            if (!context.RentalCars.Any())
            {
                Console.WriteLine("Adding data - cars - seeeding");

                var retnalId = context.Rentals.FirstOrDefault();
                var car = new RentalCar
                {
                    Brand = "BMW",
                    ModelName = "M3",
                    EngineCapacity = 2.5f,
                    Mileage = 167000,
                    ProductionYear = 2004,
                    VinNumber = "EAS42RWE32123",
                    BaseRentCost = 256,
                    RentalId = retnalId?.Id ?? 0
                };

                context.RentalCars.Add(car);
                context.SaveChanges();
            }
        }
    }
}
