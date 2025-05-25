using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class PeriodModel
    {
        public int id { get; set; }
        [RequiredAttr]
        public string name { get; set; }
        [RequiredAttr]
        public string foreignName { get; set; }
        [RequiredAttr]
        public string type { get; set; }
        [RequiredAttr]
        public int? value { get; set; }
    }
}
