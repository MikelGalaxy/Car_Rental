using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Controllers
{
    [ApiController]
    [Route("api/v1/cars")]
    public class RentalCarController : ControllerBase
    {
        private readonly IRentalCarRepo _repository;
        private readonly IMapper _mapper;

        public RentalCarController(IRentalCarRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        //GET api/v1/cars/{id}
        [HttpGet("{id}", Name = "GetRentalCarById")]
        public ActionResult<ReadRentalCarDto> GetRentalCarById(int id)
        {
            var car = _repository.GetCarById(id);

            if (car != null)
            {
                return Ok(_mapper.Map<ReadRentalCarDto>(car));
            }

            return NotFound();
        }

        //GET api/v1/cars/brand/{brandName}
        [HttpGet("brand/{brandName}")]
        public ActionResult<IEnumerable<ReadRentalCarDto>> GetCarsByBrand(string brandName)
        {
            var cars = _repository.GetCarsByBrand(brandName);

            if (cars != null && cars.Count() > 0)
            {
                return Ok(_mapper.Map<IEnumerable<ReadRentalCarDto>>(cars));
            }

            return NotFound();
        }

        //POST api/v1/cars/
        [HttpPost]
        public ActionResult<ReadRentalCarDto> AddCar(CreateRentalCarDto addRentalCarDto)
        {
            var rentalCar = _mapper.Map<RentalCar>(addRentalCarDto);

            if (rentalCar != null)
            {
                _repository.AddCar(rentalCar);
                _repository.SaveChanges();

                var readRentalCarDto = _mapper.Map<ReadRentalCarDto>(rentalCar);

                return CreatedAtRoute(nameof(GetRentalCarById), new { Id = readRentalCarDto.Id }, readRentalCarDto);
            }

            return BadRequest();
        }

        //PUT api/v1/cars/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, UpdateRentalCarDto updateRentalCarDto)
        {
            var car = _repository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            _mapper.Map(updateRentalCarDto, car);

            _repository.UpdateCar(car);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/v1/cars/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCarUpdate(int id, JsonPatchDocument<UpdateRentalCarDto> patchCar)
        {
            var car = _repository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            var carToPatch = _mapper.Map<UpdateRentalCarDto>(car);
            patchCar.ApplyTo(carToPatch, ModelState);

            if (!TryValidateModel(carToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(carToPatch, car);

            _repository.UpdateCar(car);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/v1/cars/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var car = _repository.GetCarById(id);
            if(car == null)
            {
                return NotFound();
            }

            _repository.DeleteCar(car);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
