using Ultimate.Bot.Application.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IAutomessageService
    {
        Task<ResponsePost<AutoMessageModel>> Create(AutoMessageModel autoMessageModel);
        Task<ResponsePost<AutoMessageDto>> CreateDto(AutoMessageDto autoMessageDto);
        Task<ResponseModel<AutoMessageModel>> GetAll();
        Task<ResponseModel<AutoMessageModel>> GetById(int id);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> Update(AutoMessageModel autoMessageModel);
        Task<ResponseModel> UpdateDto(AutoMessageDto autoMessageDto);



    }
}
