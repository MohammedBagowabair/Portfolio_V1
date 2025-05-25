using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;
using Ultimate.WebApp.Pages.Reports;

namespace Ultimate.WebApp.Service
{
    public class ReportCollectionServices:IReportCollectionServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public ReportCollectionServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
       public async Task<ResponsePost<ReportCollectionModel>> Create(ReportCollectionModel reportCollection)
        {
            var response = await _httpClient.PostAsJsonAsync<ReportCollectionModel>($"{_baseUrl}/api/ReportCollection", reportCollection);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<ReportCollectionModel> result = JsonConvert.DeserializeObject<ResponsePost<ReportCollectionModel>>(await response.Content.ReadAsStringAsync());
                if(result?.Code == 0)
                {
                    return new ResponsePost<ReportCollectionModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }

            }
            else
            {
                return JsonConvert.DeserializeObject<ResponsePost<ReportCollectionModel>>(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<ResponseModel<ReportCollectionModel>> GetReportCollectionBybotId(int botId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ReportCollectionModel>>($"{_baseUrl}/api/ReportCollection/{botId}");
        }
        public async Task<ResponsGeneric<ReportCollectionModel>> GetReportCollectionById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<ReportCollectionModel>>($"{_baseUrl}/api/ReportCollection/GetById/{Id}");
        }
        public async Task<ResponseModel> UpdateReportCollection(ReportCollectionModel reportCollection)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/ReportCollection", reportCollection);
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
        public async Task<ResponseModel> DeleteReportCollection(int collectionId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/ReportCollection/{collectionId}");
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
    }
}
