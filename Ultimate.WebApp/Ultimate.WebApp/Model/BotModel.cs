using System.ComponentModel;

namespace Ultimate.WebApp.Model
{
    public class BotModel
    {

        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Initcmnd { get; set; }

        [DefaultValue(false)]
        public bool Inactive { get; set; }
        public List<AutoMessageModel> AutoMessages { get; set; } = new List<AutoMessageModel>();
        public List<MenuModel> Menus { get; set; } = new List<MenuModel>();




    }
}
