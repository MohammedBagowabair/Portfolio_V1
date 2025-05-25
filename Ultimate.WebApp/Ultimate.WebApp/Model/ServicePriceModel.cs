using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class ServicePriceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        [RequiredAttr]
        public string serviceName { get; set; }
        [RequiredAttr]
        public double price { get; set; }
        public int periodId { get; set; }
        public virtual PeriodModel periodModel { get; set; }
    }
}
