using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
    }
}