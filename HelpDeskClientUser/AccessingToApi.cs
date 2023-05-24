
using ClientAppHelpDesk.DataBase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HelpDeskClientUser
{
    public class AccessingToApi
    {
        public static string address = "https://localhost:7242";

        public static async Task<List<Clients>> GetClientsAsync()
        {
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync($"{address}/api/users");
            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Clients>>(content);
            }
            else
            {
                return null;
            }
        }
        
        public static async Task NewUsers()
        {
            var client = new HttpClient();
            var data = new StringContent("{\"name\":\"John\", \"age\":30}", Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{address}/api/users", data);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
            client.Dispose();

        }
        /*
        public static async Task NewUser()
        {
            var client = new HttpClient();
            var user = new { Name = "Tom", Age = 37 };

            var json = Newtonsoft.Json.JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5001/api/users", content);

            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var newUser = Newtonsoft.Json.JsonSerializer.Deserialize<Person>(json);
                Console.WriteLine($"New user created: {newUser.Id} - {newUser.Name} ({newUser.Age})");
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        */
    }

    public class Person
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
