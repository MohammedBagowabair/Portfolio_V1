using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Pages.Bot
{
    public class BotService : IBotService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public BotService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
        public async Task<ResponseModel<BotModel>> GetBot(int clientId)
        {
           ResponseModel<BotModel> result= await _httpClient.GetFromJsonAsync<ResponseModel<BotModel>>($"{_baseUrl}/api/Bot/{clientId}");
            Console.WriteLine(result);
            return result;
        }
        public async Task<ResponseModel<BotModel>> GetAllBot()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<BotModel>>($"{_baseUrl}/api/Bot");
        }
        public async Task<ResponseModel> Refresh()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel>($"{_baseUrl}/api/Bot/Refresh");
        }
        public async Task<ResponsePost<int>> UploadImage(BotFileModel botFileModel)
        {
            var response = await _httpClient.PostAsJsonAsync<BotFileModel>($"{_baseUrl}/api/Media/Upload", botFileModel);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponsePost<int>>(await response.Content.ReadAsStringAsync());
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
        public async Task<ResponsGeneric<BotFileModel>> GetFileById(int imgId)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<BotFileModel>>($"{_baseUrl}/api/Media/GetFileById/{imgId}");

        }
        public async Task<ResponsePost<int>> UpdateImage(int imgId,BotFileModel botFileModel)
        {
            var response = await _httpClient.PutAsJsonAsync<BotFileModel>($"{_baseUrl}/api/Media/EditMediaFile/{imgId}", botFileModel);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponsePost<int>>(await response.Content.ReadAsStringAsync());
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
    }
}
