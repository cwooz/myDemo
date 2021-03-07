﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApi.Models;
using myApi.Services;
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
        //private readonly IPersonRepository _personRepository;
        //private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger)
        //public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet(Name = "GetPersons")]
        public IActionResult GetPersons()
        {
            return Ok(PersonDataStore.Current.Persons);               // Call to In-Memory Data Store
        }


        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var personToReturn = PersonDataStore.Current.Persons.FirstOrDefault(c => c.Id == id);        // Call to In-Memory Data Store

            try
            {
                if (personToReturn == null)
                {
                    _logger.LogInformation($"Person with id: {id} was not found.");
                    return NotFound();
                }

                return Ok(personToReturn);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Excection while getting a person with ID: {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonForCreationDto createdPerson)
        {
            if (createdPerson.Email == createdPerson.Name)
            {
                ModelState.AddModelError(
                    "Email",
                    "The provided email should be different than the name.");       // Placeholder, for valid email check
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }



            //     ?????       Calculate max ID in DataStore & increment by 1



            //var personToBeAdded = _mapper.Map<Entities.Person>(createdPerson);

            //_personRepository.AddPerson(personToBeAdded);

            //_personRepository.Save();

            //var createdPersonToBeReturned = _mapper.Map<Models.PersonDto>(personToBeAdded);

            //return CreatedAtRoute(
            //    "GetPersons",
            //    new { id = createdPersonToBeReturned.Id },
            //    createdPersonToBeReturned);
            return Ok();
        }
    }
}