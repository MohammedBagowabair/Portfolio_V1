namespace Ultimate.WebApp.Model
{
    public class BotFileModel
    {
        public int id { set; get; }
        public int botId { set; get; }
        public string fileName { set; get; }
        public string fileContent { set; get; }
        public string fileDescription { set; get; }
        public string mime { set; get; }
    }
}
