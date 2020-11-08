using Assignment3_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Data
{
    public interface IPersonService
    {
        Task<IList<Adult>> GetPeople(string firstName, string lastName, int? age, int? id);
        Task<Adult> AddPerson(Adult person);
        Task RemovePerson(int personID);
        Task<Adult> UpdatePerson(Adult person);
    }
}
