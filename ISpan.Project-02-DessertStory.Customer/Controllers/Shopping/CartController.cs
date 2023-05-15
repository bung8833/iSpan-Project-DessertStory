using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Shopping
{
    public class CartController : SuperController
    {
        private readonly iSpanDessertShop2023MarchContext _dbContext;
        // inherit _member from SuperController

        public CartController(iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _dbContext = dbContext;
        }


        public IActionResult Order(OrderVM vm)
        {
            decimal totalpricr = 0;
            foreach(var item in vm.OrderDetail)
            {
                totalpricr += item.UnitPrice * item.Qty;
            }
            ViewBag.ODvm = vm.OrderDetail;
            ViewBag.sellerid = vm.SellerId;
            ViewBag.memberid = _member.Id;
            ViewBag.totalprice = totalpricr;
            return View();
        }


        [HttpPost]
        public IActionResult CreatOrder(CreateOrderViewModel order)
        {
            var Order = new Order
            {
                MemberId = order.MemberId,
                SellerId = order.SellerId,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                FirstName = order.FirstName,
                LastName = order.LastName,
                ContactNumber = order.ContactNumber,
                ShipZip = order.ShipZip,
                ShipAddress = order.ShipAddress,
                OrderDate = order.OrderDate,
                ShippingFee = order.ShippingFee,
                ShipVia = order.ShipVia,
                PaymentMethod = order.PaymentMethod,
                Notes = order.Notes,
            };
            _dbContext.Orders.Add(Order);
            _dbContext.SaveChanges();

            foreach (var detail in order.OrderDetail)
            {
                var ODdetail = new OrderDetail
                {
                    OrderId= Order.Id,
                    ProductId = detail.ProductId,
                    Qty = detail.Qty,
                    UnitPrice = detail.UnitPrice,
                    Subtotal = detail.Subtotal,
                    Discount = detail.Discount,
                };
                _dbContext.OrderDetails.Add(ODdetail);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// CartView
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // CartItems in this member's cart
            List<CartItem> cartItems = _dbContext.CartItems.Include(c => c.Product).ThenInclude(p => p.Seller)
                .Where(c => c.MemberId == _member.Id).ToList();

            cartItems = cartItems.OrderBy(c => c.ProductId).ToList();

            // Sellers whom CartItems belong to
            List<Seller> sellers = cartItems.Select(c => c.Product.Seller).Distinct().ToList();

            List<CartVM> cartVMs = new List<CartVM>();

            // 每個 Seller 各自有一個 CartVM
            foreach (var seller in sellers)
            {
                CartVM cartVM = new CartVM();
                cartVM.member = _member;
                cartVM.seller = seller;

                // 處理 CartVM 中的 List<CartItemVM>
                foreach (var cartItem in cartItems)
                {
                    if (cartItem.Product.SellerId == seller.Id)
                    {
                        CartItemVM cartItemVM = new CartItemVM();
                        cartItemVM.product = cartItem.Product;
                        cartItemVM.UnitPrice = cartItem.Product.UnitPrice;
                        cartItemVM.Qty = cartItem.Qty;

                        cartVM.CartItemVMs.Add(cartItemVM);
                    }
                }

                cartVMs.Add(cartVM);
            }

            return View(cartVMs);
        }


        [HttpPost]
        public IActionResult AddToCart(int? Id, int? Qty)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                ViewBag.Error = true;
                return View();
            }

            Qty ??= 1;

            // check if same product already in cart
            CartItem itemInCart = _dbContext.CartItems.FirstOrDefault(c => c.ProductId == Id && c.MemberId == _member.Id);
            if (itemInCart != null)
            {
                itemInCart.Qty += (int)Qty;
                _dbContext.SaveChanges();
                return RedirectToAction("List", "ProductDetail", new { id = Id });
            }

            // turn Product into CartItem
            CartItem item = new CartItem();

            item.ProductId = product.Id;
            item.MemberId = _member.Id;
            item.Qty = (int)Qty;
            item.AddTime = DateTime.Now;

            _dbContext.CartItems.Add(item);
            _dbContext.SaveChanges();

            return RedirectToAction("List", "ProductDetail", new { id = Id });
        }


        public IActionResult Delete(int productId)
        {
            CartItem item = _dbContext.CartItems.FirstOrDefault(c => c.MemberId == _member.Id && c.ProductId == productId);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _dbContext.CartItems.Remove(item);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
