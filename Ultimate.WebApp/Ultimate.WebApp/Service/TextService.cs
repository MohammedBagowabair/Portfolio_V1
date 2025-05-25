using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class TextService: ITextService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public TextService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }
        public async Task<ResponsePost<TextModel>> Create(TextModel textModel)
        {
            var response = await _httpClient.PostAsJsonAsync<TextModel>($"{_baseUrl}/api/textModel", textModel);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<TextModel> result = JsonConvert.DeserializeObject<ResponsePost<TextModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<TextModel>() { Code = 0, Message = result.Message };
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
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/textModel/{id}");
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

        public async Task<ResponseModel<TextModel>> GetByBotId(int BotId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<TextModel>>($"{_baseUrl}/api/textModel/GetTxtByBotId/{BotId}");
        }

        public async Task<ResponseModel<TextModel>> GetByClientId(int ClientId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<TextModel>>($"{_baseUrl}/api/textModel/GetTxtByClientId/{ClientId}");
        }

        public async Task Update(TextModel textModel)
        {
            var response = await _httpClient.PutAsJsonAsync<TextModel>($"{_baseUrl}/api/textModel", textModel);
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
