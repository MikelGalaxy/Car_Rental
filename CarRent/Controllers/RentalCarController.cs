using CarRent.Data;
using CarRent.Models;
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

        public RentalCarController(IRentalCarRepo repo)
        {
            _repository = repo;
        }

        //GET api/v1/cars/2
        [HttpGet("{id}")]
        public ActionResult<RentalCar> GetRentalCar(int id)
        {
            var car = _repository.GetRentalCarById(id);
            return Ok(car);
        }
    }
}
