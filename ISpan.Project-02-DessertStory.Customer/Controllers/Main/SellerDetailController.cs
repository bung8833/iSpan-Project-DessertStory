using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class SellerDetailController : Controller
    {
        private readonly iSpanDessertShop2023MarchContext _db;
        public SellerDetailController(iSpanDessertShop2023MarchContext db)
        {
            _db = db; // 注入
        }
        public IActionResult Index(int? Id)
        {
            try
            {
                var q = _db.Sellers.FirstOrDefault(s => Id == s.Id);
                if (q != null)
                {
                    var sellerVm = new SellerDetailViewModel
                    {
                        Id = q.Id,
                        StoreName = q.StoreName,
                        Picture = q.Picture,
                        Description = q.Description,
                        Address = q.Address,
                        Phone = q.ContactNumber,
                    };
                    return View(sellerVm);
                }
            }
            catch
            {
                return RedirectToAction("Index", "ErrorPage");
            }

            return View();
        }
        
    }
}
