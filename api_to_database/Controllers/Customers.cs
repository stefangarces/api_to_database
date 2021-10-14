using api_to_database.Models;
using api_to_database.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace api_to_database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DatabasCustomersServices _databasCustomersServices;

        public CustomersController(DatabasCustomersServices databasCustomersServices)
        {
            _databasCustomersServices = databasCustomersServices;
        }

        [HttpGet]
        public ActionResult<List<PersonModel>> Get() =>
            _databasCustomersServices.Get();


        [HttpGet("{socialSecurityNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PersonModelDTO>> Get(string socialSecurityNumber)
        {
            var person = _databasCustomersServices.Get(socialSecurityNumber);

            if (person == null)
            {
                return NotFound("Hitta inte användaren.");
            }

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonModel> Create(PersonModelDTO personModelDTO)
        {
            var model = _databasCustomersServices.Create(personModelDTO);
            return CreatedAtRoute(nameof(Get), new { id = model.Id.ToString() }, model);
        }

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<PersonModelDTO>> Pi(PersonModel personModel)
        //{
        //    var model = _databasCustomersServices.Update(personModel);
        //    return CreatedAtRoute(nameof(Remove), new { id = model.Id.ToString() }, model);

        //    var person = _databasCustomersServices.Get(socialSecurityNumber);

        //    if (person == null)
        //    {
        //        return NotFound("Hitta inte användaren.");
        //    }

        //    return Ok(person);
        //}
    }
}
