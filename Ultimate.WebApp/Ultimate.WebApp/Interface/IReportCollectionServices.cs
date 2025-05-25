using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IReportCollectionServices
    {
        Task<ResponsePost<ReportCollectionModel>> Create(ReportCollectionModel reportCollection);
        Task<ResponseModel<ReportCollectionModel>> GetReportCollectionBybotId(int botId);
        Task<ResponsGeneric<ReportCollectionModel>> GetReportCollectionById(int Id);
        Task<ResponseModel> UpdateReportCollection(ReportCollectionModel reportCollection);
        Task<ResponseModel> DeleteReportCollection(int collectionId);
    }
}
