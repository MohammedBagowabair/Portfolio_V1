namespace Ultimate.WebApp.Model
{
    public class PackageRelation
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int packageId { get; set; }
        public virtual PackagesModel package { get; set; }
        public int userid { get; set; }
        public bool isShowDetails = false;
    }
}
