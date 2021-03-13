using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myData.Entities;
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
                    _logger.LogInformation("Persons were not found.");
                    return NotFound();
                }

                _logger.LogInformation("Returned list of all Persons.");
                return Ok(_mapper.Map<List<PersonDto>>(personsEntities));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting a persons.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }

            //return Ok(PersonDataStore.Current.Persons);               // Direct call to In-Memory Data Store
        }


        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var personToReturn = _personRepository.GetPerson(id);

            try
            {
                if (personToReturn == null)
                {
                    _logger.LogInformation($"Person with id: {id} was not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Returned an individual Person with ID: {personToReturn.Id}, Name: {personToReturn.Name}, and Email: {personToReturn.Email}.");
                return Ok(_mapper.Map<PersonDto>(personToReturn));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a person with ID: {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }

            //var personToReturn = PersonDataStore.Current.Persons.FirstOrDefault(p => p.Id == id);        // Direct call to In-Memory Data Store
            //return Ok(personToReturn);
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

            _personRepository.SavePerson(personToBeAdded);


            _logger.LogInformation($"Added NEW Person with the ID: {personToBeAdded.Id}, Name: {personToBeAdded.Name}, and Email: {personToBeAdded.Email}.");
            return CreatedAtRoute(
                "GetPersons",
                new { id = personToBeAdded.Id },
                personToBeAdded);



            //var personToBeAdded = _mapper.Map<Entities.PersonDto>(createdPerson);

            //_personRepository.SavePerson(personToBeAdded);

            //var createdPersonToBeReturned = _mapper.Map<Models.PersonModel>(personToBeAdded);

            //return CreatedAtRoute(
            //    "GetPersons",
            //    new { id = createdPersonToBeReturned.Id },
            //    createdPersonToBeReturned);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var personExists = _personRepository.PersonExists(id);

            try
            {
                if (!personExists)
                {
                    _logger.LogInformation($"Person with id: {id} was not found.");
                    return NotFound();
                }

                var personToBeDeleted = _personRepository.GetPerson(id);

                _personRepository.DeletePerson(personToBeDeleted);

                _logger.LogInformation($"DELETED: Person with the ID: {id}");
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a person with ID: {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}
