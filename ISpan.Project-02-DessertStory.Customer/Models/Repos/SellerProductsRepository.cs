using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Dtos;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;
using System;

namespace ISpan.Project_02_DessertStory.Customer.Models.Repos
{
    public class SellerProductsRepository : ISellerProducts
    {
        private readonly iSpanDessertShop2023MarchContext _db;

        public SellerProductsRepository(iSpanDessertShop2023MarchContext db)
        {
            _db = db; // 注入
        }

        public List<SellerProductsDto> QueryBySellerId(int? Id)
        {
            List<SellerProductsDto> list = new List<SellerProductsDto>();
            if (Id == null)
            {
                return null;
            }
            if (Id != null)
            {
                var q = _db.Products.Where(s => s.SellerId == Id);
                if (q != null)
                {
                    foreach (var item in q)
                    {
                        list.Add(new SellerProductsDto
                        {
                            Id = item.Id,
                            ProductName = item.ProductName,
                            CategoryId = item.CategoryId,
                            ProductSize = item.ProductSize,
                            Picture1 = item.Picture1,
                            Picture2 = item.Picture2,
                            Picture3 = item.Picture3,
                            ProductStatus = item.ProductStatus,
                            UnitPrice = item.UnitPrice,
                            UnitsInStock = item.UnitsInStock,
                            SellerId = item.SellerId
                        });
                    }

                }
            }

            return list.ToList();
        }


        /// <summary>
        /// 依據商品編號查詢商品資料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SellerProductsDto QueryByProductId(int? Id)
        {

            if (Id == null)
            {
                new SellerProductsDto();
            }
            if (Id != null)
            {
                List<Category> list = new List<Category>();
                foreach (var item in _db.Categories)
                {
                    list.Add(new Category
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DisplayOrder = item.DisplayOrder
                    });
                }
                var q = _db.Products.Join(
                    _db.Categories,
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new { p, c })
                    .Where(s => s.p.Id == Id)
                    .Select(s => new SellerProductsDto
                    {
                        Id = s.p.Id,
                        SellerId = s.p.SellerId,
                        ProductName = s.p.ProductName,
                        ProductSize = s.p.ProductSize,
                        CategoryId = s.p.CategoryId,
                        CategoryName = s.c.Name,
                        Picture1 = s.p.Picture1,
                        Picture2 = s.p.Picture2,
                        Picture3 = s.p.Picture3,
                        Description = s.p.Description,
                        UnitPrice = s.p.UnitPrice,
                        UnitsInStock = s.p.UnitsInStock,
                        ProductStatus = s.p.ProductStatus,
                        Category = list
                    }).FirstOrDefault();

                return q;
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
            return new SellerProductsDto();
    }

}
}

