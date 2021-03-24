using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PESEL { get; set; }
        public float RemainingPayments { get; set; }
        public Address Address { get; set; }
        public ICollection<RentalCar> RentedCars { get; set; }
    }
}
