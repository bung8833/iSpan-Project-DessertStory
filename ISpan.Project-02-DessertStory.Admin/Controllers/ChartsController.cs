using ISpan.Project_02_DessertStory.Admin.Models.EF;
using ISpan.Project_02_DessertStory.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class ChartsController : SuperController
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public ChartsController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }
        public IActionResult List()
        {
            var member = from m in _ISpan.Members
                         select m;
            var seller = from s in _ISpan.Sellers
                         select s;
            var product = from p in _ISpan.Products
                          select p;
            var order = from o in _ISpan.Orders
                         select o;
            ChartsViewsModel charts= new ChartsViewsModel {
                Members= member,
                Sellers= seller,
                Products= product,
                Orders= order
            };
            return View(charts);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
