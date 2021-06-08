using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
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
        private readonly ILoggingService _logger;

        public CarService(IRentalCarRepo repo, IMapper mapper, ILoggingService logger)
        {
            _repository = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ReadRentalCarDto> GetCarById(int id)
        {
            var foundCar = await _repository.GetCarByIdAsync(id);

            if (foundCar == null)
            {
                //car not found
                _logger.LoggMessage($"Car with id: {id} was not found.");
                return null;
            }

            _logger.LoggMessage($"Car with id: {id} was found.");
            return _mapper.Map<ReadRentalCarDto>(foundCar);
        }

        public async Task<IEnumerable<ReadRentalCarDto>> GetCarsByBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                _logger.LoggMessage("Can't get cars without brand name");
                throw new ArgumentNullException(nameof(brand));
            }

            var normalizedBrand = brand.ToUpper().Trim();
            var foundCars = await _repository.GetCarsByBrandAsync(normalizedBrand);

            if (foundCars == null || foundCars.Count() == 0)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<ReadRentalCarDto>>(foundCars);
        }

        public async Task<ReadRentalCarDto> AddCar(CreateRentalCarDto car)
        {
            var rentalCar = _mapper.Map<RentalCar>(car);

            if (rentalCar != null)
            {
                await _repository.AddCar(CapitalizeCarValues(rentalCar));
                await _repository.SaveChanges();

                var readRentalCarDto = _mapper.Map<ReadRentalCarDto>(rentalCar);

                return readRentalCarDto;
            }

            return null;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await _repository.GetCarByIdAsync(id);
            if (car == null)
            {
                _logger.LoggMessage($"Car with id: {id} was not found. Couldn't delete.");
                return false;
            }

            _repository.DeleteCar(car);
            await _repository.SaveChanges();

            _logger.LoggMessage($"Car with id: {id} was deleted.");

            return true;
        }

        public async Task<bool> UpdateCar(int id, UpdateRentalCarDto toUpdate)
        {
            var foundCar = await _repository.GetCarByIdAsync(id);

            if(foundCar == null)
            {
                _logger.LoggMessage($"Car with id: {id} was not found. Couldn't update.");
                return false;
            }

            _mapper.Map(toUpdate, foundCar);
            _repository.UpdateCar(foundCar);
            await _repository.SaveChanges();

            _logger.LoggMessage($"Car with id: {id} was updated.");

            return true;
        }

        private RentalCar CapitalizeCarValues(RentalCar car)
        {
            if(car == null)
            {
                var ex = new ArgumentNullException(nameof(car));
                _logger.LoggMessage("Can't capitalize null car", ex);
                throw ex;
            }

            car.Brand = car.Brand?.ToUpper().Trim();
            car.ModelName = car.ModelName?.ToUpper().Trim();
            car.VinNumber = car.VinNumber?.ToUpper().Trim();

            return car;
        }


    }
}
