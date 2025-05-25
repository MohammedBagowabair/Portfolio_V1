using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface ISMenuService
    {
        Task<ResponsePost<MenuModel>> Create(MenuModel menuModel);
        Task<ResponseModel<MenuModel>> GetAll();
        Task<ResponseModel<MenuModel>> GetMenuById(int menuId);
        Task<ResponseModel> UpdateMenu(MenuModel menuModel);
        Task<ResponseModel> DeleteMenu(int id);
    }
}
