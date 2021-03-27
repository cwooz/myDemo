using AutoMapper;
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
