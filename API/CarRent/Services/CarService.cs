using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public class CarService : ICarService
    {
        private readonly IRentalCarRepo _repository;
        private readonly IMapper _mapper;

        public CarService(IRentalCarRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public async Task<ReadRentalCarDto> GetCarById(int id)
        {
            var foundCar = await _repository.GetCarByIdAsync(id);
            
            if(foundCar == null)
            {
                //car not found
                return null;
            }

            return _mapper.Map<ReadRentalCarDto>(foundCar);
        }

        public async Task<IEnumerable<ReadRentalCarDto>> GetCarsByBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentNullException(nameof(brand));
            }

            var normalizedBrand = brand.ToUpper().Trim();
            var foundCars = await _repository.GetCarsByBrandAsync(normalizedBrand);

            if(foundCars == null || foundCars.Count() == 0)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<ReadRentalCarDto>>(foundCars);
        }
    }
}
