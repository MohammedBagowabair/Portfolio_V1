using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IPeriodService
    {
        Task<ResponsePost<PeriodModel>> Create(PeriodModel periodModel);
        Task<ResponseModel<PeriodModel>> GetAll();
        Task<ResponseModel<PeriodModel>> GetById(int id);
        Task<ResponseModel> Delete(int id);
        Task Update(PeriodModel periodModel);

    }
}
