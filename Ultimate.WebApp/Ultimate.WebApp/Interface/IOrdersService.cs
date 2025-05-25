using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IOrdersService
    {
        Task<ResponseModel<OrderModel>> GetOrders();
        Task<ResponsGeneric<OrderDetails>> GetOrderDetails(int orderId);
        Task<ResponseModel<OrderModel>> GetOrderGetByStatus(string status);
        Task<ResponseModel<OrderModel>> GetAllOrderByStatus(string status);
        Task<ResponsePost<ImageFile>> uploadFile(ImageFile imageFile);
        Task<ResponsePost<OrderModel>> addOrder(OrderModel orderModel);
        Task<ResponseModel> UpdateOrderStatus(OrderModel orderModel);
        Task<ResponseModel> Delete(int id);
        Task<ResponsePost<OrderModel>> AddRenewalOrder(int id);
        Task<ResponseModel<SubscriptionModel>> GetSubscriptionForExtend();
        Task<ResponseModel> ExtendSubscription(int? days,List<int> Ids);
        Task<ResponseModel> SendBillToEmail(int userId, int pckId, int lang);
    }
}
