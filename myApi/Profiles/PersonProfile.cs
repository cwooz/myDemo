using AutoMapper;
using myData.Entities;
using myApi.Models;

namespace myApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, PersonModel>().ReverseMap();
            //CreateMap<PersonForCreationDto, PersonModel>();
            //CreateMap<PersonToBeUpdatedDto, PersonModel>();
        }
    }
}
