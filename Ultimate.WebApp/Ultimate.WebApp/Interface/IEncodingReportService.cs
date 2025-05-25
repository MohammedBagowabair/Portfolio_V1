using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IEncodingReportService
    {
        Task<ResponsePost<EncodingReportDto>> Create(EncodingReportDto encodingReport);
        //Task<ResponseModel<ReportCollectionModel>> GetReportCollectionBybotId(int botId);
        Task<ResponseModel> UpdateEncodingReport(EncodingReportDto encodingReport);
        Task<ResponseModel> DeleteEncodingReport(int reportId);
    }
}
