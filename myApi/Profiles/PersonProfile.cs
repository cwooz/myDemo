using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myData.Models;
using myApi.Models;

namespace myApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<myData.Models.PersonDto, myApi.Models.PersonModel>();
            CreateMap<myApi.Models.PersonModel, myData.Models.PersonForCreationDto>();
        }
    }
}
