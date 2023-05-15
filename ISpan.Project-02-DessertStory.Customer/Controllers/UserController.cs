using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly iSpanDessertShop2023MarchContext _dbContext;

        private readonly HttpContext _httpContext;

        public UserController
            (IHttpContextAccessor httpContextAccessor, iSpanDessertShop2023MarchContext context)
        {
            // DI
            _httpContextAccessor = httpContextAccessor;
            _dbContext = context;

            _httpContext = _httpContextAccessor.HttpContext;
        }

        //public IActionResult MemberLogin(string? redirAction, string? redirController)
        //{
        //    // record the action/controller who called this method
        //    redirAction ??= "Index";
        //    redirController ??= "Order";

        //    // check if already logined
        //    if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_MEMBER))
        //    {
        //        return RedirectToAction(redirAction, redirController);
        //    }

        //    ViewBag.RedirAction = redirAction;
        //    ViewBag.RedirController = redirController;

        //    return View(new MemberLoginVM());
        //}

        public IActionResult MemberLogin(bool? justRegistered)
        {
            // check if already logined
            if (_httpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_MEMBER))
            {
                return RedirectToAction("Index", "Home");
            }

            // show Register Success message
            if (justRegistered == true)
            {
                ViewBag.JustRegistered = true;
            }

            return View(new MemberLoginVM());
        }

        [HttpPost]
        public IActionResult MemberLogin(MemberLoginVM vm)
        {
            string account = vm.txtAccount ?? string.Empty;
            string password = vm.txtPassword ?? string.Empty;

            // access db to check if valid member account & password
            List<Member> members = _dbContext.Members.Where(m => m.Account.Equals(account)).ToList();

            if (members != null && members.Count() == 1)
            {
                Member member = members.FirstOrDefault();

                if (member != null && member.Password == password)
                {
                    // is valid login, add this logined user to Session
                    string json = JsonSerializer.Serialize(member);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_MEMBER, json);

                    // then, redirect to the action/controller who called this method
                    return RedirectToAction("Index", "Home");
                }
            }

            // invalid login, redirect back to Login Page
            return RedirectToAction("MemberLogin", "User");
        }


        public IActionResult MemberLogout()
        {
            _httpContext.Session.Remove(CDictionary.SK_LOGINED_MEMBER);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(MemberRegisterVM vm)
        {
            bool valid = true;

            // check if account/email is already used by other members
            var registeredMembers = _dbContext.Members.ToList();
            
            if (registeredMembers.Any(r => r.Account == vm.account))
            {
                valid = false;
                ModelState.AddModelError(nameof(MemberRegisterVM.account), "這個帳號已經有人用了");
            }
            if (registeredMembers.Any(r => r.Email == vm.email))
            {
                valid = false;
                ModelState.AddModelError(nameof(MemberRegisterVM.email), "這個email已經有人用了");
            }
            // check if birthdate is valid, i.e. not after today
            if (vm.birthdate > DateTime.Today)
            {
                valid = false;
                ModelState.AddModelError(nameof(MemberRegisterVM.birthdate), "生日必須在今天以前！");
            } 

            // return to Register Page and show Errors
            if (!valid) return View(vm);
            

            Member member = new Member()
            {
                Account = vm.account,
                Password = vm.password,
                FirstName = vm.firstname,
                LastName = vm.lastname,
                BirthDate = vm.birthdate,
                Gender = vm.gender,
                Email = vm.email,

                IdentityNumber = "N/A",
                SuspensionStatus = false,
                Mobile = "N/A",
            };

            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();

            return RedirectToAction("MemberLogin", new { justRegistered = true });
        }
    }
}
