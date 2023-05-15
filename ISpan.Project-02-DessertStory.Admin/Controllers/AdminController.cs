using ISpan.Project_02_DessertStory.Admin.Models;
using ISpan.Project_02_DessertStory.Admin.Models.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class AdminController : Controller
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;

        public AdminController(iSpanDessertShop2023MarchContext ISpan)
        {
            _ISpan = ISpan;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Administrator admin)
        {
            if (admin != null)
            {
                //var passwordhash = _passwordHasher.Hash(admin.Password);
                //admin.Password = passwordhash;
                _ISpan.Administrators.Add(admin);
                _ISpan.SaveChanges();
            }
            return RedirectToAction("Login", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
