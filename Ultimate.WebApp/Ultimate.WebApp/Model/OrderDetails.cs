namespace Ultimate.WebApp.Model
{
    public class OrderDetails
    {
        public virtual OrderModel orderDto { set; get; }
        public List<FileInformation> filesInformation { get; set; } = new List<FileInformation>();
    }
}
