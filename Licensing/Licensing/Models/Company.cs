using System.ComponentModel.DataAnnotations;

namespace Licensing.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<LicencePurchase> LicencePurchases { get; set; }
    }
}
