using Licensing.Data;
using Licensing.Models;
using Licensing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Licensing.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly LicenceContext _context;

        public CompaniesController(LicenceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve a list of companies from the database
            var companies = _context.Companies.ToList();

            if (companies.Count == 0)
            {
                ViewBag.Message = "No Companies Registered.";
                return View();
            }
            
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the ViewModel to Company entity
                var Company = new Company
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };

                // Add and save the new company to the database
                _context.Companies.Add(Company);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id) 
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
    }
}
