namespace Ultimate.WebApp.Model
{
    public class OrderModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime orderTime { get; set; }
        public string status { get; set; }
        public string note { get; set; }
        public List<OrderFile> orderFiles { get; set; } = new List<OrderFile>();
        
        public virtual UserModel user { get; set; }
        public string type { get; set; }
        public List<PackageRelation> packageRelations { get; set; } = new List<PackageRelation>();
        //public List<FileInformation> filesInformation { get; set; } = new List<FileInformation>();
        public bool isShowPayment { get; set; } 
        public bool isShowDetails { get; set; } =false;
        public bool isReturned { get; set; } = false;
        
        
    }
}
