﻿using AutoMapper;
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
            //Domain to dto
            Mapper.CreateMap<Customer, CustomerDTO>();          
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDTO, Customer>()
               .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>()
               .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}