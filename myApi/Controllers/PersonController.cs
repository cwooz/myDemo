using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myData.Models;
using myData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet(Name = "GetPersons")]
        public IActionResult GetPersons()
        {
            var personsEntities = _personRepository.GetPersons();

            try
            {
                if (personsEntities == null)
                {
                    _logger.LogInformation($"Persons were not found.");
                    return NotFound();
                }

                return Ok(_mapper.Map<List<PersonDto>>(personsEntities));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Excection while getting a persons.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }

            //return Ok(PersonDataStore.Current.Persons);               // Direct call to In-Memory Data Store
        }


        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            //var personToReturn = PersonDataStore.Current.Persons.FirstOrDefault(p => p.Id == id);        // Direct call to In-Memory Data Store

            var personToReturn = _personRepository.GetPerson(id);

            try
            {
                if (personToReturn == null)
                {
                    _logger.LogInformation($"Person with id: {id} was not found.");
                    return NotFound();
                }

                return Ok(_mapper.Map<PersonDto>(personToReturn));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Excection while getting a person with ID: {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpPost]
        public IActionResult SavePerson([FromBody] PersonForCreationDto createdPerson)
        {
            if (createdPerson.Name == createdPerson.Email)
            {
                ModelState.AddModelError(
                    "Email",
                    "The provided email should be different than the name.");       // Placeholder, for valid email check
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var maxPersonId = PersonDataStore.Current.Persons.Max(p => p.Id);        // Direct call to In-Memory Data Store

            var personToBeAdded = new PersonDto()
            {
                Id = ++maxPersonId,
                Name = createdPerson.Name,
                Email = createdPerson.Email
            };



            //PersonDataStore.Current.Persons.Add(personToBeAdded);


            return CreatedAtRoute(
                "GetPersons",
                new { id = personToBeAdded.Id },
                personToBeAdded);



            //var personToBeAdded = _mapper.Map<Entities.Person>(createdPerson);

            //_personRepository.AddPerson(personToBeAdded);

            //_personRepository.Save();

            //var createdPersonToBeReturned = _mapper.Map<Models.PersonDto>(personToBeAdded);

            //return CreatedAtRoute(
            //    "GetPersons",
            //    new { id = createdPersonToBeReturned.Id },
            //    createdPersonToBeReturned);
        }
    }
}
