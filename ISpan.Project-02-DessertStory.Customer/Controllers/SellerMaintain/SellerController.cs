using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Xml.Schema;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    public class SellerController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly iSpanDessertShop2023MarchContext _dbContext;
        
        private readonly HttpContext _httpContext;
        private readonly Seller? _seller;
        private readonly int _sellerId;

        public SellerController
            (IHttpContextAccessor httpContextAccessor, iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;

            _httpContext = _httpContextAccessor.HttpContext;
            
            // fetch user instance if is logined
            if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_SELLER))
            {
                string json = _httpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
                _seller = JsonSerializer.Deserialize<Seller>(json);
                _sellerId = _seller.Id;
            }
        }

        public IActionResult Index()
        {
            ViewBag.SellerAccount = "未登入";
            ViewBag.SellerPhoto = "anonymous.png";

            if (_seller != null)
            {
                ViewBag.SellerAccount = _seller.Account;
                ViewBag.SellerPhoto = String.IsNullOrEmpty(_seller.Picture)
                    ? "anonymous.png" : _seller.Picture;
            }

            return View();
        }
    }
}
