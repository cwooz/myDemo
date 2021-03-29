using myData.Entities;
using System.Collections.Generic;

namespace myData.Services
{
    public interface IPersonRepository
    {
        List<PersonDto> GetPersons();

        PersonDto GetPerson(int id);

        void SavePerson(PersonDto person);

        void UpdatePerson(int id, PersonDto person, PersonDto updatedPerson);

        void DeletePerson(PersonDto person);

        bool PersonExists(int id);
    }
}
