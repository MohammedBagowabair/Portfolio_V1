using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class NotificationsModel
    {
        [RequiredAttr]
        public  List<int> userIds { set; get; }= new List<int>();


        [RequiredAttr]
        public  string content { set; get; }

        [RequiredAttr]
        public string content_type { set; get; } = "text";

        [RequiredAttr]
        public  string fileName { set; get; }

        [RequiredAttr]
        public  string description { set; get; }


        [RequiredAttr]
        public  string acutelyFileName { set; get; }

        [RequiredAttr]
        public  string mime { set; get; }   
    }
}
