using Assignment3_WebService.Models;
using Assignment3_WebService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Data
{
    public class DatabaseUserService : IUserService
    {
        IUserRepo repo;

        public DatabaseUserService()
        {
            repo = new UserRepo();
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await repo.AddUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await repo.UpdateUserAsync(user);
        }

        public async Task<User> ValidateUserAsync(string username)
        {
            return await repo.ValidateUserAsync(username);
        }
    }
}
