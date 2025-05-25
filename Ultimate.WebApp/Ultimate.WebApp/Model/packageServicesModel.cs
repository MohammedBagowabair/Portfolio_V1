namespace Ultimate.WebApp.Model
{
    public class packageServicesModel
    {
        public int id { get; set; }
        public string serviceName { get; set; }
        public string displayedserviceName { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public int packageId { get; set; }
        public List<PackagesModel> packageModel { get; set; }
    }
}
