using api_to_database.Models;
using api_to_database.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_to_database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DatabasCustomersServices _databasCustomersServices;

        public BooksController(DatabasCustomersServices databasCustomersServices)
        {
            _databasCustomersServices = databasCustomersServices;
        }

        //[HttpGet]
        //public ActionResult<List<PersonModel>> Get() =>
        //    _databasCustomersServices.Get();

        [HttpGet("{firstName}")]
        public ActionResult<PersonModel> Get(string firstName)
        {
            var person = _databasCustomersServices.Get(firstName);

            if (person == null)
            {
                return NotFound("Hitta inte användaren.");
            }

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<PersonModel> Create(PersonModelDTO personModelDTO)
        {
            var model = _databasCustomersServices.Create(personModelDTO);
            return CreatedAtRoute(nameof(Get), new { id = model.Id.ToString() }, model);
        }

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, Book bookIn)
        //{
        //    var book = _databasCustomersServices.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _databasCustomersServices.Update(id, bookIn);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    var book = _databasCustomersServices.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _databasCustomersServices.Remove(book.Id);

        //    return NoContent();
        //}
    }
}
