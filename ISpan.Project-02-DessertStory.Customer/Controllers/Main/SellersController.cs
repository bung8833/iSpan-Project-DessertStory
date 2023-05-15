using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class SellersController : Controller
    {
        private readonly iSpanDessertShop2023MarchContext _db;
        public SellersController(iSpanDessertShop2023MarchContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var query = from s in _db.Sellers
                        join p in _db.Products on s.Id equals p.SellerId
                        join c in _db.Categories on p.CategoryId equals c.Id
                        group c by new { s.Id, s.StoreName, s.Picture } into g
                        select new SellersViewModel
                        {
                            Id = g.Key.Id,
                            StoreName = g.Key.StoreName,
                            Picture = g.Key.Picture,
                            MainProduct = g.GroupBy(x => x.Name)
                                            .OrderByDescending(x => x.Count())
                                            .Select(x => x.Key)
                                            .FirstOrDefault()
                        };

            var result = query.ToList();
            return View(result);

        }
    }
}
