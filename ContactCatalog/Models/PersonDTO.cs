using System.Collections.Generic;

namespace ContactCatalog.Models
{
    public class PersonDTO
    {
        public int Person { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonType { get; set; }
        public List<string> EmailIds { get; set; }
        public List<int> AddressIds { get; set; }
    }
}