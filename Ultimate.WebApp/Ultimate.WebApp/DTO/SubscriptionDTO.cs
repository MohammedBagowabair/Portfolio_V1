using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.DTO
{
    public class SubscriptionDTO
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        public int userId { get; set; }
        public virtual UserModel user { get; set; }
        public int packageId { get; set; }
        public virtual PackagesModel package { get; set; }
        public List<SubscriptionServiceModel> subscriptionService { get; set; }
    }
}
