using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController (JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employer = context.Employers.ToList();
            return View(employer);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel employerViewMod)
        {
            if (ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = employerViewMod.Name,
                    Location = employerViewMod.Location
                };
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("Index");
            }
            return View("ProcessAddEmployerForm", employerViewMod);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id);

            return View(employer);
        }
    }
}
