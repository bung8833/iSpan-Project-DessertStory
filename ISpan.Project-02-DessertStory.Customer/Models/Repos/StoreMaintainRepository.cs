using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;

namespace ISpan.Project_02_DessertStory.Customer.Models.Repos
{
    public class StoreMaintainRepository
    {
        private readonly iSpanDessertShop2023MarchContext _db;

        public StoreMaintainRepository(iSpanDessertShop2023MarchContext db)
        {
            _db = db; // 注入
        }
        public StoreSettingViewModel QueryByStoreId(int? Id)
        {
            if(Id==null){
                return new StoreSettingViewModel();
            }
            else
            {
                var q = _db.Sellers.FirstOrDefault(s => s.Id == Id);
                if(q != null)
                {
                    return new StoreSettingViewModel() { Id = q.Id, StoreName = q.StoreName, Description = q.Description, Picture = q.Picture };
                }
                return new StoreSettingViewModel();
            }
        }

        //public void UpdateStoreInformation(StoreSettingViewModel vm)
        //{
        //    if (vm != null)
        //    {
        //        if (vm.Id != null)
        //        {
        //            var q = _db.Sellers.FirstOrDefault(s => s.Id == vm.Id);
        //            q.StoreName = vm.StoreName;
        //            q.Description = vm.Description;
        //            q.Picture = vm.Picture;
        //            _db.SaveChanges();
        //        }
        //    }
        //}
    }
}
