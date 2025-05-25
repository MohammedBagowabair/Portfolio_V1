using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface ISendVerifyCodeService
    {
        Task<ResponsePost<string>> Create(int  userId);
    }
}
