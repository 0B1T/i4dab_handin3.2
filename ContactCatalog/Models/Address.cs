using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactCatalog.Models
{

    public class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Persons = new HashSet<Person>();
        }

        [Key]
        public int Addresses { get; set; }

        [Required]
        public string AddressType { get; set; }

        [Required]
        public string Streetname { get; set; }

        [Required]
        [StringLength(128)]
        public string PostCode_PostCodeId { get; set; }

        [Required]
        public string HousNr { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Persons { get; set; }
    }
}