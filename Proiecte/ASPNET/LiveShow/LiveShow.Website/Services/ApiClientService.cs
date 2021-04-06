using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveShow.Website.Services
{
    public class ApiClientService : IApiService
    {
        HttpClient httpClient;

        public ApiClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async void RegisterUser(string firstName, string lastName, string userName, string password, string userType)
        {
            var values = new Dictionary<string, string>
            {
                { "Username", userName },
                { "Password", password },
                { "FirstName", firstName },
                { "LastName", lastName },
                { "UserType", userType }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await httpClient.PostAsync("https://localhost:5001/api/v1/user", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        private T GetContentFromHttp<T>(string url)
        {
            var content = httpClient.GetAsync(url)
                .Result.Content.ReadAsStringAsync();
            content.Wait();
            return JsonConvert.DeserializeObject<T>(content.Result);
        }
    }
}
