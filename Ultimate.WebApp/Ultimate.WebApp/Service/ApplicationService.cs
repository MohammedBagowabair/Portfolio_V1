using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class ApplicationService: IApplicationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ApplicationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }

        public async Task<ResponsePost<ApplicationModel>> Create(ApplicationModel applicationModel)
        {
            var response = await _httpClient.PostAsJsonAsync<ApplicationModel>($"{_baseUrl}/api/Application", applicationModel);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<ApplicationModel> result = JsonConvert.DeserializeObject<ResponsePost<ApplicationModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<ApplicationModel>() { Code = 0, Message = result.Message };
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

        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Application/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
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
        public async Task<ResponseModel> RefreshSecret(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel>($"{_baseUrl}/api/Application/RefreshSecretKey/{id}");
        }

        public async Task<ResponseModel<ApplicationModel>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ApplicationModel>>($"{_baseUrl}/api/Application/{id}");
        }

        public async Task Update(int id,ApplicationModel applicationModel)
        {
            var response = await _httpClient.PutAsJsonAsync<ApplicationModel>($"{_baseUrl}/api/Application/{id}", applicationModel);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<bool> result = JsonConvert.DeserializeObject<ResponsePost<bool>>(await response.Content.ReadAsStringAsync());
                //Console.WriteLine("result of code is:" + result.Code);
                if (result?.Code == 0)
                {

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
