using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCoreDemo.ViewModel;
using System.Text.Json;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace ISpan.Project_02_DessertStory.Customer.Controllers
{
    public class PostController : Controller
    {
        private readonly iSpanDessertShop2023MarchContext _context;

        public PostController(iSpanDessertShop2023MarchContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List(int? page, CQueryKeywordViewModel vm)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            ViewBag.search=vm.txtKeyword;
            //iSpanDessertShop2023MarchContext db = new iSpanDessertShop2023MarchContext();
            IQueryable<Post> datas = null; // 使用 IQueryable 而不是 IEnumerable
            if (string.IsNullOrEmpty(vm.txtKeyword))
            {
                datas = from p in _context.Posts
                        select p;
            }
            else
            {
                datas = _context.Posts.Where(p => p.TContent.Contains(vm.txtKeyword));
            }
            return View(await datas.ToPagedListAsync(pageNumber, pageSize)); // 使用 datas 而不是 _context.posts
        }
        private bool IsUserLoggedIn()
        {
            var member = HttpContext.Session.GetString(CDictionary.SK_LOGINED_MEMBER);
            return member != null;
        }
        public IActionResult Create()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("MemberLogin", "User");
            }
            var member = HttpContext.Session.GetString(CDictionary.SK_LOGINED_MEMBER);
            var memberid = JsonSerializer.Deserialize<Member>(member);
            ViewBag.ID = memberid.Account;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PostID,UserID,Title,TContent,CreatedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                post.UpdateAt=DateTime.Now;
                var member = HttpContext.Session.GetString(CDictionary.SK_LOGINED_MEMBER);
                var memberid=JsonSerializer.Deserialize<Member>(member);

                post.UserId = memberid.Account;

                if (post.TContent != null)
                {
                    post.TContent = post.TContent.Replace("\n", "<br>");
                }
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(post);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            // 將留言的內容轉換成可供顯示的格式
            post.TContent = post.TContent.Replace("\n", "<br>");

            // 取得該留言的所有回覆
            var replies = await _context.Replies.Where(r => r.PostId == id).ToListAsync();

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

        [HttpPost]
        public async Task<IActionResult> CreateReply(Reply reply)
        {
            if (ModelState.IsValid)
            {

                var member = HttpContext.Session.GetString(CDictionary.SK_LOGINED_MEMBER);
                var memberid = JsonSerializer.Deserialize<Member>(member);
                reply.UserId = memberid.Account;
                reply.CreatedAt = DateTime.Now;
                if (reply.TContent != null)
                {
                    reply.TContent = reply.TContent.Replace("\n", "<br>");
                }
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Detail), new { id = reply.PostId });
            }
            return RedirectToAction(nameof(Detail), new { id = reply.PostId });
        }
        public async Task<IActionResult>Chat()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("MemberLogin", "User");
            }
            return View();
        }

    }
}
