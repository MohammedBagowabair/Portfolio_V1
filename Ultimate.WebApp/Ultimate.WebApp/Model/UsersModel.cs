using Ultimate.WebApp.Pages.Client1;

namespace Ultimate.WebApp.Model
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public string phoneNumber { get; set; }
        public string verifyCode { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isVerified { get; set; }
        public bool isWhatAppPhoneVerified { get; set; }
        public int notificationOption { get; set; }
        public bool isShowDetails { get; set; }= false;
        public virtual List<UserStatisticsModel> UserStatistics { get; set; } = new List<UserStatisticsModel>();
        public List<ClientModel> clients { get; set; } = new List<ClientModel>();
        public List<SubscriptionModel> subscription { get; set; } = new List<SubscriptionModel>();
        public List<OrderModel> order { get; set; } = new List<OrderModel>();

    }
}
