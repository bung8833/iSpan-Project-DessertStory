using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    public class SellerOrderController : SellerSuperController
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly iSpanDessertShop2023MarchContext _db;

        //private readonly HttpContext _httpContext;
        //private readonly Seller? _seller;
        //private readonly int _sellerId;
        

        public SellerOrderController
            (IHttpContextAccessor httpContextAccessor, iSpanDessertShop2023MarchContext db)
        {
            // DI
            //_httpContextAccessor = httpContextAccessor;
            _db = db;
            //_sellerId = _seller.Id;

            //_httpContext = _httpContextAccessor.HttpContext;
            
            //if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_SELLER))
            //    {
            //        string json = _httpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
            //        _seller = JsonSerializer.Deserialize<Seller>(json);
            //        _sellerId = _seller.Id;
            //    ViewBag.SellerId = _seller.Id;
            //    ViewBag.SellerAccount = _seller.Account;
            //    ViewBag.SellerPicture = _seller.Picture;
            //    ViewBag.SellerName = _seller.LastName + _seller.FirstName;
            //}
        }
       
        public IActionResult List(SellerOrderViewModel vm)
        {
            int Id = _sellerId;
            //找出所有狀態
            List<string> orderStatus = _db.Orders.Select(s => s.OrderStatus).Distinct().ToList();
            List<SelectListItem> orderStatusList = orderStatus.Select(s => new SelectListItem
            {
                Value = s,
                Text = s
            }).ToList();
            ViewBag.OrderStatus = orderStatusList;

            //找出所有付款方式
            List<string> paymentMethod = _db.Orders.Select(s => s.PaymentMethod).Distinct().ToList();
            List<SelectListItem> paymentMethodList = paymentMethod.Select(s => new SelectListItem
            {
                Value = s,
                Text = s
            }).ToList();
            ViewBag.PaymentMethod = paymentMethodList;

            //找出所有出貨方式
            List<string> shipVia = _db.Orders.Select(s => s.ShipVia).Distinct().ToList();
            List<SelectListItem> shipViaList = shipVia.Select(s => new SelectListItem
            {
                Value = s,
                Text = s
            }).ToList();
            ViewBag.ShipVia = shipViaList;

            //查詢
            var q = from Order in _db.Orders
                    join Member in _db.Members on Order.MemberId equals Member.Id
                    join Seller in _db.Sellers on Order.SellerId equals Seller.Id
                    where Seller.Id == Id
          && (string.IsNullOrEmpty(vm.SelectedOrderStatus) || Order.OrderStatus == vm.SelectedOrderStatus)
          && (string.IsNullOrEmpty(vm.SelectedPaymentMethod) || Order.PaymentMethod == vm.SelectedPaymentMethod)
          && (string.IsNullOrEmpty(vm.SelectedShipVia) || Order.ShipVia == vm.SelectedShipVia)
          && (string.IsNullOrEmpty(vm.DateStart) || Order.OrderDate >= DateTime.Parse(vm.DateStart))
          && (string.IsNullOrEmpty(vm.DateEnd) || Order.OrderDate < DateTime.Parse(vm.DateEnd).AddDays(1))
                    select new SellerOrderViewModel
                    {
                        OrderId = Order.Id,
                        SellerId = Seller.Id,
                        MemberId = Member.Id,
                        MemberFirstName = Member.FirstName,
                        MemberLastName = Member.LastName,
                        TotalPrice = Order.TotalPrice,
                        ContectNumber = Order.ContactNumber,
                        Address = Order.ShipAddress,
                        OrderDate = Order.OrderDate,
                        OrderStatus = Order.OrderStatus,
                        PaymentMethod = Order.PaymentMethod,
                        ShipVia = Order.ShipVia,
                    };
            ViewBag.DateStart = vm.DateStart;
            ViewBag.DateEnd = vm.DateEnd;

            return View(q);
        }

        public IActionResult OrderDetailList(int Id)
        {
            var q = from OrderDetail in _db.OrderDetails
                    join Order in _db.Orders on OrderDetail.OrderId equals Order.Id
                    join Product in _db.Products on OrderDetail.ProductId equals Product.Id
                    where OrderDetail.OrderId == Id
                    select new SellerOrderDetailViewModel
                    {
                        OrderId = OrderDetail.OrderId,
                        OrderDetailId = OrderDetail.Id,
                        ProductId = OrderDetail.ProductId,
                        ProductName = Product.ProductName,
                        UnitPrice = OrderDetail.UnitPrice,
                        Quantity = OrderDetail.Qty,
                        SubTotal = OrderDetail.Subtotal,
                    };
            return View(q);
        }
    }
}
