using myApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApi.Services
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();

        Person GetPerson(int id);

        void AddPerson(Person person);

        //void UpdatePerson(int id, Person person);

        //void DeletePerson(Person person);
    }
}
