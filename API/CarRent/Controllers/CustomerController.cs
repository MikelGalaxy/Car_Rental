using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/v1/customers/{id}
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<ReadCustomerDto> GetCustomerById(int id)
        {
            var cuustomer = _repository.GetCustomerById(id);

            if (cuustomer != null)
            {
                return Ok(_mapper.Map<ReadCustomerDto>(cuustomer));
            }

            return NotFound();
        }
    }
}
