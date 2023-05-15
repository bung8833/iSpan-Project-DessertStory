using ISpan.Project_02_DessertStory.Admin.Models;
using ISpan.Project_02_DessertStory.Admin.Models.EF;
using ISpan.Project_02_DessertStory.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using X.PagedList;

namespace ISpan.Project_02_DessertStory.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly iSpanDessertShop2023MarchContext _ISpan;

        public HomeController(ILogger<HomeController> logger,iSpanDessertShop2023MarchContext ISpan)
        {
            _logger = logger;
            _ISpan = ISpan;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CDictionary.SK_LOGIN_USER);
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            Administrator admin = _ISpan.Administrators.FirstOrDefault(t => t.Email.Equals(vm.txtEmail));
            if (admin == null)
            {
                ViewBag.accerrorstring = "此帳號不存在";
                return View();
            }
            if(admin != null && admin.Password.Equals(vm.txtPassword))
            {
                string json = JsonSerializer.Serialize(admin);
                HttpContext.Session.SetString(CDictionary.SK_LOGIN_USER, json);
                return RedirectToAction("Index");
            }
            ViewBag.errstring = "密碼錯誤";
            return View();
        }

        public async Task<IActionResult> Index(int? page, QueryKeywordViewModel vm)
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_USER))
            {


                int pageNumber = page ?? 1;
                int pageSize = 10;
                ViewBag.search = vm.txtKeyword;
                //iSpanDessertShop2023MarchContext db = new iSpanDessertShop2023MarchContext();
                IQueryable<Post> datas = null; // 使用 IQueryable 而不是 IEnumerable
                if (string.IsNullOrEmpty(vm.txtKeyword))
                {
                    datas = from p in _ISpan.Posts
                            select p;
                }
                else
                {
                    datas = _ISpan.Posts.Where(p => p.TContent.Contains(vm.txtKeyword));
                }
                return View(await datas.ToPagedListAsync(pageNumber, pageSize)); // 使用 datas 而不是 _context.posts
            }
            return RedirectToAction("Login");
        }
            public async Task<IActionResult> Detail(int? id)
        {
            if(HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_USER))
            { 

            if (id == null)
            {
                return NotFound();
            }

            var post = await _ISpan.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            // 將留言的內容轉換成可供顯示的格式
            post.TContent = post.TContent.Replace("\n", "<br>");

            // 取得該留言的所有回覆
            var replies = await _ISpan.Replies.Where(r => r.PostId == id).ToListAsync();

            // 將回覆的內容轉換成可供顯示的格式
            foreach (var reply in replies)
            {
                reply.TContent = reply.TContent.Replace("\n", "<br>");
            }

            // 根據回覆的 CreateAt 欄位排序
            replies = replies.OrderBy(r => r.CreatedAt).ToList();

            ViewBag.Post = post;
            ViewBag.Replies = replies;
            return View();
        }
return RedirectToAction("Login");
        }
            
        public IActionResult DeletePost(int? id)
        {
           var post = _ISpan.Posts.FirstOrDefault(p => p.PostId == id);
            if (post != null)
            {
            _ISpan.Posts.Remove(post);
                _ISpan.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteReply(int? id, int? fid )
        {
            var post = _ISpan.Posts.FirstOrDefault(p => p.PostId == fid);
            var reply = _ISpan.Replies.FirstOrDefault(p => p.ReplyId == id);
            if (reply != null)
            {
                _ISpan.Replies.Remove(reply);
                _ISpan.SaveChanges();
            }
            return RedirectToAction("Detail", "Home", new {id=fid});
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