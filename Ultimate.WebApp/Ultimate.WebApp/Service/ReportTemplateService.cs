using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class ReportTemplateService: IReportTemplateService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public ReportTemplateService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
        public async Task<ResponseModel<ReportTemplateModel>> GetReportTemplates()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<ReportTemplateModel>>($"{_baseUrl}/api/Report/GetAllTemplateReport");
        }
    }
}
