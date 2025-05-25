using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class EncodingReportService : IEncodingReportService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public EncodingReportService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];


        }
        public async Task<ResponsePost<EncodingReportDto>> Create(EncodingReportDto encodingReport)
        {
            var response = await _httpClient.PostAsJsonAsync<EncodingReportDto>($"{_baseUrl}/api/Report", encodingReport);
            if (response.IsSuccessStatusCode)
            {
                ResponsePost<EncodingReportDto> result = JsonConvert.DeserializeObject<ResponsePost<EncodingReportDto>>(await response.Content.ReadAsStringAsync());
                if (result?.Code == 0)
                {
                    return new ResponsePost<EncodingReportDto>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }

            }
            else
            {
                return JsonConvert.DeserializeObject<ResponsePost<EncodingReportDto>>(await response.Content.ReadAsStringAsync());
            }
        }
        public  async Task<ResponseModel> UpdateEncodingReport(EncodingReportDto encodingReport)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Report", encodingReport);
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
        public async Task<ResponseModel> DeleteEncodingReport(int reportId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Report/{reportId}");
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