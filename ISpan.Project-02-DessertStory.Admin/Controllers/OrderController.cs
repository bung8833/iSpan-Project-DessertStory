using ISpan.Project_02_DessertStory.Admin.Models.EF;
using ISpan.Project_02_DessertStory.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class OrderController : SuperController
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public OrderController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }

        public IActionResult List(int? page, QueryKeywordViewModel vm)
        {
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            IEnumerable<Order> order = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
            {
                order = _ISpan.Orders.
                    Include(s => s.Seller).
                    Include(m => m.Member).
                    Include(od => od.OrderDetails).ThenInclude(p => p.Product).
                    ToPagedList(pagenumber, pagesize);
            }
            else
            {
                order = _ISpan.Orders.
                    Include(s => s.Seller).
                    Include(m => m.Member).
                    Include(od => od.OrderDetails).ThenInclude(p => p.Product).
                    Where(o => o.Member.FirstName.Contains(vm.txtKeyword)
                            || o.Member.LastName.Contains(vm.txtKeyword))
                              .ToPagedList(pagenumber, pagesize);
            }
            return View(order);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
