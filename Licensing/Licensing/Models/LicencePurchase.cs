using System.ComponentModel.DataAnnotations;

namespace Licensing.Models
{
    public class LicencePurchase
    {
        public int PurchaseId { get; set; }
        public int CompanyId { get; set; }
        public int LicenceId { get; set; }
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

        public Company Company { get; set; }
        public Licence Licence { get; set; }
    }
}
