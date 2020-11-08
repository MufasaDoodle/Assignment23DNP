using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignment23.Models;

namespace DNPAssignment23.Data
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> ValidateUserAsync(string username, string password);
    }
}
