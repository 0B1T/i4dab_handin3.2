using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactCatalog.Models
{
    public class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public string PostCode { get; set; }

        [Required]
        public string CityName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
