using ISpan.Project_02_DessertStory.Customer.Models;
using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Main
{
    public class HomeController : Controller
    {
        private readonly iSpanDessertShop2023MarchContext _dbContext;

        public HomeController(iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var data = _dbContext.Advertises.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}