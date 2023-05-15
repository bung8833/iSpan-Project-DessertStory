using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class ErrorPagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
