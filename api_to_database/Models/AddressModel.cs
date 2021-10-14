using System.ComponentModel.DataAnnotations;

namespace api_to_database.Models
{
    public class AddressModel
    {
        public string StreetAdress { get; set; }
        public string City { get; set; }
        [Range(10000, 99999)]
        public int ZipCode { get; set; }
    }
}
