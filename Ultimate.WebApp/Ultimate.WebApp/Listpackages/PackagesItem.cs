using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Listpackages
{
    public class PackagesItem
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string description { get; set; }
        public double disCount { get; set; }
        public int periodId { get; set; }
        public virtual PeriodModel period { get; set; }
        public List<packageServicesModel> packageServices { set; get; } = new List<packageServicesModel>();

    }
}
