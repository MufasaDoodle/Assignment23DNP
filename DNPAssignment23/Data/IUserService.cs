using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignment23.Models;

namespace DNPAssignment23.Data
{
    public interface IUserService
    {
        IList<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        User ValidateUser(string username, string password);
    }
}
