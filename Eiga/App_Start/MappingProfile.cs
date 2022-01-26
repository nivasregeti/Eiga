using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eiga.DTOs;
using Eiga.Models;

namespace Eiga.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDTOs>();

            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDTOs, Customer>()
                .ForMember(c => c.CustomerId, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.MovieId, opt => opt.Ignore());
        }
    }
}