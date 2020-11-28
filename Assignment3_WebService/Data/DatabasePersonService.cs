using Assignment3_WebService.Models;
using Assignment3_WebService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Data
{
    public class DatabasePersonService : IPersonService
    {
        IAdultRepo repo;

        public DatabasePersonService()
        {
            repo = new AdultRepo();
        }

        public async Task<Adult> AddPerson(Adult person)
        {
            return await repo.AddPerson(person);
        }

        public async Task<IList<Adult>> GetPeople(string firstName, string lastName, int? age, int? id)
        {
            return await repo.GetPeople(firstName, lastName, age, id);
        }

        public async Task RemovePerson(int personID)
        {
            await repo.RemovePerson(personID);
        }

        public async Task<Adult> UpdatePerson(Adult person)
        {
            return await repo.UpdatePerson(person);
        }
    }
}
