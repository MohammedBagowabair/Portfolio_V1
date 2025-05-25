using Ultimate.WebApp.Model.Validations;



namespace Ultimate.WebApp.Model
{
    //public class ExRequired : RequiredAttribute
    // {
    //     public ExRequired()
    //     {
    //         var localization = ActivatorUtilities.GetServiceOrCreateInstance<IStringLocalizer<Resource>>;
    //         this.ErrorMessage = localization["msg_Required"];
    //     }
    // }
    public class MenuModel : BaseModel
    {

        public int Id { get; set; }
        [RequiredAttr]
        public string MenuName { get; set; }
        [RequiredAttr]
        public string Body { get; set; }
        [RequiredAttr]
        public string ButtonText { get; set; }
        [RequiredAttr]
        public string Title { get; set; }
        [RequiredAttr]
        public string Footer { get; set; }
        [RequiredAttr]
        public string ItemTitle { get; set; }
        public int botId { get; set; }
        [RequiredAttr]
        public string Type { get; set; } = "M";
        public string structureType { get; set; }
        public int? TemplateId { get; set; }
        public List<MenuItemModel> Items { get; set; } = new List<MenuItemModel>();

    }
}
