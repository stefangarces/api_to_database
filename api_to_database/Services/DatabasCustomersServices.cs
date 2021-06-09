using api_to_database.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace api_to_database.Services
{
    public class DatabasCustomersServices
    {
        private readonly IMongoCollection<PersonModel> _PersonModel;

        public DatabasCustomersServices(IDatabaseCustomersSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _PersonModel = database.GetCollection<PersonModel>(settings.CustomersCollection);
        }

        //public List<PersonModel> Get() =>
        //    _PersonModel.Find(_ => true).ToList();

        public List<PersonModel> Get(string FirstName) =>
            _PersonModel.Find(p => p.FirstName.ToString() == FirstName).ToList();

        //public PersonModel Get(string id) =>
        //    _PersonModel.Find<PersonModel>(book => book.Id == id).FirstOrDefault();

        public PersonModel Create(PersonModelDTO personModelDTO)
        {
            PersonModel personModel = new PersonModel()
            {
                FirstName = personModelDTO.FirstName,
                LastName = personModelDTO.LastName,
                Address = personModelDTO.Address,
                DateOfBirth = personModelDTO.DateOfBirth
            };
            _PersonModel.InsertOne(personModel);
            return personModel;
        }

        //public void Update(string id, PersonModel personModel) =>
        //    _PersonModel.ReplaceOne(PersonModel => PersonModel.FirstName, personModel);

        //public void Remove(PersonModel bookIn) =>
        //    _PersonModel.DeleteOne(book => book.Id == bookIn.Id);

        //public void Remove(string id) =>
        //    _PersonModel.DeleteOne(book => book.Id == id);
    }
}
