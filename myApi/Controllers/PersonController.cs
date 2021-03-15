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
        }


        [HttpPost]
        public IActionResult SavePerson([FromBody] PersonDto createdPerson)
        {
            if (createdPerson.Name == createdPerson.Email)
            {
                ModelState.AddModelError(
                    "Email",
                    "The provided email should be different than the name.");       // Placeholder, for valid email check
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Unable to ADD new Person with the Name: {createdPerson.Name}, and Email: {createdPerson.Email}.");
                return BadRequest();
            }

            var maxPersonId = PersonDataStore.Current.Persons.Max(p => p.Id);        // Direct call to In-Memory Data Store
            createdPerson.Id = ++maxPersonId;                                        // To Increment ID for NEW Person

            var personToBeAdded = _mapper.Map<PersonDto>(createdPerson);

            _personRepository.SavePerson(personToBeAdded);


            _logger.LogInformation($"ADDED NEW Person with ID: {personToBeAdded.Id}, Name: {personToBeAdded.Name}, and Email: {personToBeAdded.Email}.");
            return CreatedAtRoute(
                "GetPersons", personToBeAdded);
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] PersonDto personToBeUpdated)
        {
            if (personToBeUpdated.Name == personToBeUpdated.Email)
            {
                ModelState.AddModelError(
                    "Email",
                    "The provided email should be different than the name.");       // Placeholder, for valid email check
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Unable to UPDATE Person [{id}] with the Name: {personToBeUpdated.Name}, and Email: {personToBeUpdated.Email}.");
                return BadRequest();
            }

            var personExists = _personRepository.PersonExists(id);

            try
            {
                if (!personExists)
                {
                    _logger.LogInformation($"Person with id: {id} was not found.");
                    return NotFound();
                }

                var personBeingUpdated = _personRepository.GetPerson(id);

                personBeingUpdated.Name = personToBeUpdated.Name;
                personBeingUpdated.Email = personToBeUpdated.Email;

                //_mapper.Map(personToBeUpdated, personBeingUpdated);
                //_personRepository.UpdatePerson(id, personBeingUpdated);

                _logger.LogInformation($"UPDATED: Person with the ID: {id}");
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a person with ID: {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
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
