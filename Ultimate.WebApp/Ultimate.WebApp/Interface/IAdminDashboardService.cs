using System.Runtime.InteropServices;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IAdminDashboardService
    {
        Task<ResponsGeneric<AllStatisticsModel>> GetAllStatisticsNumber([Optional]string fDate, [Optional]string lDate);
        Task<ResponseModel<UsersModel>> GetAllSubscribedUsers([Optional] string fDate, [Optional] string lDate);
        Task<ResponseModel<UserStatisticsModel>> GetUserStatisticsSummary(int userId);
        Task<ResponseModel<SubscriptionModel>> GetUserStatisticsDetails(int userId);
    }
}
