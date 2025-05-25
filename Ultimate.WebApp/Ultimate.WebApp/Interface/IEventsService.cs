using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IEventsService
    {
        Task<ResponseModel<MenuModel>> GetMenu(int botId,string structureType);
    }
}
