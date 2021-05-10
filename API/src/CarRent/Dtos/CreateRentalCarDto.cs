﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Dtos
{
    public class CreateRentalCarDto
    {
        [Required]
        [MaxLength(40)]
        public string Brand { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Range(0, 100)]
        public float EngineCapacity { get; set; }
        public long Mileage { get; set; }
        [Range(1900, 2100)]
        public int ProductionYear { get; set; }
        [Required]
        public string VinNumber { get; set; }
        [Required]
        public float BaseRentCost { get; set; }
        [Required]
        public int RentalId { get; set; }
    }
}
