namespace Ultimate.WebApp.Model
{
    public class UserStatisticsModel
    {
        //public int Id { get; set; }
        //public string lastStartSubscription { get; set; }
        //public string lastEndSubscription { get; set; }
        //public int allUserClients { get; set; }
        //public int allUserMenus { get; set; }
        //public int NumberofUserSubscriptions { get; set; }
        //public int NumberOfFinishedSubscriptions { get; set; }
        //public int NumberOfSubscriptionsRemaining { get; set; }
        public int Id { get; set; }
        public DateTime lastStartSubscriptionDate { get; set; }
        public DateTime lastEndSubscriptionDate { get; set; }
        public int allClientUserHave { get; set; }
        public int allClientUserUsed { get; set; }
        public int allMenusUserHave { get; set; }
        public int allMenusUserUsed { get; set; }
        public int allMessageUsersHave { get; set; }
        
        public int theNumberOfSubscriptionUserHave { get; set; }
        public int theNumberOfFinishedSubscription { get; set; }
        public int theNumberOfSubscriptionsRemaining { get; set; }
    }
}
