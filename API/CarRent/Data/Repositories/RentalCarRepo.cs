using CarRent.Models;
using System;
using System.Collections.Generic;
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

        public void AddCar(RentalCar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.RentalCars.Add(car);
        }

        public void DeleteCar(RentalCar car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.RentalCars.Remove(car);
        }

        public RentalCar GetCarById(int id)
        {
            return _context.RentalCars.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<RentalCar> GetCarsByBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentNullException(nameof(brand));
            }

            return _context.RentalCars.Where(c => c.Brand.ToLower().Equals(brand.ToLower()));
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCar(RentalCar car)
        {
            //EF handle it
            return true;
        }
    }
}
