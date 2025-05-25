using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class PeriodService: IPeriodService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public PeriodService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];
        }

        public async Task<ResponsePost<PeriodModel>> Create(PeriodModel periodModel)
        {
            var response = await _httpClient.PostAsJsonAsync<PeriodModel>($"{_baseUrl}/api/Period", periodModel);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<PeriodModel> result = JsonConvert.DeserializeObject<ResponsePost<PeriodModel>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {

                    return new ResponsePost<PeriodModel>() { Code = 0, Message = result.Message };
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
        public async Task<ResponseModel<PeriodModel>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<PeriodModel>>($"{_baseUrl}/api/Period/{id}");
        }
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Period/{id}");
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
        public async Task<ResponseModel<PeriodModel>> GetAll()
        {

            return await _httpClient.GetFromJsonAsync<ResponseModel<PeriodModel>>($"{_baseUrl}/api/Period");

        }
        public async Task Update(PeriodModel periodModel)
        {
            var response = await _httpClient.PutAsJsonAsync<PeriodModel>($"{_baseUrl}/api/Period", periodModel);
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
