using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Interface
{
    public interface IPackagesService
    {
        Task<ResponsePost<PackagesModel>> Create(PackagesModel packagesModel);
        Task<ResponseModel<PackagesModel>> GetPackages();
        Task<ResponsGeneric<PackagesModel>> GetPackageById(int Id);
        Task<ResponseModel> UpdatePackage(PackagesModel packagesModel,int pckId);
        Task<ResponseModel> DeletePackage(int id);
    }
}
