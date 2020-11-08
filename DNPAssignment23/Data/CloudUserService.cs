using DNPAssignment23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNPAssignment23.Data
{
    public class CloudUserService : IUserService
    {
        HttpClient client;
        string uri = "https://localhost:44339/users";

        public CloudUserService()
        {
            client = new HttpClient();
        }

        public async Task AddUserAsync(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PostAsync($"{uri}", content);
        }

        public async Task UpdateUserAsync(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );
            await client.PatchAsync($"{uri}{user.UserID}", content);
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            string message = await client.GetStringAsync($"{uri}?username={username}");

            User result = JsonSerializer.Deserialize<User>(message);

            if (!result.Password.Equals(password))
            {
                throw new Exception("Password is incorrect");
            }

            return result;
        }
    }
}
