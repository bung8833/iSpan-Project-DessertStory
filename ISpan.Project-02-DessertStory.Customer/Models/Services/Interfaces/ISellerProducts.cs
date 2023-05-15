using ISpan.Project_02_DessertStory.Customer.Models.Services.Dtos;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces
{
    public interface ISellerProducts
    {
        public SellerProductsDto QueryByProductId(int? id);
        public List<SellerProductsDto> QueryBySellerId(int? Id);
    }
}
