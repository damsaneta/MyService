using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyService.Application.Model;
using Newtonsoft.Json;

namespace MyService.ClientApp
{
    public static class DataHelper
    {
        private static readonly HttpClient Client = new HttpClient {BaseAddress = new Uri("http://localhost/MyService/api/") }; 

        public static async Task<User> RegisterUser(string email)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("Users", new User {Email = email});
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            User result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }
    }
}
