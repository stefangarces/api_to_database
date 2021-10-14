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

        public List<PersonModel> Get() =>
            _PersonModel.Find(_ => true).ToList();

        public List<PersonModel> Get(string socialSecurityNumber) =>
            _PersonModel.Find(p => p.SocialSecurityNumber == socialSecurityNumber).ToList();

        public PersonModel Create(PersonModelDTO personModelDTO)
        {
            PersonModel personModel = new PersonModel()
            {
                FirstName = personModelDTO.FirstName,
                LastName = personModelDTO.LastName,
                SocialSecurityNumber = personModelDTO.SocialSecurityNumber,
                Email = personModelDTO.Email,
                SwishNumber = personModelDTO.SwishNumber,
                Address = personModelDTO.Address
            };
            _PersonModel.InsertOne(personModel);
            return personModel;
        }

        //public void Update(string socialSecurityNumber, PersonModel personModel) =>
        //    _PersonModel.ReplaceOne(PersonModelDTO => PersonModelDTO.Email, personModelDTO);

        //public void Update(string socialSecurityNumber) =>
        //    _PersonModel.ReplaceOne(p => p.swishNumber == p.swishNumber);

        //public void Remove(string id) =>
        //    _PersonModel.DeleteOne(book => book.Id == id);
    }
}
