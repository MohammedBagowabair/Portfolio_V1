using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class ReportCollectionModel
    {
        public int id { get; set; }
        [RequiredAttr]
        public string name { get; set; }
        public int botId { get; set; }
        public List<EncodingReportModel> reports { get; set; }= new List<EncodingReportModel>();
        public bool isShowReports { get; set; }
    }
}
