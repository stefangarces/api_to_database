using MongoDB.Bson.Serialization.Attributes;
using System;

namespace api_to_database.Models
{
    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel Address { get; set; }
        [BsonElement("dob")]
        public DateTime DateOfBirth { get; set; }
    }

    public class PersonModelDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
