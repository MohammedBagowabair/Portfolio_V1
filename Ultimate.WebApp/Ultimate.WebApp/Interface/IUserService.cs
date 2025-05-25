using Ultimate.WebApp.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IUserService
    {
        Task<ResponsePost<UserDto>> Create(UserModel userModel);
        Task<ResponsGeneric<bool>> IsUserSubScribed(int userId,string ServiceName);
         Task<ResponsGeneric<bool>> SendWhatsappVerifyCode(string whatsAppNumber);
        Task<ResponsGeneric<bool>> VerifyWhatsappPhone(string code);
        Task<ResponseModel<UsersModel>> GetAllUsers();
        Task<ResponsGeneric<bool>> IsUserHaveActiveSubscription(int userId);
    }
}
