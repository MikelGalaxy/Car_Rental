using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public interface IRentalCarRepo
    {
        RentalCar GetCarById(int id);
        IEnumerable<RentalCar> GetCarsByBrand(string brand);
        void AddCar(RentalCar car);
        bool SaveChanges();
        bool UpdateCar(RentalCar car);
    }
}
