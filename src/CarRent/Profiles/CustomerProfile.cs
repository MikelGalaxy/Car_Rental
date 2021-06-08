using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, ReadCustomerDto>();
        }
    }
}
