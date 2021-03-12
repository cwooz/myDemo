using myData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace myData.Services
{
    public class PersonRepository : IPersonRepository
    {
        public List<PersonDto> GetPersons()
        {
            return PersonDataStore.Current.Persons.OrderBy(p => p.Name).ToList();
        }

        public PersonDto GetPerson(int id)
        {
            return (PersonDto)PersonDataStore.Current.Persons.Where(p => p.Id == id);       // Not working, if remove casting, gives error
        }

        public void SavePerson(PersonDto person)
        {
            PersonDataStore.Current.Persons.Add(person);
        }
    }


    public class PersonDataStore
    {
        public static PersonDataStore Current { get; } = new PersonDataStore();     // Maintains working on same instance, unless restarting WebServer

        public List<PersonDto> Persons { get; set; }

        public PersonDataStore()
        {
            // init dummy data
            Persons = new List<PersonDto>()
            {
                new PersonDto()
                {
                     Id = 1,
                     Name = "John Doe",
                     Email = "doej@test.com"
                },
                new PersonDto()
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Email = "doeja@test.com"
                },
                new PersonDto()
                {
                    Id = 3,
                    Name = "Tom Smith",
                    Email = "tom.smith@test.com"
                }
            };
        }
    }
}
