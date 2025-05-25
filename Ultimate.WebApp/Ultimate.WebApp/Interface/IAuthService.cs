using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IAuthService
    {
        public Task<ResponseModel> Login(UserLoginModel userLogin);
        Task<ResponsePost<string>> Verify(DTOModel dto);
        Task<ResponseModel> Change(ChangePasswordModel changePassword);
        public Task Logout();
        public Task<ResponsGeneric<UsersModel>> GetUser(int id);
        
    }
}
