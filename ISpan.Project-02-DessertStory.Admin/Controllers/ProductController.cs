using ISpan.Project_02_DessertStory.Admin.Models.EF;
using ISpan.Project_02_DessertStory.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class ProductController : SuperController
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public ProductController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }
        [HttpGet]
        public IActionResult Productsus(int id, bool status)
        {
            Product product = _ISpan.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.ProductStatus = status;
                _ISpan.SaveChanges();
            }

            return RedirectToAction("List");
        }
        public IActionResult List(int? page,QueryKeywordViewModel vm)
        {
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            IEnumerable<Product> prod = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
            {            
                 prod = _ISpan.Products.Include(s => s.Seller).ToPagedList(pagenumber,pagesize);
            }
            else
            {
                prod = _ISpan.Products.Include(s => s.Seller).Where(p => p.ProductName.Contains(vm.txtKeyword)).ToPagedList(pagenumber,pagesize);
            }
            ViewBag.seachstring = vm.txtKeyword;
            return View(prod);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
