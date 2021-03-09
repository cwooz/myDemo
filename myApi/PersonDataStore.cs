using myApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApi
{
    public class PersonDataStore
    {
        public static PersonDataStore Current { get; } = new PersonDataStore();     // Maintains working on same instance, unless restarting WebServer

        public List<PersonDto> Persons { get; set; }

        //public void Add<PersonDto> (personToBeAdded);

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
