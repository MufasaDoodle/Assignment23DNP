using Assignment3_WebService.Models;
using Assignment3_WebService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assignment3_WebService.Data
{
    public class PersonService : IPersonService
    {
        private FileContext fileContext;

        public PersonService()
        {
            fileContext = new FileContext();
        }

        public async Task<Adult> AddPerson(Adult person)
        {
            int max = fileContext.Adults.Max(person => person.Id);
            person.Id = (++max);
            fileContext.Adults.Add(person);
            fileContext.SaveChanges();
            return person;

        }

        public async Task<IList<Adult>> GetPeople(string firstName, string lastName, int? age, int? id)
        {
            List<Adult> temp = new List<Adult>(fileContext.Adults);
            //List<Adult> returnList = new List<Adult>();


            List<Adult> returnList = temp.Where(adult => 
            (firstName != null && adult.FirstName.Equals(firstName) || firstName == null) &&
            (lastName != null && adult.LastName.Equals(lastName) || lastName == null) &&
            (age != null && adult.Age == age || age == null) &&
            (id != null && adult.Id == id || id == null)
            ).ToList();


            /*
            if (firstName == null && lastName == null && age == null && id == null)
            {
                return temp;
            }

            if (firstName != null && age != null)
            {
                foreach (var adult in temp)
                {
                    if ((adult.FirstName.ToLower().Contains(name.ToLower()) || adult.LastName.ToLower().Contains(name.ToLower())) && adult.Age >= age)
                    {
                        returnList.Add(adult);
                    }
                }
            }
            */

            return returnList;
        }

        public async Task RemovePerson(int personID)
        {
            Adult toRemove = fileContext.Adults.First(t => t.Id == personID);
            fileContext.Adults.Remove(toRemove);
            fileContext.SaveChanges();
        }

        public async Task<Adult> UpdatePerson(Adult person)
        {
            Adult toUpdate = fileContext.Adults.FirstOrDefault(t => t.Id == person.Id);
            if (toUpdate == null) throw new Exception($"Did ont find adult with id: {person.Id}");
            toUpdate.JobTitle = person.JobTitle;
            toUpdate.Id = person.Id;
            toUpdate.FirstName = person.FirstName;
            toUpdate.LastName = person.LastName;
            toUpdate.HairColor = person.HairColor;
            toUpdate.EyeColor = person.EyeColor;
            toUpdate.Age = person.Age;
            toUpdate.Weight = person.Weight;
            toUpdate.Height = person.Height;
            toUpdate.Sex = person.Sex;
            fileContext.SaveChanges();
            return toUpdate;
        }
    }
}
