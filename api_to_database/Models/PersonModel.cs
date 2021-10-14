using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace api_to_database.Models
{
    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress.")]
        public string Email { get; set; }
        [RegularExpression(@"^07\d*", ErrorMessage = "Mobilnumret måste börja på 07.")]
        [StringLength(10, ErrorMessage = "Mobilnumret måste vara 10 siffror.")]
        public string SwishNumber { get; set; }
        public AddressModel Address { get; set; }
    }

    public class PersonModelDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress.")]
        public string Email { get; set; }
        [RegularExpression(@"^07\d*", ErrorMessage = "Mobilnumret måste börja på 07.")]
        [StringLength(10, ErrorMessage = "Mobilnumret måste vara 10 siffror.")]
        public string SwishNumber { get; set; }
        public AddressModel Address { get; set; }
    }

    public class PersonModelUpdateDTO
    {
        public string Email { get; set; }
        [RegularExpression(@"^07\d*", ErrorMessage = "Mobilnumret måste börja på 07.")]
        [StringLength(10, ErrorMessage = "Mobilnumret måste vara 10 siffror.")]
        public string SwishNumber { get; set; }
        public AddressModel Address { get; set; }
    }
}
