using DNPAssignment23.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNPAssignment23.Data
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

        public void AddUser(User user)
        {
            int max;
            try
            {
                max = users.Max(user => user.UserID);
            }
            catch(Exception e)
            {
                max = 1;
            }
            user.UserID = (++max);
            users.Add(user);
            WriteUsersToFile();
        }

        public IList<User> GetUsers()
        {
            List<User> temp = new List<User>(users);
            return temp;
        }

        public void UpdateUser(User user)
        {
            User toUpdate = users.First(t => t.UserID == user.UserID);
            toUpdate.UserName = user.UserName;
            toUpdate.Password = user.Password;
            toUpdate.UserID = user.UserID;
            toUpdate.SecurityLevel = user.SecurityLevel;
            WriteUsersToFile();
        }

        public User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(username));
            if(first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) 
            {
                throw new Exception("Password is wrong");
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
