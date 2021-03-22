using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public interface IRentalCarRepo
    {
        RentalCar GetRentalCarById(int id);
    }
}
