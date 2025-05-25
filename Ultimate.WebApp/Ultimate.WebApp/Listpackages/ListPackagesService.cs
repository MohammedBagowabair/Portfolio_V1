using Blazored.LocalStorage;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.Listpackages
{
    public class ListPackagesService:IListPackagesService
    {
        private readonly ILocalStorageService _localStorageService;
        //private readonly IOrdersService _ordersService;

        public event Action Onchange;
        public ListPackagesService(
            ILocalStorageService localStorageService
            //IOrdersService ordersService
            )
        {
            _localStorageService=localStorageService;
            //_ordersService=ordersService;
        }
        public async Task AddToListPackages(PackageRelation packageRelation)
        {
            var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>> ("ListPackages");
            if(ListPackages == null)
            {
                ListPackages = new List<PackageRelation> ();
            }
            int x=ListPackages.Count;
            ListPackages.Add (new PackageRelation {
                id=x,
                orderId=x,
                package = packageRelation.package,
                packageId=packageRelation.packageId,
                userid=packageRelation.userid,
            });
            await _localStorageService.SetItemAsync("ListPackages", ListPackages);
            //var order=await _ordersService.GetOrderDetails(packageRelation.orderId);
            Onchange.Invoke();
        }
        public async Task<List<PackageRelation>> GetPackageItemsByUserId(int id)
        {
            var result = new List<PackageRelation>();
            var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackages");
            if (ListPackages == null)
            {
                return result;
            }
            foreach(var x in ListPackages)
            {
                if (x.userid == id)
                {
                    result.Add (x);
                }
            }
            return result;
        }
        public async Task<List<PackageRelation>> GetPackageItems()
        {
            var result=new List<PackageRelation> ();
            var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackages");
            if (ListPackages==null) 
            { 
                return result;
            }
            result = ListPackages;
            return result;
        }

        public async Task RemoveToListPackages(int id)
        {
            var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackages");
            if (ListPackages == null)
            {
                return;
            }
            var pack = ListPackages.Find(x => x.id == id);
            ListPackages.Remove(pack);
            for(int i= 0; i < ListPackages.Count; i++)
            {
                ListPackages[i].id=i;
                ListPackages[i].orderId = i;
            }
            await _localStorageService.SetItemAsync("ListPackages", ListPackages);
            Onchange.Invoke();
        }

        public async Task RemoveALLPackagesStorage()
        {
            var ListPackages = await _localStorageService.GetItemAsync<List<PackageRelation>>("ListPackages");
            ListPackages.Clear();
            await _localStorageService.SetItemAsync("ListPackages", ListPackages);
            Onchange.Invoke();
        }
    }
}
