using System.Collections.Generic;

namespace ContactCatalog.Models
{
    public class AdressDTO
    {
        public int Addresses { get; set; }

        public string AddressType { get; set; }

        public string Streetname { get; set; }

        public string HousNr { get; set; }

        public string PostCodes { get; set; }

        public List<int> PersonIDs { get; set; }
    }
}