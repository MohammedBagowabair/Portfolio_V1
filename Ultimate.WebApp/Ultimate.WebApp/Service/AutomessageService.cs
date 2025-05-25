using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.Bot.Application.DTO;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class AutomessageService : IAutomessageService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public AutomessageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }
        public async Task<ResponsePost<AutoMessageModel>> Create(AutoMessageModel autoMessageModel)
        {
            var response = await _httpClient.PostAsJsonAsync<AutoMessageModel>($"{_baseUrl}/api/AutoMessage", autoMessageModel);
            ResponsePost<AutoMessageModel> result = JsonConvert.DeserializeObject<ResponsePost<AutoMessageModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                //ResponsePost<AutoMessageModel> result = JsonConvert.DeserializeObject<ResponsePost<AutoMessageModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<AutoMessageModel>() { Code = 0, Message = result.Message };
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
        public async Task<ResponsePost<AutoMessageDto>> CreateDto(AutoMessageDto autoMessageDto)
        {
            var response = await _httpClient.PostAsJsonAsync<AutoMessageDto>($"{_baseUrl}/api/AutoMessage", autoMessageDto);
            ResponsePost<AutoMessageDto> result = JsonConvert.DeserializeObject<ResponsePost<AutoMessageDto>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                if (result?.Code == 0)
                {

                    return new ResponsePost<AutoMessageDto>() { Code = 0, Message = result.Message };
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

        public async Task<ResponseModel<AutoMessageModel>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<AutoMessageModel>>($"{_baseUrl}/api/AutoMessage/{id}");
        }


        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/AutoMessage/{id}");
            var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
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
                if (result.Code == 3003)
                {
                    return result;
                }
                else
                {
                    throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
                }
            }
        }


        public async Task<ResponseModel<AutoMessageModel>> GetAll()
        {

            return await _httpClient.GetFromJsonAsync<ResponseModel<AutoMessageModel>>($"{_baseUrl}/api/AutoMessage");

        }

        public async Task<ResponseModel> Update(AutoMessageModel autoMessageModel)
        {
            var response = await _httpClient.PutAsJsonAsync<AutoMessageModel>($"{_baseUrl}/api/AutoMessage", autoMessageModel);
            var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                 //Console.WriteLine("result of code is:" + result.Code);
                if (result?.Code == 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("eeeeeeeeeeeee: "+result.Message);
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
        public async Task<ResponseModel> UpdateDto(AutoMessageDto autoMessageDto)
        {
            var response = await _httpClient.PutAsJsonAsync<AutoMessageDto>($"{_baseUrl}/api/AutoMessage", autoMessageDto);
            var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
            Console.WriteLine("response of code is:" + response);
            if (response.IsSuccessStatusCode)
            {
                
                Console.WriteLine("result of code is:" + result.Code);
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
        //    public async Task<ResponsePut<AutoMessageModel>> Update(AutoMessageModel autoMessageModel)
        //    {
        //        var response=await _httpClient.PutAsJsonAsync<AutoMessageModel>($"{_baseUrl}/api/AutoMessage", autoMessageModel);
        //        //Console.WriteLine("response is:"+response);
        //        if (response.IsSuccessStatusCode)
        //        {

        //            ResponsePut<AutoMessageModel> result = JsonConvert.DeserializeObject<ResponsePut<AutoMessageModel>>(await response.Content.ReadAsStringAsync());

        //            if (result?.Code == 1)
        //            {

        //                return new ResponsePut<AutoMessageModel>() { Code = 0, Message = result.Message };
        //            }
        //            else
        //            {
        //                throw new Exception(result.Message);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception($"status code:{response.StatusCode}, response:{await response.Content.ReadAsStringAsync()}");
        //        }

        //    }
    }
}
