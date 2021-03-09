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
            return (IEnumerable<Person>)PersonDataStore.Current.Persons.OrderBy(p => p.Name).ToList();
        }

        public Person GetPerson(int id)
        {
            //return PersonDataStore.Current.Persons.Where(p => p.Id == id).FirstOrDefault();

            throw new NotImplementedException();
        }

        public void AddPerson(Person person)
        {
            //PersonDataStore.Current.Persons.Add(person);

            throw new NotImplementedException();
        }

        //public void UpdatePerson(int id, Person person)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeletePerson(Person person)
        //{
        ////    PersonDataStore.Current.Persons.Remove(person);
        //
        //    throw new NotImplementedException();
        //}
    }
}
