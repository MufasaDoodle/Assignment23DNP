using DNPAssignment23.Persistence;
using DNPAssignment23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment23.Data
{
    public class PersonService : IPersonService
    {
        private FileContext fileContext;

        public PersonService()
        {
            fileContext = new FileContext();
        }

        public async Task AddPerson(Adult person)
        {
            int max;
            try
            {
                max = fileContext.Adults.Max(person => person.Id);
            }
            catch
            {
                max = 1;
            }
            person.Id = (++max);
            if(person is Adult)
            {
                fileContext.Adults.Add(person);
                fileContext.SaveChanges();
            }

        }

        public async Task<IList<Adult>> GetPeople()
        {
            List<Adult> temp = new List<Adult>(fileContext.Adults);
            return temp;
        }

        public async Task RemovePerson(int personID)
        {
            Adult toRemove = fileContext.Adults.First(t => t.Id == personID);
            fileContext.Adults.Remove(toRemove);
            fileContext.SaveChanges();
        }

        public async Task UpdatePerson(Adult person)
        {
            Adult toUpdate = fileContext.Adults.First(t => t.Id == person.Id);
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
        }
    }
}
