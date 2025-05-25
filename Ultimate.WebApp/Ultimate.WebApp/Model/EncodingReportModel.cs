using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class EncodingReportModel
    {
        public int id { get; set; }
        [RequiredAttr]
        public string name { get; set; }
        [RequiredAttr]
        public string type { get; set; }
        [RequiredAttr]
        public int reportCollectionId { get; set; }
        [RequiredAttr]
        public int reportTemplateId { get; set; }
        [RequiredAttr]
        public int? erpMsgNo { get; set; }
        public virtual ReportTemplateModel reportTemplate { get; set; }

    }
}
