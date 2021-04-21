using CarRent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public interface ICarService
    {
        Task<ReadRentalCarDto> GetCarById(int id);
        Task<IEnumerable<ReadRentalCarDto>> GetCarsByBrand(string brand);
    }
}
