using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myData.Entities;
using myApi.Models;

namespace myApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, PersonModel>();
            CreateMap<PersonForCreationDto, PersonModel>();
            //CreateMap<PersonModel, PersonForCreationDto>().ReverseMap();
            CreateMap<PersonToBeUpdatedDto, PersonModel>();
        }
    }
}
