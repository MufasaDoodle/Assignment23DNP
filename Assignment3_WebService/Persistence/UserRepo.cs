using Assignment3_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Persistence
{
    public class UserRepo : IUserRepo
    {
        private DatabaseContext context;

        public UserRepo()
        {
            context = new DatabaseContext();
        }

        public async Task<User> AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            context.Update(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> ValidateUserAsync(string username)
        {
            User first = context.Users.FirstOrDefault(user => user.UserName.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            return first;
        }
    }
}
