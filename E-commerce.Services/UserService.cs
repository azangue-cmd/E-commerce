using E_commerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Services
{
    internal class UserService
    {
       private readonly HttpClient client;
        public UserService(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<UserModel> Get(int id)
        {
            //http://localhost:8180/api
            string url = $"Users/{id}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserModel>(data);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException("User not found !!!!");
            }
            else
            {
                throw new Exception($"Error status code : {response.StatusCode} \n {data}");
            }
        }


        public async Task<UserModel> Login (string username, string password)
        {
            //http://localhost:8180/api
            string url = $"Users/username = {username} & password = {password}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserModel>(data);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new UnauthorizedAccessException("Username or password is incorrect !!!!");
            }
            else
            {
                throw new Exception($"Error status code : {response.StatusCode} \n {data}");
            }
        }

        public async Task<UserModel> Create(UserModel user)
        {
            //http://localhost:8180/api
            string url = $"/Users";
            StringContent content = new StringContent
                (
                    JsonConvert.SerializeObject(user),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
            var response = await client.PostAsync(url, content);
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserModel>(data);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new DuplicateWaitObjectException($"Username {user.Username} already exists !!!!");
            }
            else
            {
                throw new Exception($"Error status code : {response.StatusCode} \n {data}");
            }
        }


        public async Task<UserModel> Update(UserModel user)
        {
            //http://localhost:8180/api
            string url = $"/Users";
            StringContent content = new StringContent
                (
                    JsonConvert.SerializeObject(user),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
            var response = await client.PutAsync(url, content);
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserModel>(data);
            }

            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"User id {user.Id} not found !!!!");
            }

            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new DuplicateWaitObjectException($"Username {user.Username} already exists !!!!");
            }

            else
            {
                throw new Exception($"Error status code : {response.StatusCode} \n {data}");
            }
        }


    }
}
