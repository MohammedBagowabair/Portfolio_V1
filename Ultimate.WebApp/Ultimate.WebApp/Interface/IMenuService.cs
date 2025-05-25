using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IMenuService
    {
        Task<ResponsePost<MenuModel>> Create(MenuModel menuModel);
        Task<ResponseModel<MenuModel>> GetMenuBybotId(int botId,string type);
        Task<ResponseModel<MenuModel>> GetMenuById(int menuId);
        Task<ResponseModel> UpdateMenu(MenuModel menuModel);
        Task<ResponseModel> DeleteMenu(int id);
        Task<ResponseModel<TemplateModel>> GetTemplate();
        Task<ResponseModel<MenuModel>> SetDefaultMenu(int botId,int tempId);
    }
}
