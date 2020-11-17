using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Controllers;

namespace ViewModel.Models
{
    public class PersonRepo
    {
        public static List<Person> People { get; set; }

        // Konstruktorn kollar ifall listan är tom och behöver fyllas på:
        public PersonRepo()
        {
            if (People == null)
            {
                PopulateListOfPersons();
            }
        }

        private void PopulateListOfPersons()
        {
            People = new List<Person>
            {
                new Person
                {
                    Name = "Anna",
                    PhoneNumber = 0733100000,
                    City = "Göteborg"
                },

                new Person
                {
                    Name = "Simon",
                    PhoneNumber = 0767100000,
                    City = "Göteborg"
                },

                new Person
                {
                    Name = "Louise",
                    PhoneNumber = 0725100000,
                    City = "Floda"
                },

                new Person
                {
                    Name = "Jessica",
                    PhoneNumber = 0708100000,
                    City = "Åby"
                },

                new Person
                {
                    Name = "Marie Louise",
                    PhoneNumber = 0706100000,
                    City = "Haverdal"
                },

                new Person
                {
                    Name = "Linda",
                    PhoneNumber = 0737100000,
                    City = "Göteborg"
                },

                new Person
                {
                    Name = "Peter",
                    PhoneNumber = 0704100000,
                    City = "Mölndal"
                },

                new Person
                {
                    Name = "Cecilia",
                    PhoneNumber = 0703100000,
                    City = "Floda"
                },

                new Person
                {
                    Name = "Nils",
                    PhoneNumber = 0708100000,
                    City = "Åsa"
                },

                new Person
                {
                    Name = "Mikael",
                    PhoneNumber = 0706100000,
                    City = "Göteborg"
                },

                new Person
                {
                    Name = "Karolina",
                    PhoneNumber = 0706100000,
                    City = "Stockholm"
                }
            };
        }

        public List<Person> GetAllPersons()
        {
            return People;
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
        }
        public void RemovePerson(Person person)
        {
            foreach (var item in People)
            {
                if (item.Name == person.Name && item.PhoneNumber == person.PhoneNumber && item.City == person.City)
                {
                    People.Remove(item);
                    break;
                }
            }
        }
    }
}
