using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Licensing.ViewModels
{
    public class CompanyLicenceViewModel
    {
        public CompanyViewModel CompanyDetails { get; set; }

        // Licence purchase information
        [Required(ErrorMessage = "Licence is required")]
        public int LicenceId { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1")]
        public int Quantity { get; set; }

        public SelectList LicenceSelectList { get; set; }
    }
}
