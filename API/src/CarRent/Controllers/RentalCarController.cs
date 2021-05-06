using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using CarRent.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRent.Controllers
{
    [ApiController]
    [Route("api/v1/cars")]
    public class RentalCarController : ControllerBase
    {

        private readonly IRentalCarRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public RentalCarController(IRentalCarRepo repo, IMapper mapper, ICarService carService)
        {
            _repository = repo;
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("Testo");
        }

        //GET api/v1/cars/{id}
        [HttpGet("{id}", Name = "GetRentalCarById")]
        public async Task<IActionResult> GetRentalCarById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var car = await _carService.GetCarById(id);
            return car != null ? (IActionResult)Ok(car) : NotFound();
        }

        //GET api/v1/cars/brand/{brandName}
        [HttpGet("brand/{brandName}")]
        public async Task<IActionResult> GetCarsByBrand([FromRoute] string brandName)
        {
            var cars = await _repository.GetCarsByBrandAsync(brandName);

            if (cars != null && cars.Count() > 0)
            {
                return Ok(cars);
            }

            return cars != null && cars.Count() > 0 ? (IActionResult)Ok(cars) : NotFound();
        }

        //POST api/v1/cars/
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateRentalCarDto addRentalCarDto)
        {
            var readRentalCarDto = await _carService.AddCar(addRentalCarDto);
            if (readRentalCarDto != null)
            {
                return CreatedAtRoute(nameof(GetRentalCarById), new { Id = readRentalCarDto.Id }, readRentalCarDto);
            }

            return BadRequest();
        }

        //DELETE api/v1/cars/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            if(await _carService.DeleteCar(id))
            {
                return NoContent();              
            }

            return NotFound();
        }

        //PUT api/v1/cars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateRentalCarDto updateRentalCarDto)
        {
            if (await _carService.UpdateCar(id, updateRentalCarDto))
            {
                return NoContent();
            }

            return NotFound();        
        }

        ////PATCH api/v1/cars/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialCarUpdate([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateRentalCarDto> patchCar)
        //{
        //    var car = _repository.GetCarById(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    var carToPatch = _mapper.Map<UpdateRentalCarDto>(car);
        //    patchCar.ApplyTo(carToPatch, ModelState);

        //    if (!TryValidateModel(carToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(carToPatch, car);

        //    _repository.UpdateCar(car);

        //    _repository.SaveChanges();

        //    return NoContent();
        //}

        ////DELETE api/v1/cars/{id}
        //[HttpDelete("{id}")]
        //public ActionResult DeleteCar([FromRoute] int id)
        //{
        //    var car = _repository.GetCarById(id);
        //    if(car == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.DeleteCar(car);
        //    _repository.SaveChanges();

        //    return NoContent();
        //}
    }
}
