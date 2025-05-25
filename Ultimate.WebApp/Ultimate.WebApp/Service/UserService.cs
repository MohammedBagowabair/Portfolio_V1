using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.DTO;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }

        public async Task<ResponsePost<UserDto>> Create(UserModel userModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/registeruser", userModel);

            ResponsePost<UserDto> result = JsonConvert.DeserializeObject<ResponsePost<UserDto>>(await response.Content.ReadAsStringAsync());
            return result;


        }
        public async Task<ResponsGeneric<bool>> IsUserHaveActiveSubscription(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ResponsGeneric<bool>>($"{_baseUrl}/api/User/IsUserHaveActiveSubscription");

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<ResponsGeneric<bool>> IsUserSubScribed(int userId, string ServiceName)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/User/IsUserSubScribed?UserId={userId}&ServiceName={ServiceName}", null);

            if (response.IsSuccessStatusCode)
            {
                ResponsGeneric<bool> result = JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return result;
                }
                else
                {
                    return result;
                    //throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");

            }

        }
        public async Task<ResponsGeneric<bool>> SendWhatsappVerifyCode(string whatsAppNumber)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/User/SendWhatsappVerifyCode/{whatsAppNumber}", null);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
            }

        }
        public async Task<ResponsGeneric<bool>> VerifyWhatsappPhone(string code)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/User/VerifyWhatsappPhone?code={code}", null);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
            }
        }
        public async Task<ResponseModel<UsersModel>> GetAllUsers()
        {
            var response = await _httpClient.PostAsJsonAsync<ResponseModel<UsersModel>>($"{_baseUrl}/api/User/GetAllUsers", null);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponseModel<UsersModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}
