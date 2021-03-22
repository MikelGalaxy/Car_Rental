using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class RentalCar : Car
    {
        [Required]
        public float BaseRentCost { get; set; }
    }
}
