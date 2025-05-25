using Ultimate.Bot.Application.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IClientService
    {
        Task<ResponsePost<ClientModel>> Create(ClientModel clientModel);
        Task<ResponseModel<ClientModel>> GetClients();
        Task<ResponseModel<ClientModel>> GetAllClients();
        Task<ResponseModel<ClientModel>> GetClientById(int id);
        Task<ResponseModel> DeleteClient(int clientId, int userId);
        Task<ResponseModel>IsConnected(int clientId);
        Task<ResponseAdd<T>> getQr<T>(int id);
        Task<ResponseModel> Update(ClientModel clientModel);
        Task<ResponsGeneric<string>> logOut(int clnId);
        Task<ResponsGeneric<bool>> exitClient();
        Task<ResponsGeneric<bool>> runClient();
    }
}
