using Newtonsoft.Json;
using ProjectManagement.UI.Models;
using System.Text;

namespace ProjectManagement.UI.Services
{
    public class BaseService
    {
        private readonly HttpClient _httpClient;
        private readonly string token;

        public BaseService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            token = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", Thread.CurrentThread.CurrentCulture.Name);
        }
        public async Task<Result> Post<Tdata>(Tdata data, string requestAddress)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            StringContent stringContent = new(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestAddress, stringContent);
            var result = JsonConvert.DeserializeObject<Result>(await response.Content.ReadAsStringAsync());
            result.Statuscode = response.StatusCode.ToString();
            return result;
        }
        public async Task<Result> Put<Tdata>(Tdata data, string requestAddress)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            var response = await _httpClient.PutAsync(requestAddress, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
            result.Statuscode = response.StatusCode.ToString();
            return result;
        }
        public async Task<Result> Delete(int id, string requestAddress)
        {
            var response = await _httpClient.DeleteAsync(requestAddress + id);
            var result = JsonConvert.DeserializeObject<Result>(await response.Content.ReadAsStringAsync());
            result.Statuscode = response.StatusCode.ToString();
            return result;
        }
        public async Task<OnlyDataResult<Tdata>> GetById<Tdata>(int id, string requestAddress)
        {
            var response = await _httpClient.GetAsync(requestAddress + id);
            string sonuc = response.Content.ReadAsStringAsync().Result;
            var returnData = JsonConvert.DeserializeObject<OnlyDataResult<Tdata>>(sonuc, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return returnData;
        }
        public async Task<DataResult<Tdata>> Get<Tdata>(string requestAddress)
        {
            var response = await _httpClient.GetAsync(requestAddress);
            string sonuc = response.Content.ReadAsStringAsync().Result;
            var returnData = JsonConvert.DeserializeObject<DataResult<Tdata>>(sonuc, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return returnData;
        }
    }
}
