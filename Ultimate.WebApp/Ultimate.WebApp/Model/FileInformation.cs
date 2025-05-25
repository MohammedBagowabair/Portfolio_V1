namespace Ultimate.WebApp.Model
{
    public class FileInformation
    {
        public string fileContent { get; set; }
        public string fileDescription { get; set; }
        public string fileType { get; set; }
        public OrderFile OrderFile { get; set; }
    }
}
