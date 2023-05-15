using ISpan.Project_02_DessertStory.Admin.Models;
using ISpan.Project_02_DessertStory.Admin.Models.EF;
using ISpan.Project_02_DessertStory.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing.Printing;
using X.PagedList;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class UserController : SuperController
    {
        public readonly iSpanDessertShop2023MarchContext _ISpan;
        public UserController(iSpanDessertShop2023MarchContext iSpan)
        {
            _ISpan = iSpan;
        }


        [HttpGet]
        public IActionResult Sellersus(int id, bool status)
        {
            Seller seller = _ISpan.Sellers.FirstOrDefault(x => x.Id == id);
            if (seller != null)
            {
                seller.SuspensionStatus = status;
                _ISpan.SaveChanges();
            }

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Membersus(int id, bool status)
        {
            Member member = _ISpan.Members.FirstOrDefault(x => x.Id == id);
            if (member != null)
            {
                member.SuspensionStatus = status;
                _ISpan.SaveChanges();
            }

            return RedirectToAction("List");
        }       
        public IActionResult List(int? page, string? usercategory, string? Keyword)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.UserCategory = usercategory ?? "Member";
            if (string.IsNullOrEmpty(usercategory) || usercategory == "Member")
            {
                if (string.IsNullOrEmpty(Keyword))
                {
                    var data = _ISpan.Members.ToList();
                    var userList = data.Select(m => (IUser)m).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.UserCategory = usercategory;
                    ViewBag.seachstring = Keyword;
                    return View(userList);
                }
                else
                {
                    var data = _ISpan.Members.ToList();
                    var userList = data.Select(m => (IUser)m).Where(p => p.LastName.Contains(Keyword) || p.FirstName.Contains(Keyword)).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.UserCategory = usercategory;
                    ViewBag.seachstring = Keyword;
                    return View(userList);
                }
            }
            else if (usercategory == "Seller")
            {
                if (string.IsNullOrEmpty(Keyword))
                {
                    var data = _ISpan.Sellers.ToList();
                    var userList = data.Select(m => (IUser)m).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.UserCategory = usercategory;
                    ViewBag.seachstring = Keyword;
                    return View(userList);
                }
                else
                {
                    var data = _ISpan.Sellers.ToList();
                    var userList = data.Select(m => (IUser)m).Where(p => p.FirstName.Contains(Keyword) || p.LastName.Contains(Keyword)).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.UserCategory = usercategory;
                    ViewBag.seachstring = Keyword;
                    return View(userList);
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
