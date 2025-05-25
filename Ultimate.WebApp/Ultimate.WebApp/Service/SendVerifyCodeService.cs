using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class SendVerifyCodeService : ISendVerifyCodeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public SendVerifyCodeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }
        public async Task<ResponsePost<string>> Create(int userId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/sendVerifyCode?userId={userId}",null);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<string> result = JsonConvert.DeserializeObject<ResponsePost<string>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return result;
                   // return new ResponsePost<string>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}
