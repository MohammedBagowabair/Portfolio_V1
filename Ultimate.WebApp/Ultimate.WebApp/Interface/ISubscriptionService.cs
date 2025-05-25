using Ultimate.WebApp.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface ISubscriptionService
    {
        Task<ResponsePost<SubscriptionModel>> Create(SubscriptionModel subscriptionModel);
        Task<ResponseModel<SubscriptionModel>> GetAll();
        Task<ResponsGeneric<SubscriptionModel>> GetById(int Id);
        Task<ResponseModel> Update(SubscriptionModel subscriptionModel, int subscriptionId);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel<SubscriptionModel>> GetRequestedStatus();
        Task<ResponsGeneric<bool>> isFree(int UserId);
        Task<ResponsGeneric<SubscriptionModel>> ThePostOfFreeSubscription(int packId);
    }
}
