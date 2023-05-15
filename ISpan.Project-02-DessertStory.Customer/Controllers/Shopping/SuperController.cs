using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Shopping
{
    public class SuperController : Controller
    {
        protected Member _member = new Member();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_MEMBER))
            {
                // fetch Session and store member information
                string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_MEMBER);
                _member = JsonSerializer.Deserialize<Member>(json);
            }
            else
            {
                // not logined, redirect to Login Page
                context.Result = RedirectToAction("MemberLogin", "User");
            }
        }
    }
}
