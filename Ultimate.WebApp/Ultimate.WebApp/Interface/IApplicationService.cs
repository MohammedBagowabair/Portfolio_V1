using Ultimate.Bot.Application.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IApplicationService
    {
        Task<ResponsePost<ApplicationModel>> Create(ApplicationModel applicationModel);
        Task<ResponseModel<ApplicationModel>> GetById(int id);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> RefreshSecret(int id);
        Task Update(int id,ApplicationModel applicationModel);
    }
}
