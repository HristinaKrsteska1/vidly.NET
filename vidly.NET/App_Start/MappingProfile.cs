using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.NET.Dtos;
using vidly.NET.Models;

namespace vidly.NET.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

        }
    }
}