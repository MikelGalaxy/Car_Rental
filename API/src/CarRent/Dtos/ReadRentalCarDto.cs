using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Dtos
{
    public class ReadRentalCarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public float EngineCapacity { get; set; }
        public long Mileage { get; set; }
        public int ProductionYear { get; set; }
        public string VinNumber { get; set; }
        public float BaseRentCost { get; set; }
    }
}
