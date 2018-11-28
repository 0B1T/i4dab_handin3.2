using System.Collections.Generic;

namespace ContactCatalog.Models
{
    public class CityDTO
    {
        public string PostCodes { get; set; }

        public string CityName { get; set; }

        public List<int> AddressIDs { get; set; }
    }
}
