using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class ProductsController : Controller
    {
        public readonly iSpanDessertShop2023MarchContext _db;
        public ProductsController(iSpanDessertShop2023MarchContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var q = _db.Categories.Select(p => p).ToList();

            return View(q);
        }

        [HttpPost]
        public IActionResult GetProducts(int? sellerId)
        {
            var datas = from p in _db.Products
                        join s in _db.Sellers on p.SellerId equals s.Id
                        join c in _db.Categories on p.CategoryId equals c.Id
                        where p.ProductStatus == true && sellerId == s.Id
                        select new ProductsQuertServiceViewModel
                        {
                            ProductId = p.Id,
                            CategoryId = p.CategoryId,
                            CategoryName = c.Name,
                            SellerId = p.SellerId,
                            StoreName = s.StoreName,
                            SellerDescription = s.Description,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            ProductDescription = p.Description,
                            Picture1 = p.Picture1,
                            Picture2 = p.Picture2,
                            Picture3 = p.Picture3,
                        };
            return Ok(datas);
        }

        
        public IActionResult GetProductsTop()
        {
            //從訂單資料表找到銷售量前十二名的商品
            var query = (from od in _db.OrderDetails
                         join p in _db.Products on od.ProductId equals p.Id
                         join s in _db.Sellers on p.SellerId equals s.Id
                         where od.Order.OrderDate >= DateTime.Now.AddDays(-7)
                         group od by od.ProductId into g
                         orderby g.Sum(od => od.Qty) descending
                         select new
                         {
                             ProductId = g.FirstOrDefault().ProductId,
                             ProductName = g.FirstOrDefault().Product.ProductName,
                             Picture1 = g.FirstOrDefault().Product.Picture1,
                             StoreName = g.FirstOrDefault().Product.Seller.StoreName,
                             UnitPrice = g.FirstOrDefault().Product.UnitPrice,
                         }).Take(12).ToList();
            //為訂單排序結果加上排名
            var queryRank = query.Select((p, Index) => new { p.ProductId,p.ProductName, p.Picture1, p.StoreName, p.UnitPrice, Rank = Index + 1 }).ToList();
            return Json(queryRank);
        }
        
        public IActionResult GetSellersTop()
        {
            var query = (from o in _db.Orders
                         join s in _db.Sellers on o.SellerId equals s.Id
                         where o.OrderDate >= DateTime.Now.AddDays(-7)
                         group o by o.SellerId into g
                         orderby g.Sum(o => o.SellerId) descending
                         select new
                         {
                             SellerId = g.FirstOrDefault().SellerId,
                             StoreName = g.FirstOrDefault().Seller.StoreName,
                             SellerPicture = g.FirstOrDefault().Seller.Picture
                         }).Take(3).ToList();

            return Json(query);
        }



    }
}
