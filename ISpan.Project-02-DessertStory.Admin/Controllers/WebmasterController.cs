using ISpan.Project_02_DessertStory.Admin.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class WebmasterController : Controller
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public WebmasterController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Advertise advertise)
        {
            var data = _ISpan.Advertises.ToList();
            foreach (var item in data)
            {
                if ((item.Tstarttime < advertise.Tstarttime && advertise.Tstarttime < item.Tendtime) || (item.Tstarttime < advertise.Tendtime && advertise.Tendtime < item.Tendtime))
                {
                    ViewBag.err = "此時間段已有廣告插入";
                    return View();
                }
            }
            _ISpan.Advertises.Add(advertise);
            _ISpan.SaveChanges();
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
