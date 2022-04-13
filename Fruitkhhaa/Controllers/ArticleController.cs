using Microsoft.AspNetCore.Mvc;

namespace Fruitkhhaa.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
