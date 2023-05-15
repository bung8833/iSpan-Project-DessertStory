using ISpan.Project_02_DessertStory.Customer.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    public class AuthenticateController : Controller
    {
        private readonly iSpanDessertShop2023MarchContext _db; // 将 YourDbContext 替换为您的实际 DbContext 类

        public AuthenticateController(iSpanDessertShop2023MarchContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("authenticate")]
        public IActionResult Authenticate(string uid)
        {
            bool result = _db.Sellers.Any(s => s.EmailToken.Contains(uid));
            //在此處執行驗證的邏輯
            //可以將傳入的令牌與存儲的值進行比較或執行其他必要的檢查

            if (result)
            {
                // 驗證成功
                // 可以更新使用者的驗證狀態或執行其他所需的操作
                Seller seller = _db.Sellers.FirstOrDefault(s => s.EmailToken == uid);
                seller.EmailStatus = true;
                _db.SaveChanges();

                return View("VerificationSuccess");
            }

            // 令牌無效或驗證失敗
            return View("VerificationFailure");
        }
    }
}
