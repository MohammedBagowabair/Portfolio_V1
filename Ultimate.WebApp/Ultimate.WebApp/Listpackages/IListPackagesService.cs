using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Listpackages
{
    public interface IListPackagesService
    {
        event Action Onchange;
        Task AddToListPackages(PackageRelation packageRelation);
        Task<List<PackageRelation>> GetPackageItems();
        Task<List<PackageRelation>> GetPackageItemsByUserId(int id);
        Task RemoveToListPackages(int id);
        Task RemoveALLPackagesStorage();
    }
}
