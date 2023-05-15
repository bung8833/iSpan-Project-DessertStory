using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;
using System.Text.Json;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.EntityFrameworkCore;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    /// <summary>
    /// 賣家相關設定
    /// </summary>
    public class SellerSettingController : SellerSuperController
    {
        private readonly iSpanDessertShop2023MarchContext _db;
        private readonly IPasswordHasher _passwordHasher;
        //private Seller _seller;
        //private readonly int _sellerId;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly HttpContext _httpContext;

        public SellerSettingController(IPasswordHasher passwordHasher,iSpanDessertShop2023MarchContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db; // 注入
            _sellerId = _seller.Id;
            _passwordHasher = passwordHasher;
            // DI
            //    _httpContextAccessor = httpContextAccessor;
            //    _httpContext = _httpContextAccessor.HttpContext;
            //    if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_SELLER))
            //    {
            //        string json = _httpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
            //        _seller = JsonSerializer.Deserialize<Seller>(json);
            //        _sellerId = _seller.Id;
            //        ViewBag.SellerId = _seller.Id;
            //        ViewBag.SellerAccount = _seller.Account;
            //        ViewBag.SellerPicture = _seller.Picture;
            //        ViewBag.SellerName = _seller.LastName + _seller.FirstName;
            //    }
        }

        public IActionResult List(int? Id)
        {
            Id = _sellerId;
            if (Id == null)
            {
                
                //404的畫面
                //return NotFound();
            }
            if (Id != null)
            {
                var seller = _db.Sellers.FirstOrDefault(s => s.Id == Id);
                //var sellers = _db.Sellers.ToList();
                //var sellerViewModels = sellers.Select(s => new SellerSettingViewModel { Id = s.Id, Account = s.Account,Password = s.Password,Email = s.Email,ContactNumber = s.ContactNumber}).Where(s=>s.Id == Id);
                return View(seller);
            }
            return NotFound();
        }


        /// <summary>
        /// 使用者設定頁面，依據使用者ID顯示資料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? Id)
        {
            var seller = _db.Sellers.FirstOrDefault(s => s.Id == Id);
            //var sellers = _db.Sellers.ToList();
            //var sellerViewModels = sellers.Select(s => new SellerSettingViewModel { Id = s.Id, Account = s.Account,Password = s.Password,Email = s.Email,ContactNumber = s.ContactNumber}).Where(s=>s.Id == Id);
            return View(seller);
        }

        /// <summary>
        /// 修改使用者資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditAccount(SellerSettingViewModel vm)
        {
            var seller = _db.Sellers.FirstOrDefault(s => s.Id == vm.Id);
            if (seller != null)
            {
                //seller.Account = vm.Account;
                if (vm.Password != null)
                {
                    seller.Password = vm.Password;
                }
                if (vm.Email != null)
                {
                    seller.Email = vm.Email;
                }
                if (vm.ContactNumber != null)
                {
                    seller.ContactNumber = vm.ContactNumber;
                }
            }
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult PasswordList(SellerPasswordViewModel vm)
        {
            vm.Id = _sellerId;
            var seller = _db.Sellers.FirstOrDefault(s => s.Id == vm.Id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult PasswordUpdate(SellerPasswordViewModel vm)
        {
            var seller = _db.Sellers.FirstOrDefault(s => s.Id == vm.Id);
            var passwordHash = _passwordHasher.Hash(vm.SellerNewPassword);
            //if (!ModelState.IsValid)
            //{
            //    return View(vm);
            //}
            if (seller != null)
            {
                //seller.Account = vm.Account;
                if (vm.SellerNewPassword != null)
                {
                    seller.Password = vm.SellerNewPassword;
                    seller.PasswordSalt = passwordHash;
                }
            }
            _db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
