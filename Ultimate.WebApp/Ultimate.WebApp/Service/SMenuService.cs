using Newtonsoft.Json;
using System.Net.Http.Json;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Service
{
    public class SMenuService : ISMenuService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public SMenuService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = configuration["BaseApiUrl"];

        }
        public async Task<ResponsePost<MenuModel>> Create(MenuModel menuModel)
        {
            var response = await _httpClient.PostAsJsonAsync<MenuModel>($"{_baseUrl}/api/Menu/smenu", menuModel);
            ResponsePost<MenuModel> result = JsonConvert.DeserializeObject<ResponsePost<MenuModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                if (result?.Code == 0)
                {

                    return new ResponsePost<MenuModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                if (result.Code == 3003 || result.Code == 3001 || result.Code == 4004)
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
        public async Task<ResponseModel<MenuModel>> GetMenuBybotId(int botId, string type)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<MenuModel>>($"{_baseUrl}/api/Menu/get/{botId}/{type}");
        }
        public async Task<ResponseModel<MenuModel>> GetMenuById(int menuId)
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<MenuModel>>($"{_baseUrl}/api/Menu/id/{menuId}");
        }
        public async Task<ResponseModel> UpdateMenu(MenuModel menuModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Menu", menuModel);
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
                if (result.Code == 3003 || result.Code == 4004)
                {
                    return result;
                }
                else
                {
                    throw new Exception($"status code:{response.StatusCode},response:{await response.Content.ReadAsStringAsync()}");
                }
            }
        }
        public async Task<ResponseModel> DeleteMenu(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Menu/{id}");
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

        public async Task<ResponseModel<TemplateModel>> GetTemplate()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<TemplateModel>>($"{_baseUrl}/api/Template/ge");
        }
        public async Task<ResponseModel<MenuModel>> SetDefaultMenu(int botId, int tempId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Menu/SetDefaultMenu?botId={botId}&templateId={tempId}", null);
            ResponseModel<MenuModel> result = JsonConvert.DeserializeObject<ResponseModel<MenuModel>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                if (result?.Code == 0)
                {

                    return new ResponseModel<MenuModel>() { Code = 0, Message = result.Message };
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                if (result.Code == 3003 || result.Code == 3001 || result.Code == 4004)
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

        public async Task<ResponseModel<MenuModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<ResponseModel<MenuModel>>($"{_baseUrl}/api/Menu/smenu");
        }
    }
}
