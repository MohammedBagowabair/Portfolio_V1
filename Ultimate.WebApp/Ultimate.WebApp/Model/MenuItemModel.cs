using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        [RequiredAttr]
        public string Title { get; set; }
        [RequiredAttr]
        public string Description { get; set; }
        [RequiredAttr]
        public string Action { get; set; }
        [RequiredAttr]
        public string ActionValue { set; get; }
        public bool isDeleted { get; set; } = false;

    }
}
