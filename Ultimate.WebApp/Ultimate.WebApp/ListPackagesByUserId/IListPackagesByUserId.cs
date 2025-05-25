using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.ListPackagesByUserId
{
    public interface IListPackagesByUserId
    {
        event Action Onchanges;
        Task AddToListPackagesByUserId(PackageRelation packageRelation,int UserId);
        Task<List<PackageRelation>> GetPackageItemsByUserId();
        Task<List<PackageRelation>> GetPackageByUserIdItemsByUserId(int id);
        Task RemoveToListPackagesByUserId(int id);
        Task RemoveALLPackagesByUserIdStorage();
    }
}
