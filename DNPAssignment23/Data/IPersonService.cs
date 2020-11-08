using DNPAssignment23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment23.Data
{
    interface IPersonService
    {
        Task <IList<Adult>> GetPeopleAsync(string firstName, string lastName, int? age);
        Task<Adult> GetAdultByIdAsync(int id);
        Task AddPersonAsync(Adult person);
        Task RemovePersonAsync(int personID);
        Task UpdatePersonAsync(Adult person);
    }
}
