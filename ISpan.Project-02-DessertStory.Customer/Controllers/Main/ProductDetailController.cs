using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class ProductDetailController : Controller
    {
        public readonly iSpanDessertShop2023MarchContext _db;
        public ProductDetailController(iSpanDessertShop2023MarchContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Report(ReportViewModel vm)
        {
            if (vm != null)
            {
                var data = new Report
                {
                    Reporter = vm.Rname,
                    Reportcategory = vm.Reportcategory,
                    Reportreason = vm.Reportreason,
                    Detail = vm.Detail
                };
                _db.Reports.Add(data);
                _db.SaveChanges();
            }
            return Redirect(vm.Detail);
        }
        public IActionResult List(int? Id)
        {
            if (Id != null)
            {
                var q = _db.Products.FirstOrDefault(p => Id == p.Id);
                if (q != null)
                {
                    var productVm = new ProductDetailViewModel
                    {
                        Id = q.Id,
                        Picture1 = q.Picture1,
                        Picture2 = q.Picture2,
                        Picture3 = q.Picture3,
                        ProductName = q.ProductName,
                        ProductSize = q.ProductSize,
                        UnitPrice = q.UnitPrice,
                        Description = q.Description,
                        OrderQuantity = 1,
                    };
                    return View(productVm);
                }
            }
            return View();
        }

        //var q = _db.Products.FirstOrDefault(p => p.Id == Id);
        //if (q != null)
        //{
        //    return new SellerProductsDto
        //    {
        //        Id = q.Id,
        //        ProductName = q.ProductName,
        //        ProductSize = q.ProductSize,
        //        Picture1 = q.Picture1,
        //        Picture2 = q.Picture2,
        //        Picture3 = q.Picture3,
        //        UnitPrice = q.UnitPrice,
        //        UnitsInStock = q.UnitsInStock
        //    };
        //}
    }
}
