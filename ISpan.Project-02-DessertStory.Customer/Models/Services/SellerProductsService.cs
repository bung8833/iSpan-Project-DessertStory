using ISpan.Project_02_DessertStory.Customer.Models.Repos;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Dtos;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services
{
    public class SellerProductsService
    {
        // private readonly iSpanDessertShop2023MarchContext _db;
        private readonly ISellerProducts _repo;
        public SellerProductsService(ISellerProducts repo)
        {
            _repo = repo;
        }
        public List<SellerProductsDto> QueryBySellerId(int? Id)
        {
            return (_repo.QueryBySellerId(Id));
        }
        public SellerProductsDto QueryByProductId(int? Id)
        {
            return (_repo.QueryByProductId(Id));
        }
    }



}
