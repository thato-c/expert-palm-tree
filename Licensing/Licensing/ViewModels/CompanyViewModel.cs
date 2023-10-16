using System.ComponentModel.DataAnnotations;

namespace Licensing.ViewModels
{
    public class CompanyViewModel
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1")]
        public int Quantity { get; set; }
    }
}
