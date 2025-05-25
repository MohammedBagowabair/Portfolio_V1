using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface INotificationServices
    {
        Task<ResponseModel> SendNotification(NotificationsModel notification);
        Task<ResponsGeneric<bool>> UpdateNotifications(int option, List<int> Ids);
    }
}
