using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.ViewModels
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }

        public string SearchString { get; set; }
        public bool CaseSensitive { get; set; }
        public bool SortByNameAndCity { get; set; }
        public bool SortNamesBackwards { get; set; }
        public List<Person> People { get; set; }
        public Person person { get; set; }

        public List<Person> GetAllPersons()
        {
            return People;
        }

    }
}