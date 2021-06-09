namespace api_to_database.Models
{
    public class DatabaseCustomersSettings : IDatabaseCustomersSettings
    {
        public string CustomersCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDatabaseCustomersSettings
    {
        string CustomersCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
