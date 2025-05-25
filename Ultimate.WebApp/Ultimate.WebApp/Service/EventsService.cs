using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class EventsService : IEventsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public List<MenuModel> menus;
        public EventsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }
        public async Task<ResponseModel<MenuModel>> GetMenu(int botId,string structureType)
        {
            var r = await _httpClient.GetFromJsonAsync<ResponseModel<MenuModel>>($"{_baseUrl}/api/Menu/get/{botId}/{structureType}");
            Console.WriteLine(r?.Content?.Count);
            return r;

        }
    }
}
