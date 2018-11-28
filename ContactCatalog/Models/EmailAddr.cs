using System.ComponentModel.DataAnnotations;

namespace ContactCatalog.Models
{
    public class EmailAddr
    {
        [Key]
        public string Emails { get; set; }

        [Required]
        public string EmailAddrType { get; set; }

        public int Contact_PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
