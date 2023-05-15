using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    public class SellerSuperController : Controller
    {
        protected Seller _seller = new Seller();
        protected Member _member = new Member();
        protected int _sellerId;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var actionname = context.ActionDescriptor.RouteValues["action"];
            var controllername = context.ActionDescriptor.RouteValues["controller"];

            if (actionname == "Login" && controllername == "SellerHome")
            {
                return;
            }
            if (actionname == "Create" && controllername == "SellerHome")
            {
                return;
            }
            if (actionname == "CheckAccount" && controllername == "SellerHome")
            {
                return;
            }
            if (actionname == "SellerRegisterCreate" && controllername == "SellerHome")
            {
                return;
            }
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_SELLER))
            {
                // todo add RouteValues
                context.Result = RedirectToAction("Login", "SellerHome");
            }
            else
            {
                var serializedSellers = HttpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
                _seller = JsonSerializer.Deserialize<Seller>(serializedSellers);
                _sellerId = _seller.Id;
            }
        }
    }
}
