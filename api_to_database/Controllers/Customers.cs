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


        [HttpPut("{socialSecurityNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(PersonModelUpdateDTO PersonModelUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new personDBtable())
            {
                var existingPerson = ctx.Students.Where(s => s.StudentID == student.Id)
                                                        .FirstOrDefault<PersonModelUpdateDTO>();

                if (existingPerson != null)
                {
                    existingPerson.FirstName = PersonModelUpdateDTO.Email;
                    existingPerson.LastName = PersonModelUpdateDTO.SwishNumber;
                    existingPerson.LastName = PersonModelUpdateDTO.Address;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
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
