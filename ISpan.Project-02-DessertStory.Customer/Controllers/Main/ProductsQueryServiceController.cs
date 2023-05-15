using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Repos;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsQueryServiceController : ControllerBase
    {
        private readonly iSpanDessertShop2023MarchContext _db;
        public ProductsQueryServiceController(iSpanDessertShop2023MarchContext db)
        {
            _db = db; // 注入
        }

        /// <summary>
        /// 所有上架中的產品
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductsQueryServiceController>
        [HttpGet]
        public IEnumerable<ProductsQuertServiceViewModel> Get()
        {

            var datas = from p in _db.Products
                        join s in _db.Sellers on p.SellerId equals s.Id
                        join c in _db.Categories on p.CategoryId equals c.Id
                        where p.ProductStatus == true
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
            return datas;



            //return new string[] { "value1", "value2" };
            //var datas = from p in _db.Products
            //            join s in _db.Sellers on p.SellerId equals s.Id
            //            join c in _db.Categories on p.CategoryId equals c.Id
            //            select new
            //            {
            //                p.Id,
            //                p.CategoryId,
            //                c.Name,
            //                p.SellerId,
            //                s.StoreName,
            //                s.Description,
            //                p.ProductName,
            //                p.UnitPrice,
            //                productDescription = p.Description,
            //                p.Picture1,
            //                p.Picture2,
            //                p.Picture3,
            //            };

            //var result = datas.Select(d => $"{d.Id},{d.CategoryId},{d.Name},{d.SellerId},{d.StoreName},{d.Description},{d.ProductName},{d.UnitPrice},{d.productDescription},{d.Picture1},{d.Picture2},{d.Picture3}");
            //return result;
        }

        // GET api/<ProductsQueryServiceController>/5
        [HttpGet("{id}")]
        public IEnumerable<ProductsQuertServiceViewModel> Get(int id)
        {

            var datas = from p in _db.Products
                        join s in _db.Sellers on p.SellerId equals s.Id
                        join c in _db.Categories on p.CategoryId equals c.Id
                        where p.ProductStatus == true && id == c.Id
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
            return datas;
        }

        // POST api/<ProductsQueryServiceController>
        [HttpPost]
        public IEnumerable<ProductsQuertServiceViewModel> Post(int sellerid)
        {
            var datas = from p in _db.Products
                        join s in _db.Sellers on p.SellerId equals s.Id
                        join c in _db.Categories on p.CategoryId equals c.Id
                        where p.ProductStatus == true && sellerid == s.Id
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
            var a = datas;
            return datas;
        }

        // PUT api/<ProductsQueryServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsQueryServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
