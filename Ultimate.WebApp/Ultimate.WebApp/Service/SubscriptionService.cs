using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.DTO;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly IMapper _mapper;
        public SubscriptionService(HttpClient httpClient, IConfiguration configuration,IMapper mapper)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
            _mapper = mapper;

        }
        public async Task<ResponsePost<SubscriptionModel>> Create(SubscriptionModel subscriptionModel)
        {
            //SubscriptionServiceDto subscription = _mapper.Map<SubscriptionServiceDto>(subscriptionModel.subscriptionService);
            //string converter = System.Text.Json.JsonSerializer.Serialize<SubscriptionServiceDto>(subscription);
            //List<SubscriptionServiceModel> subscriptionServiceModel = System.Text.Json.JsonSerializer.Deserialize<List<SubscriptionServiceModel>>(converter);
            //subscriptionModel.subscriptionService = subscriptionServiceModel;
            //subscriptionModel.id = 556;
          
            var response = await _httpClient.PostAsJsonAsync<SubscriptionModel>($"{_baseUrl}/api/Subscription", subscriptionModel);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<SubscriptionModel> result = JsonConvert.DeserializeObject<ResponsePost<SubscriptionModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return new ResponsePost<SubscriptionModel>() { Code = 0, Message = result.Message,Content=result.Content};
                }
                else if(result?.Code == 4002)
                {
                    return new ResponsePost<SubscriptionModel>() { Code = result.Code, Message = result.Message };
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
        public async Task<ResponseModel<SubscriptionModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<SubscriptionModel>>($"{_baseUrl}/api/Subscription");
        }
        public async Task<ResponsGeneric<SubscriptionModel>> GetById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<SubscriptionModel>>($"{_baseUrl}/api/Subscription/{Id}");
        }
        public async Task<ResponseModel> Update(SubscriptionModel subscriptionModel, int subscriptionId)
        {
            var response = await _httpClient.PutAsJsonAsync<SubscriptionModel>($"{_baseUrl}/api/Subscription/{subscriptionId}", subscriptionModel);
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
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Subscription/{id}");
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
        public async Task<ResponsGeneric<bool>> isFree(int UserId)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<bool>>($"{_baseUrl}/api/Subscription/IsFree/{UserId}");
            
        }
        public async Task<ResponsGeneric<SubscriptionModel>> ThePostOfFreeSubscription(int pckId) {
            var response = await _httpClient.PostAsJsonAsync<SubscriptionModel>($"{_baseUrl}/api/Subscription/ThePostOfFreeSubscription?PackageId={pckId}",null);
            ResponsGeneric<SubscriptionModel> result = JsonConvert.DeserializeObject<ResponsGeneric<SubscriptionModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                
                if (result?.Code == 0)
                {
                    return new ResponsGeneric<SubscriptionModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                if (result.Code == 4006)
                {
                    return new ResponsGeneric<SubscriptionModel>() { Code = result.Code, Message = result.Message };
                }
                else
                {
                    throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");
                }
            }
        }
        public async Task<ResponseModel<SubscriptionModel>> GetRequestedStatus()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<SubscriptionModel>>($"{_baseUrl}/api/Subscription/GetByStatusRequested");

        }
    }
}
