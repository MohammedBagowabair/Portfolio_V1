namespace Ultimate.WebApp.Model
{
    public class SubscriptionServiceModel
    {
        public int id { get; set; }
        public string serviceName { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public string status { get; set; }
        public int subscriptionId { get; set; }
        public virtual SubscriptionModel subscription { get; set; }
    }
}
