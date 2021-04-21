using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public interface IRentalCarRepo
    {
        Task<RentalCar> GetCarByIdAsync(int id);
        Task<IEnumerable<RentalCar>> GetCarsByBrandAsync(string brand);
        void AddCar(RentalCar car);
        bool SaveChanges();
        bool UpdateCar(RentalCar car);
        void DeleteCar(RentalCar car);
    }
}
