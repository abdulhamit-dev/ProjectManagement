using Newtonsoft.Json;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.Login;
using System.Text;

namespace ProjectManagement.UI.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenResult> GetToken(string username, string password)
        {
            string jsonString = JsonConvert.SerializeObject(new LoginVM() { UserName = username, Password = password });
            StringContent stringContent = new(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("auth/login", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            if (result == "Kullanıcı Bulunamadı")
                return new TokenResult();
            else
                return JsonConvert.DeserializeObject<TokenResult>(result);
        }
    }
}
