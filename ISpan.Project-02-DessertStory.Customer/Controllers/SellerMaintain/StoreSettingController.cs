using Microsoft.AspNetCore.Mvc;
using System;
using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;
using ISpan.Project_02_DessertStory.Customer.Models.Repos;
using System.Text.Json;
using ISpan.Project_02_DessertStory.Customer.Models.Services;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    /// <summary>
    /// 賣場相關設定
    /// </summary>



    public class StoreSettingController : SellerSuperController
    {
        private readonly iSpanDessertShop2023MarchContext _db;
        private readonly StoreMaintainRepository _repo;
        //private Seller _seller;
        private readonly int _sellerId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;

        //var repo = new StoreMaintainRepository(_db);
        IWebHostEnvironment _enviro;

        public StoreSettingController(iSpanDessertShop2023MarchContext db, IWebHostEnvironment p)
        {
            _db = db; // 注入
            _repo = new StoreMaintainRepository(_db);
            _enviro = p;
            _sellerId = _seller.Id;
            //_httpContextAccessor = httpContextAccessor;
            //_httpContext = _httpContextAccessor.HttpContext;
            //if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_SELLER))
            //{
            //    string json = _httpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
            //    _seller = JsonSerializer.Deserialize<Seller>(json);
            //    _sellerId = _seller.Id;
            //    ViewBag.SellerId = _seller.Id;
            //    ViewBag.SellerAccount = _seller.Account;
            //    ViewBag.SellerPicture = _seller.Picture;
            //    ViewBag.SellerName = _seller.LastName + _seller.FirstName;
            //}
        }

        public IActionResult List(int? Id)
        {
            if (Id == null)
            {
                Id = _seller.Id;
            }
            var storeInformation = _repo.QueryByStoreId(Id);
            return View(storeInformation);
        }
        public IActionResult Edit(int? Id)
        {
            //Id = _storeID;
            var storeInformation = _repo.QueryByStoreId(Id);
            return View(storeInformation);
        }

        //[HttpPost]
        //public IActionResult Edit(StoreSettingViewModel vm)
        //{
        //    //vm.Id = _storeID;
        //    _repo.UpdateStoreInformation(vm);
        //    return RedirectToAction("List");
        //}
        [HttpPost]
        public IActionResult EditStoreInformation(StoreSettingViewModel vm)
        {
            //dbDemoContext db = new dbDemoContext();
            var seller = _db.Sellers.FirstOrDefault(s => s.Id == vm.Id);
            if (seller != null)
            {
                if (vm.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    string path = _enviro.WebRootPath + "/images/" + photoName;
                    vm.photo.CopyTo(new FileStream(path, FileMode.Create));
                    seller.Picture = photoName;
                }
                seller.StoreName = vm.StoreName;
                seller.Description = vm.Description;
                _db.SaveChanges();
            }
            return RedirectToAction("List", new { vm.Id });
        }
    }
}
