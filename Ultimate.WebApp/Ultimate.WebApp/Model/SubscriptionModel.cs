using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Ultimate.WebApp.Model
{
    public class SubscriptionModel
    {
        [AllowNull]
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        public int userId { get; set; }
        public virtual UserModel user { get; set; }
        public int packageId { get; set; }
        public int orderId { get; set; }
        public bool isActive { get; set; }
        public virtual OrderModel order { get; set; }
        public virtual PeriodModel period { get; set; }
        public virtual PackagesModel package { get; set; }
        public List<SubscriptionServiceModel> subscriptionService { get; set; }
        public bool isShowDetails = false;
        public bool isReturned = false;
    }
}
