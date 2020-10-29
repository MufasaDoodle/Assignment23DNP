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
        string url1 = "http://dnp.metamate.me/Adults/";

        public CloudAdultService()
        {
            client = new HttpClient();
        }

        public async Task AddPerson(Adult person)
        {
            string adultSerialized = JsonSerializer.Serialize(person);

            HttpContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PutAsync($"{url1}", content);
        }

        public async Task<IList<Adult>> GetPeople()
        {
            Task<string> stringAsync = client.GetStringAsync($"{url1}");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task RemovePerson(int personID)
        {
            await client.DeleteAsync($"{url1}{personID}");
        }

        public async Task UpdatePerson(Adult person)
        {
            string adultSerialized = JsonSerializer.Serialize(person);

            HttpContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
                );
            await client.PatchAsync($"{url1}{person.Id}", content);
        }
    }
}
