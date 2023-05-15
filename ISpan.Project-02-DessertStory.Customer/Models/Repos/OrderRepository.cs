using ISpan.Project_02_DessertStory.Customer.Models.EF;

namespace ISpan.Project_02_DessertStory.Customer.Models.Repos
{
    public class OrderRepository
    {
        private readonly iSpanDessertShop2023MarchContext _dbContext;

        public OrderRepository(iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _dbContext = dbContext;
        }

        //public IEnumerable<Product> QueryProductByOrderId(int orderId)
        //{
        //    Order order = _dbContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
        //    if (order == null) return null;

        //    IEnumerable<Product> products = _dbContext.OrderDetails.Where(d => d.OrderId == orderId).

            
        //}
    }
}
