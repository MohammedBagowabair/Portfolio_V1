using Blazored.LocalStorage;
using Ultimate.WebApp.Listpackages;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.ListPackagesByUserId
{
    public class ListPackagesByUserId: IListPackagesByUserId
    {
            private readonly ILocalStorageService _localStorageService;
            //private readonly IOrdersService _ordersService;

            public event Action Onchanges;
            public ListPackagesByUserId(
                ILocalStorageService localStorageService
                //IOrdersService ordersService
                )
            {
                _localStorageService = localStorageService;
                //_ordersService=ordersService;
            }
            public async Task AddToListPackagesByUserId(PackageRelation packageRelation,int UserId)
            {
                var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackagesByUserId");
                if (ListPackages == null)
                {
                    ListPackages = new List<PackageRelation>();
                await _localStorageService.SetItemAsync("ListPackagesByUserId", ListPackages);
                //var order=await _ordersService.GetOrderDetails(packageRelation.orderId);
                
            }
                
            if (UserId == packageRelation.userid)
            {
                int x = ListPackages.Count;
                ListPackages.Add(new PackageRelation
                {
                    id = x,
                    orderId = x,
                    package = packageRelation.package,
                    packageId = packageRelation.packageId,
                    userid = packageRelation.userid,
                });
                await _localStorageService.SetItemAsync("ListPackagesByUserId", ListPackages);
                //var order=await _ordersService.GetOrderDetails(packageRelation.orderId);
                
            }
            //Onchanges.Invoke();
        }
            public async Task<List<PackageRelation>> GetPackageByUserIdItemsByUserId(int id)
            {
                var result = new List<PackageRelation>();
                var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackagesByUserId");
                if (ListPackages == null)
                {
                    return result;
                }
                foreach (var x in ListPackages)
                {
                    if (x.userid == id)
                    {
                        result.Add(x);
                    }
                }
                return result;
            }
            public async Task<List<PackageRelation>> GetPackageItemsByUserId()
            {
                var result = new List<PackageRelation>();
                var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackagesByUserId");
                if (ListPackages == null)
                {
                    return result;
                }
                result = ListPackages;
                return result;
            }

            public async Task RemoveToListPackagesByUserId(int id)
            {
                var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackagesByUserId");
                if (ListPackages == null)
                {
                    return;
                }
                var pack = ListPackages.Find(x => x.id == id);
                ListPackages.Remove(pack);
                for (int i = 0; i < ListPackages.Count; i++)
                {
                    ListPackages[i].id = i;
                    ListPackages[i].orderId = i;
                }
                await _localStorageService.SetItemAsync("ListPackagesByUserId", ListPackages);
                //Onchanges.Invoke();
            }

            public async Task RemoveALLPackagesByUserIdStorage()
            {
                var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackagesByUserId");
                ListPackages.Clear();
                await _localStorageService.SetItemAsync("ListPackagesByUserId", ListPackages);
                //Onchanges.Invoke();
            }

    }
}

