using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidli.Dtos;
using Vidli.Models;

namespace Vidli.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Customer DTO
            Mapper.CreateMap<CustomerModel, CustomerReadOnlyDto>(); // Domain to Dto - READONLY
            Mapper.CreateMap<CustomerModel, CustomerDto>(); // Domain to Dto
            Mapper.CreateMap<CustomerDto, CustomerModel>() // Dto to Domain
                .ForMember(c => c.Id, opt => opt.Ignore());
                // A Dto should ignore the id of update/put request.

            // Movies DTO
            Mapper.CreateMap<MovieModel, MovieDto>(); // Domain to dto
            Mapper.CreateMap<MovieDto, MovieModel>() // Dto to Domain
                .ForMember(m => m.Id, opt => opt.Ignore());
                // A Dto should ignore the id of update/put request.

            // Membership DTO
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Genre DTO
            Mapper.CreateMap<Genre, GenreDto>();

            // Rental DTO
            Mapper.CreateMap<RentalModel, RentalDto>();
            Mapper.CreateMap<RentalDto, RentalModel>();
        }
    }
}