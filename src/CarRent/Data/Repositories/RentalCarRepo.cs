using CarRent.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public class RentalCarRepo : IRentalCarRepo
    {
        private readonly RentalCarsContext _context;

        public RentalCarRepo(RentalCarsContext context)
        {
            _context = context;
        }

        public async Task AddCar(RentalCar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            await _context.RentalCars.AddAsync(car);
        }

        public void DeleteCar(RentalCar car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.RentalCars.Remove(car);
        }

        public async Task<RentalCar> GetCarByIdAsync(int id)
        {
            return await _context.RentalCars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<RentalCar>> GetCarsByBrandAsync(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentNullException(nameof(brand));
            }

            using (IDbConnection connection = new SqlConnection(Startup.ConnectionString))
            {
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                return await connection.QueryAsync<RentalCar>($"select * from RentalCars where Brand = '{brand}'");
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public bool UpdateCar(RentalCar car)
        {
            //EF handle it
            return true;
        }
    }
}
