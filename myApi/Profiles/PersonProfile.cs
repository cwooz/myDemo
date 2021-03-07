using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Entities.Person, Models.PersonDto>();
            CreateMap<Entities.Person, Models.PersonForCreationDto>();
        }
    }
}
