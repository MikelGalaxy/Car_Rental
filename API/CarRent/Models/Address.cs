using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public string City { get; set; }
    }
}
