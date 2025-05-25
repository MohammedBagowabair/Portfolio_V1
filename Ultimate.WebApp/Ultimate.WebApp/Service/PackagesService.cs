using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class PackagesService:IPackagesService
    {
        //private readonly IHttpServiec _httpServiec;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public PackagesService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
        public async Task<ResponsePost<PackagesModel>> Create(PackagesModel packagesModel)
        {
            var response = await _httpClient.PostAsJsonAsync<PackagesModel>($"{_baseUrl}/api/Package", packagesModel);
            if(response.IsSuccessStatusCode)
            {
                ResponsePost<PackagesModel> result = JsonConvert.DeserializeObject<ResponsePost<PackagesModel>>(await response.Content.ReadAsStringAsync());
                if(result?.Code==0)
                {
                    return new ResponsePost<PackagesModel>() { Code = 0, Message = result.Message };
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
        public  async Task<ResponseModel<PackagesModel>> GetPackages()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<PackagesModel>>($"{_baseUrl}/api/Package");
        }
        public async Task<ResponsGeneric<PackagesModel>> GetPackageById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponsGeneric<PackagesModel>>($"{_baseUrl}/api/Package/{Id}");
        }
        public async Task<ResponseModel> UpdatePackage(PackagesModel packagesModel, int pckId)
        {
            var response = await _httpClient.PutAsJsonAsync<PackagesModel>($"{_baseUrl}/api/Package/{pckId}", packagesModel);
            if(response.IsSuccessStatusCode)
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
        public async Task<ResponseModel> DeletePackage(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Package/{id}");
            if(response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                if(result?.Code==0)
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
