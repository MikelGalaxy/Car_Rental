using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Profiles
{
    public class RentalCarProfile : Profile
    {
        public RentalCarProfile()
        {
            CreateMap<RentalCar, ReadRentalCarDto>();
            CreateMap<CreateRentalCarDto, RentalCar>();

            CreateMap<UpdateRentalCarDto, RentalCar>();
            CreateMap<RentalCar, UpdateRentalCarDto>();
        }
    }
}
