using myApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApi.Services
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository()
        {
            //
        }

        public IEnumerable<Person> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        //public void UpdatePerson(int id, Person person)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeletePerson(Person person)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool PersonExists(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
