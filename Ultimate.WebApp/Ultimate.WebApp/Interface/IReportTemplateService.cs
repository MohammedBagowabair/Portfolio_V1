using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IReportTemplateService
    {
        Task<ResponseModel<ReportTemplateModel>> GetReportTemplates();
    }
}
