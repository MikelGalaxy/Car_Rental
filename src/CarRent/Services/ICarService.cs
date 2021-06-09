using CarRent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public interface ICarService
    {
        Task<IEnumerable<ReadRentalCarDto>> GetCars(int page, int pageSize);
        Task<ReadRentalCarDto> GetCarById(int id);
        Task<IEnumerable<ReadRentalCarDto>> GetCarsByBrand(string brand);
        Task<ReadRentalCarDto> AddCar(CreateRentalCarDto car);
        Task<bool> DeleteCar(int id);
        Task<bool> UpdateCar(int id, UpdateRentalCarDto toUpdate);
    }
}
