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
    public class CloudAdultService : IPersonService
    {
        HttpClient client;
        string uri1 = "http://dnp.metamate.me/Adults/";
        string uri2 = "https://localhost:44339/adults/";

        public CloudAdultService()
        {
            client = new HttpClient();
        }

        public async Task AddPersonAsync(Adult person)
        {
            string adultSerialized = JsonSerializer.Serialize(person);

            HttpContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PostAsync($"{uri2}", content);
        }

        public async Task<IList<Adult>> GetPeopleAsync(string firstName, string lastName, int? age)
        {
            string message = "";
            string uri = uri2;
            bool temp = false;

            if(firstName != null)
            {
                if(temp == false)
                {
                    uri += "?";
                    temp = true;
                }
                else
                {
                    uri += "&";
                }
                uri += $"firstName={firstName}";
            }

            if(lastName != null)
            {
                if (temp == false)
                {
                    uri += "?";
                    temp = true;
                }
                else
                {
                    uri += "&";
                }
                uri += $"lastName={lastName}";
            }

            if(age != null)
            {
                if (temp == false)
                {
                    uri += "?";
                    temp = true;
                }
                else
                {
                    uri += "&";
                }
                uri += $"age={age}";
            }

            Console.WriteLine(uri);
            message = await client.GetStringAsync(uri);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            string message = await client.GetStringAsync(uri2 + "?id=" + id);

            List<Adult> temp = JsonSerializer.Deserialize<List<Adult>>(message);
            Adult returnList = new Adult();
            for (int i = 0; i < 1; i++)
            {
                returnList = temp.First();
            }
            return returnList;
        }

        public async Task RemovePersonAsync(int personID)
        {
            await client.DeleteAsync($"{uri2}{personID}");
        }

        public async Task UpdatePersonAsync(Adult person)
        {
            string adultSerialized = JsonSerializer.Serialize(person);

            HttpContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
                );
            await client.PatchAsync($"{uri2}{person.Id}", content);
        }
    }
}
