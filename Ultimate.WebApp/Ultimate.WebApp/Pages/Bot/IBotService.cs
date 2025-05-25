using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Pages.Bot
{
    public interface IBotService
    {
        Task<ResponseModel<BotModel>> GetBot(int clientId);
        Task<ResponseModel<BotModel>> GetAllBot();
        Task<ResponseModel> Refresh();
        Task<ResponsePost<int>> UploadImage(BotFileModel botFileModel);
        Task<ResponsGeneric<BotFileModel>> GetFileById(int imgId);
        Task<ResponsePost<int>> UpdateImage(int imgId, BotFileModel botFileModel);
    }
}
