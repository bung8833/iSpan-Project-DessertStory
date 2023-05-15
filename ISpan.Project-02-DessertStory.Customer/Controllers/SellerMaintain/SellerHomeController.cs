using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text.Json;

namespace ISpan.Project_02_DessertStory.Customer.Controllers.SellerMaintain
{
    public class SellerHomeController : SellerSuperController
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly iSpanDessertShop2023MarchContext _db;
        IWebHostEnvironment _enviro;
        private readonly IEmailService _emailService;
        //private Seller _seller;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISellerService _sellerService;
        //private readonly HttpContext _httpContext;


        public SellerHomeController(IPasswordHasher passwordHasher, iSpanDessertShop2023MarchContext db, IWebHostEnvironment p, IEmailService emailService, IHttpContextAccessor httpContextAccessor, ISellerService sellerService)
        {
            _passwordHasher = passwordHasher;
            _db = db;
            _enviro = p;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_SELLER);
            var seller = JsonSerializer.Deserialize<Seller>(json);

            ViewBag.SellerId = seller.Id;
            ViewBag.SellerAccount = seller.Account;
            ViewBag.SellerPicture = seller.Picture;
            ViewBag.SellerName = seller.LastName + seller.FirstName;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 把賣家註冊的資料存到資料庫
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SellerRegisterCreate(SellerRegisterViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    // 驗證失敗，返回表單並顯示錯誤訊息
            //    return View(vm);
            //}
            var passwordHash = _passwordHasher.Hash(vm.Password);
            if (vm != null)
            {
                if (vm.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    string path = _enviro.WebRootPath + "/images/" + photoName;
                    vm.photo.CopyTo(new FileStream(path, FileMode.Create));
                    vm.Picture = photoName;
                }
                var seller = new Seller
                {
                    Account = vm.Account,
                    Password = vm.Password,
                    PasswordSalt = passwordHash,
                    IdentityNumber = vm.IdentityNumber,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email,
                    ContactNumber = vm.ContactNumber,
                    Address = vm.Address,
                    BirthDate = vm.BirthDate,
                    StoreName = vm.StoreName,
                    Description = vm.Description,
                    Picture = vm.Picture,
                    EmailToken = Guid.NewGuid().ToString(),
                };
                _db.Sellers.Add(seller);
                _db.SaveChanges();


                //寄送E-mail
                string recipientEmail = seller.Email; // Set recipient email address

                string url = Url.Action("authenticate", "authenticate", new { uid = seller.EmailToken }, HttpContext.Request.Scheme);



                //string authenticationUrl = $"https://localhost:7008/authenticate?uid={seller.EmailToken}"; // Set authentication URL


                _emailService.SendAuthenticationEmailAsync(recipientEmail, url, seller.FirstName);
                return View("SellerRegisterSuccess");
            }
            return RedirectToAction("Login");

        }

        /// <summary>
        /// 顯示登入畫面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// [暫時，未顯示提示訊息]驗證是否登入成功，登入成功會進入歡迎頁面，失敗會停留在登入畫面(20230422)
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(SellerLoginViewModel vm)
        {
            if (vm != null) {
                Seller q = _db.Sellers.FirstOrDefault(s => s.Account == vm.txtAccount);
                if (q != null)
                {

                    //var passwordHash = _passwordHasher.Hash(q.Password);
                    //q.PasswordSalt = passwordHash;
                    //_db.SaveChanges();
                    var result = _passwordHasher.Verify(q.PasswordSalt, vm.txtPassword);
                    if (!result)
                    {
                        return View();
                        //throw new Exception("帳號或密碼錯誤");
                    }
                    else if (q.EmailStatus == false)
                    {

                        //暫時，為了知道要寄給誰
                        string json = JsonSerializer.Serialize(q);
                        HttpContext.Session.SetString(CDictionary.SK_LOGINED_SELLER, json);
                        _seller = JsonSerializer.Deserialize<Seller>(json);

                        ViewBag.SellerAccount = _seller.Account;
                        ViewBag.SellerId = _seller.Id.ToString();


                        //寄送E-mail


                        //string recipientEmail = "tinatsao.work@gmail.com"; // Set recipient email address
                        //string url = Url.Action("authenticate", "authenticate", new { uid = q.EmailToken }, HttpContext.Request.Scheme);
                        //string authenticationUrl = $"https://localhost:7008/authenticate?uid={q.EmailToken}"; // Set authentication URL

                        //_emailService.SendAuthenticationEmailAsync(recipientEmail, url, _seller.FirstName);
                        return View("EmailStatusFalse");
                    }
                    else
                    {
                        string json = JsonSerializer.Serialize(q);
                        HttpContext.Session.SetString(CDictionary.SK_LOGINED_SELLER, json);
                        _seller = JsonSerializer.Deserialize<Seller>(json);

                        ViewBag.SellerAccount = _seller.Account;
                        ViewBag.SellerId = _seller.Id.ToString();

                        return RedirectToAction("Index", "SellerHome");
                    }
                }
            }
            return View();
        }

        //登出
        public IActionResult SellersLogout()
        {
            HttpContext.Session.Remove(CDictionary.SK_LOGINED_SELLER);

            return RedirectToAction("Login", "SellerHome");
        }

        /// <summary>
        /// 寄送E-mail驗證信
        /// </summary>
        /// <param name="recipientEmail"></param>
        /// <param name="authenticationUrl"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IActionResult> SendAuthenticationEmail(string recipientEmail, string authenticationUrl,string username)
        {
            await _emailService.SendAuthenticationEmailAsync(recipientEmail, authenticationUrl, username);

            // Additional logic

            return Ok();
        }
        [HttpPost]
        public IActionResult CheckAccount(string account)
        {
            var isDuplicate = _sellerService.IsAccountExist(account);
            return Ok(isDuplicate);
        }
    }
}
