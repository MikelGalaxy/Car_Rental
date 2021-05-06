using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Address RentalAddress { get; set; }

        public ICollection<RentalCar> Cars { get; set; }
    }
}
