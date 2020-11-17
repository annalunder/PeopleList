using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel.Models;
using ViewModel.ViewModels;

namespace ViewModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(PersonViewModel pVM)
        {
            PersonRepo repo = new PersonRepo();

            var peoples = repo.GetAllPersons().OrderBy(x => x.Name);

            PersonViewModel pvm = new PersonViewModel();

            if (!string.IsNullOrEmpty(pVM.SearchString) && pVM.CaseSensitive == true)
            {
                pvm.People = peoples.Where(s => s.Name.Contains(pVM.SearchString)).ToList();
                pvm.People = peoples.Where(s => s.City.Contains(pVM.SearchString)).ToList();
            }

            else if (!string.IsNullOrEmpty(pVM.SearchString) && pVM.CaseSensitive == false)
            {
                pvm.People = peoples.Where(s => s.Name.Contains(pVM.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
                pvm.People = peoples.Where(s => s.City.Contains(pVM.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            else if (pVM.SortByNameAndCity == true)
            {
                pvm.People = peoples.OrderBy(n => n.Name).ThenBy(c => c.City).ToList();
            }

            else if (pVM.SortNamesBackwards == true)
            {
                pvm.People = peoples.OrderByDescending(n => n.Name).ToList();
            }

            else
            {
                pvm.People = peoples.ToList();
            }

            return View(pvm);
        }

        public IActionResult Person(PersonViewModel pVM)
        {
            PersonRepo repo = new PersonRepo();

            var peoples = repo.GetAllPersons().OrderBy(x => x.Name);

            PersonViewModel pvm = new PersonViewModel();

            if (!string.IsNullOrEmpty(pVM.SearchString) && pVM.CaseSensitive == true)
            {
                pvm.People = peoples.Where(s => s.Name.Contains(pVM.SearchString)).ToList();
                pvm.People = peoples.Where(s => s.City.Contains(pVM.SearchString)).ToList();
            }

            else if (!string.IsNullOrEmpty(pVM.SearchString) && pVM.CaseSensitive == false)
            {
                pvm.People = peoples.Where(s => s.Name.Contains(pVM.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
                pvm.People = peoples.Where(s => s.City.Contains(pVM.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            else if (pVM.SortByNameAndCity == true)
            {
                pvm.People = peoples.OrderBy(n => n.Name).ThenBy(c => c.City).ToList();
            }

            else if (pVM.SortNamesBackwards == true)
            {
                pvm.People = peoples.OrderByDescending(n => n.Name).ToList();
            }

            else
            {
                pvm.People = peoples.ToList();
            }

            return View(pvm);
        }

        public IActionResult Delete(Person person)
        {
            PersonRepo repo = new PersonRepo();

            repo.RemovePerson(person);

            return RedirectToAction("Index");
        }

        public IActionResult Add(PersonViewModel pVM)
        {
            Person person = new Person();
            PersonRepo repo = new PersonRepo();

            person.Name = pVM.Name;
            person.PhoneNumber = pVM.PhoneNumber;
            person.City = pVM.City;
            repo.AddPerson(person);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
