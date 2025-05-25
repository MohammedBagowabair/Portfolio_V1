using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Claims;
using Ultimate.WebApp.Helpers;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private string _alias;
        private readonly string _baseUrl;

        public AuthService(HttpClient httpClient,
                           IConfiguration configuration,
                           ILocalStorageService localStorage,
                           AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
            _alias = !string.IsNullOrEmpty(_configuration["ApiAlias"]) ? "/" + _configuration["ApiAlias"] : null;
            _baseUrl = configuration["BaseApiUrl"];
        }

        public async Task<ResponseModel> Login(UserLoginModel userLogin)
        {
            return JsonConvert.DeserializeObject<ResponseModel>(await (await _httpClient.PostAsJsonAsync($"{_alias}/login", userLogin)).Content.ReadAsStringAsync());
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            await _authenticationStateProvider.GetAuthenticationStateAsync();
        }
        public async Task<ResponsePost<string>> Verify(DTOModel dto)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/verifyAccount?userId={dto.id}&code={dto.code}",null);
            if (response.IsSuccessStatusCode)
            {
               
                ResponsePost<string> result = JsonConvert.DeserializeObject<ResponsePost<string>>(await response.Content.ReadAsStringAsync());
               
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
                throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");
            }
        }
        public async Task<ResponseModel> Change(ChangePasswordModel changePassword)
        {
            return JsonConvert.DeserializeObject<ResponseModel>(await (await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Auth/ChangePassword", changePassword)).Content.ReadAsStringAsync());
        }
        public async Task<ResponsGeneric<UsersModel>> GetUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<UsersModel>>($"{_baseUrl}/api/User/{id}");
        }

    }
}
