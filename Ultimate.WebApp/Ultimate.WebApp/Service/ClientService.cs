using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.Bot.Application.DTO;
using Ultimate.WebApp.Interface;

using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class ClientService : IClientService
    {
        //private readonly IHttpServiec _httpServiec;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
        public async Task<ResponsePost<ClientModel>> Create(ClientModel clientModel)
        {
            var response = await _httpClient.PostAsJsonAsync<ClientModel>($"{_baseUrl}/api/Client", clientModel);
            ResponsePost<ClientModel> result = JsonConvert.DeserializeObject<ResponsePost<ClientModel>>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                if (result?.Code == 0)
                {

                    return new ResponsePost<ClientModel>() { Code = 0, Message = result.Message };
                }
                else
                {

                    throw new Exception(result.Message);
                }
            }

            else
            {

                if (result?.Code == 3003 || result?.Code == 4004)
                {
                    return result;
                }
                else
                {
                    throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
                }
                //throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");


            }
        }
        public async Task<ResponseModel<ClientModel>> GetClients()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ClientModel>>($"{_baseUrl}/api/Client/");

        }
        public async Task<ResponseModel<ClientModel>> GetAllClients()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ClientModel>>($"{_baseUrl}/api/Client");

        }
        public async Task<ResponseModel<ClientModel>> GetClientById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ClientModel>>($"{_baseUrl}/api/Client/{id}");

        }
        public async Task<ResponseModel> DeleteClient(int clientId, int userId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Client/{clientId}?Id={userId}");
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
        public async Task<ResponseModel> IsConnected(int clientId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/isConnect/{clientId}");
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
        public async Task<ResponseAdd<T>> getQr<T>(int id)
        {
            //return await _httpClient.GetFromJsonAsync<ResponseAdd<T>>($"{_baseUrl}/api/client/qr/{id}");
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Client/qr/{id}");
            if (response.IsSuccessStatusCode)
            {
                ResponseAdd<T> result = JsonConvert.DeserializeObject<ResponseAdd<T>>(await response.Content.ReadAsStringAsync());
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
                return JsonConvert.DeserializeObject<ResponseAdd<T>>(await response.Content.ReadAsStringAsync());
            }


        }
        public async Task<ResponseModel> Update(ClientModel clientModel)
        {

            var response = await _httpClient.PutAsJsonAsync<ClientModel>($"{_baseUrl}/api/Client", clientModel);
            var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("result of code is:" + result.Code);
                if (result?.Code == 0)
                {

                    //clientModel.isInprogress=false;
                    //Progress.isProgress = clientModel.isInprogress;
                    return result;
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                if (result?.Code == 3003 || result?.Code == 4004)
                {
                    return result;
                }
                else
                {
                    throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
                }
            }

        }
        public async Task<ResponsGeneric<string>> logOut(int clnId)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<string>>($"{_baseUrl}/api/Client/Logout/{clnId}");
        }
        public async Task<ResponsGeneric<bool>> exitClient()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Client/exit");
            if (response.IsSuccessStatusCode)
            {
                ResponsGeneric<bool> result = JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
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
                return JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<ResponsGeneric<bool>> runClient()
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Client/run", null);
            if (response.IsSuccessStatusCode)
            {
                ResponsGeneric<bool> result = JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return result;
                }


                else if (result?.Code == 3003)
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
                return JsonConvert.DeserializeObject<ResponsGeneric<bool>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
