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
        
        private readonly UserManager<User> _userManager;
        public ArticleController(INewManager newManager,  UserManager<User> userManager)
        {
            _newManager = newManager;
            
            _userManager = userManager;
        }


        public IActionResult Index(int? id)
        {
            var news = _newManager.GetNewById(id);

            ArticleVM vm = new()
            {

                NewSingle = news,
                User = _userManager.FindByIdAsync(news.UserId).Result,
                
            };
            return View(vm);
        }
    }
}
