using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Dtos
{
    public class ReadCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public float RemainingPayments { get; set; }
        public Address Address { get; set; }
    }
}
