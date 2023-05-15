using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Xml.Schema;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.Shopping
{
    public class MemberController : SuperController
    {
        private readonly iSpanDessertShop2023MarchContext _dbContext;
        // inherit _member from SuperController

        public MemberController(iSpanDessertShop2023MarchContext dbContext)
        {
            // DI
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_member);
        }
    }
}
