using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        
        public AdminDashboardService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
           

        }
        public async Task<ResponsGeneric<AllStatisticsModel>> GetAllStatisticsNumber([Optional] string fDate, [Optional] string lDate)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<AllStatisticsModel>>($"{_baseUrl}/api/DashPanel/GetAllStatisticsNumber?firstDate={fDate}&lastDate={lDate}");
        }
        public async Task<ResponseModel<UsersModel>> GetAllSubscribedUsers([Optional] string fDate, [Optional] string lDate)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<UsersModel>>($"{_baseUrl}/api/DashPanel/GetAllSubscribedUsers?FirstDate={fDate}&LastDate={lDate}");
        }
        public async Task<ResponseModel<UserStatisticsModel>> GetUserStatisticsSummary(int userId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<UserStatisticsModel>>($"{_baseUrl}/api/DashPanel/GetUserStatisticsSummary/{userId}");
        }
        public async Task<ResponseModel<SubscriptionModel>> GetUserStatisticsDetails(int userId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<SubscriptionModel>>($"{_baseUrl}/api/DashPanel/GetUserStatistics/{userId}");
        }
    }
}
