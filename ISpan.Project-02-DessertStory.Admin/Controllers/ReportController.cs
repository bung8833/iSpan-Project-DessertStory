using ISpan.Project_02_DessertStory.Admin.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class ReportController : SuperController
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public ReportController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }
        public IActionResult List()
        {
            var data = _ISpan.Reports.ToList();
            return View(data);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
