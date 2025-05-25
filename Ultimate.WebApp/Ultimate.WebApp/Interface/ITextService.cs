using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface ITextService
    {
        Task<ResponsePost<TextModel>> Create(TextModel textModel);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel<TextModel>> GetByBotId(int BotId);
        Task<ResponseModel<TextModel>> GetByClientId(int ClientId);
        Task Update(TextModel textModel);
    }
}
