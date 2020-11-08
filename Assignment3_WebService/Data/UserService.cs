using Assignment3_WebService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment3_WebService.Data
{
    public class UserService : IUserService
    {
        private string usersFile = "users.json";
        private IList<User> users;

        public UserService()
        {
            if (!File.Exists(usersFile))
            {
                Seed();
                WriteUsersToFile();
            }
            else
            {
                string content = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        private void Seed()
        {
            User[] temp =
            {
                new User
                {
                    UserID = 1,
                    UserName = "Mufasa",
                    Password = "1234",
                    SecurityLevel = 3
                }
            };
            users = temp.ToList();
        }

        public async Task<User> AddUserAsync(User user)
        {
            int max = users.Max(user => user.UserID);
            user.UserID = (++max);
            users.Add(user);
            WriteUsersToFile();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            User toUpdate = users.FirstOrDefault(t => t.UserID == user.UserID);
            if(toUpdate == null)
            {
                throw new Exception($"Did not find adult with ID: {user.UserID}");
            }
            toUpdate.UserName = user.UserName;
            toUpdate.Password = user.Password;
            toUpdate.UserID = user.UserID;
            toUpdate.SecurityLevel = user.SecurityLevel;
            WriteUsersToFile();
            return toUpdate;
        }

        public async Task<User> ValidateUserAsync(string username)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            return first;
        }

        private void WriteUsersToFile()
        {
            string usersAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(usersFile, usersAsJson);
        }
    }
}
