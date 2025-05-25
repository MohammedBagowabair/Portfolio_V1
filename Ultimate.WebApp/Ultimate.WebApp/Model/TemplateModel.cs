namespace Ultimate.WebApp.Model
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<MenuModel> sMenu { get; set; } = new List<MenuModel>();
        public string displayTemplateDetails { get; set; } = "none";
    }
}
