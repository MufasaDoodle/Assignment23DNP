using DNPAssignment23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment23.Data
{
    interface IPersonService
    {
        Task <IList<Adult>> GetPeople();
        Task AddPerson(Adult person);
        Task RemovePerson(int personID);
        Task UpdatePerson(Adult person);
    }
}
