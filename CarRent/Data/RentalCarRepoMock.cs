﻿using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public class RentalCarRepoMock : IRentalCarRepo
    {
        private List<RentalCar> rentalCars = new List<RentalCar> {
            new RentalCar() { Id = 1, Brand = "Ford", ModelName = "Fiesta", ProductionYear = 2002, BaseRentCost = 200 },
            new RentalCar() { Id = 2, Brand = "BMW", ModelName = "M3", ProductionYear = 2002, BaseRentCost = 500 }};
        public RentalCar GetRentalCarById(int id)
        {
            return rentalCars.FirstOrDefault(c=>c.Id == id);
        }
    }
}
