using Entities;
using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class ArticleController : Controller
    {
        private readonly INewManager _newManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly ICommentManager _commentManager;

        public ArticleController(INewManager newManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, ICommentManager commentManager)
        {
            _newManager = newManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _commentManager = commentManager;
        }


        public IActionResult Index(int? id)
        {
            var news = _newManager.GetNewById(id);
            var comments = _commentManager.GetNewComment(news.Id);
            ViewBag.Comments = comments.Count;

            ArticleVM vm = new()
            {
                NewSingle = news,
                User = _userManager.FindByIdAsync(news.UserId).Result,
                Comments = comments,
                News = _newManager.GetAll()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddNewComment(Comment comment, int newId)
        {
            comment.NewId = newId;
            _commentManager.AddComment(comment);
            return RedirectToAction("Index", "New", new { id = newId });
        }
    }
}
