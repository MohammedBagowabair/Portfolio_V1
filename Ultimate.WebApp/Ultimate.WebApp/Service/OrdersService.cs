using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class OrdersService: IOrdersService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        //private readonly IMapper _mapper;
        public OrdersService(HttpClient httpClient, IConfiguration configuration )
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
            //_mapper = mapper;

        }
        public async Task<ResponseModel<OrderModel>> GetOrders()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<OrderModel>>($"{_baseUrl}/api/Order");

        }
        public async Task<ResponseModel<OrderModel>> GetOrderGetByStatus(string status)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<OrderModel>>($"{_baseUrl}/api/Order/GetByStatus/{status}");

        }
        public async Task<ResponseModel<OrderModel>> GetAllOrderByStatus(string status)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<OrderModel>>($"{_baseUrl}/api/Order/GetAllOrdersByStatus/{status}");

        }
        public async Task<ResponsGeneric<OrderDetails>> GetOrderDetails(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<OrderDetails>>($"{_baseUrl}/api/Order/Details/{orderId}");

        }
        public async Task<ResponsePost<ImageFile>> uploadFile(ImageFile imageFile)
        {
            var response = await _httpClient.PostAsJsonAsync<ImageFile>($"{_baseUrl}/api/Order/Upload", imageFile);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<ImageFile> result = JsonConvert.DeserializeObject<ResponsePost<ImageFile>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<ImageFile>() { Code = 0, Message = result.Message };
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

        public async Task<ResponsePost<OrderModel>> addOrder(OrderModel orderModel)
        {
            var response = await _httpClient.PostAsJsonAsync<OrderModel>($"{_baseUrl}/api/Order", orderModel);
            ResponsePost<OrderModel> result = JsonConvert.DeserializeObject<ResponsePost<OrderModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                if (result?.Code == 0)
                {

                    return new ResponsePost<OrderModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                return new ResponsePost<OrderModel>() { Code = result.Code, Message = result.Message };
            }
        }
        public async Task<ResponseModel> UpdateOrderStatus(OrderModel order)
        {
            var response = await _httpClient.PutAsJsonAsync<OrderModel>($"{_baseUrl}/api/Order/UpdateStatus/{order.id}", order);
            if(response.IsSuccessStatusCode)
            {
                var result=JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                if(result?.Code == 0)
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
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Order/CancelOrder/{id}",null);
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
        public async Task<ResponsePost<OrderModel>> AddRenewalOrder(int id)
        {
            var response = await _httpClient.PostAsJsonAsync<OrderModel>($"{_baseUrl}/api/Order/AddRenewalOrder?subscriptionId={id}",null);
            ResponsePost<OrderModel> result = JsonConvert.DeserializeObject<ResponsePost<OrderModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                //ResponsePost<OrderModel> result = JsonConvert.DeserializeObject<ResponsePost<OrderModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<OrderModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                return new ResponsePost<OrderModel>() { Code = result.Code, Message = result.Message };
            }
        }

        public async Task<ResponseModel<SubscriptionModel>> GetSubscriptionForExtend()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<SubscriptionModel>>($"{_baseUrl}/api/Subscription/GetSubscriptionForExtend");
        }

        public async Task<ResponseModel> ExtendSubscription(int? days, List<int> Ids)
        {
            var response = await _httpClient.PutAsJsonAsync<List<int>>($"{_baseUrl}/api/Subscription/ExtendSubscription?days={days}", Ids);
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

        public async  Task<ResponseModel> SendBillToEmail(int userId,int pckId,int lang)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel>($"{_baseUrl}/api/Package/SendBillToEmail?UserId={userId}&packageId={pckId}&lang={lang}");
        }
    
    }
}
