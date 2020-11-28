using Assignment3_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Persistence
{
    public class AdultRepo : IAdultRepo
    {
        private DatabaseContext context;

        public AdultRepo()
        {
            context = new DatabaseContext();
        }

        public async Task<Adult> AddPerson(Adult person)
        {
            await context.Adults.AddAsync(person);
            await context.SaveChangesAsync();
            return person;
        }

        public async Task<IList<Adult>> GetPeople(string firstName, string lastName, int? age, int? id)
        {
            List<Adult> returnList = context.Adults.Where(adult =>
            (firstName != null && adult.FirstName.Equals(firstName) || firstName == null) &&
            (lastName != null && adult.LastName.Equals(lastName) || lastName == null) &&
            (age != null && adult.Age == age || age == null) &&
            (id != null && adult.Id == id || id == null)
            ).ToList();

            return returnList;
        }

        public async Task RemovePerson(int personID)
        {
            Adult toRemove = context.Adults.First(p => p.Id == personID);
            context.Remove(toRemove);
            await context.SaveChangesAsync();
        }

        public async Task<Adult> UpdatePerson(Adult person)
        {
            context.Update(person);
            await context.SaveChangesAsync();
            return person;
        }
    }
}
