using myData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Services
{
    public interface IPersonRepository
    {
        List<PersonDto> GetPersons();

        PersonDto GetPerson(int id);

        void SavePerson(PersonDto person);

        void UpdatePerson(int id, PersonDto person);

        void DeletePerson(PersonDto person);

        bool PersonExists(int id);
    }
}
