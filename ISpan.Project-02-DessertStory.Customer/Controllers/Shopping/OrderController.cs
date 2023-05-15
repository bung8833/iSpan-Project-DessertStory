using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Shopping
{
    public class OrderController : SuperController
    {
        private readonly iSpanDessertShop2023MarchContext _dbContext;
        // inherit _member from SuperController

        public OrderController(iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _dbContext = dbContext;
        }


        public IActionResult Checkout(IEnumerable<CartItem> cartItems)
        {
            // check cartItems.count() > 0
            Order order = new Order();
            // check 轉型
            order.OrderDetails = (ICollection<OrderDetail>)cartItems;

            order.MemberId = _member.Id;
            // check if only one seller
            order.SellerId = cartItems.FirstOrDefault().Product.Seller.Id;
            order.TotalPrice = order.OrderDetails.Sum(c => c.Product.UnitPrice * c.Qty);

            // Fill in form
            // change to ViewModel
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // check ModelState.IsValid

            order.OrderStatus = "未出貨";
            order.OrderDate = DateTime.Now;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            // check if also updates OrderDetails

            return RedirectToAction("OrderView", new { orderId = order.Id });
        }


        /// <summary>
        /// 檢視已成立且付款完成的訂單
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        //public IActionResult OrderView(int orderId)
        //{
        //    Order order = _dbContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();

        //    if (order == null) return NotFound();
        //    if (order.MemberId != _member.Id) return NotFound();

        //    order.OrderDetails = (ICollection<OrderDetail>)_dbContext.OrderDetails.Where(d => d.OrderId == order.Id);

        //    return View(order);
        //}

        /// <summary>
        /// 會員訂單列表
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var orders = _dbContext.Orders.Include(o => o.Seller).Where(o => o.MemberId == _member.Id);
            orders = orders.OrderByDescending(o => o.OrderDate);

            List<MemberOrderVM> vm = new List<MemberOrderVM>();

            foreach (var order in orders)
            {
                vm.Add(new MemberOrderVM()
                {
                    OrderId = order.Id,
                    StoreName = order.Seller.StoreName,
                    TotalPrice = order.TotalPrice,
                    OrderDate = order.OrderDate,
                    OrderStatus = order.OrderStatus,
                    ShippingFee = order.ShippingFee,
                    PaymentMethod = String.IsNullOrWhiteSpace(order.PaymentMethod) 
                        ? null : order.PaymentMethod,
                });
            }

            return View(vm);
        }


        public IActionResult Details(int orderId)
        {
            // todo check if order belongs to this member

            // check if order exits
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                ViewBag.NullOrderError = true;
                return View();
            }

            // check if order details exits
            var orderDetails = _dbContext.OrderDetails.Include(d => d.Product).Where(d => d.OrderId == orderId);
            if (orderDetails == null || orderDetails.Count() == 0)
            {
                ViewBag.EmptyDetailsError = true;
                return View();
            }

            List<MemberOrderDetailVM> vm = new List<MemberOrderDetailVM>();

            foreach (var orderDetail in orderDetails)
            {
                vm.Add(new MemberOrderDetailVM()
                {
                    ProductName = orderDetail.Product.ProductName,
                    Qty = orderDetail.Qty,
                    Subtotal = orderDetail.Subtotal,
                    Size = String.IsNullOrWhiteSpace(orderDetail.Product.ProductSize) 
                        ? "單一尺寸" : orderDetail.Product.ProductSize,
                });
            }

            return View(vm);
        }
    }
}
