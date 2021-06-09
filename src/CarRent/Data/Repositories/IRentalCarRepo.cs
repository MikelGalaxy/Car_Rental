using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public interface IRentalCarRepo
    {
        Task<IEnumerable<RentalCar>> GetCars(int page, int pageSize);
        Task<RentalCar> GetCarByIdAsync(int id);
        Task<IEnumerable<RentalCar>> GetCarsByBrandAsync(string brand);
        Task AddCar(RentalCar car);
        Task SaveChanges();
        bool UpdateCar(RentalCar car);
        void DeleteCar(RentalCar car);
    }
}
