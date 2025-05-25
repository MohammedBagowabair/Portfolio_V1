using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class NotificationServices : INotificationServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
       
        public NotificationServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
            

        }
        public async  Task<ResponseModel> SendNotification(NotificationsModel notification)
        {
            var response=await _httpClient.PostAsJsonAsync<NotificationsModel>($"{_baseUrl}/api/Notification",notification);
            if (response.IsSuccessStatusCode)
            {
                var result= JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
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
        public async Task<ResponsGeneric<bool>> UpdateNotifications(int option, List<int> Ids)
        {
            var response = await _httpClient.PutAsJsonAsync<List<int>>($"{_baseUrl}/api/Notification?Option={option}", Ids);
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
    }
}
