using System.Diagnostics;
using Fruitkhhaa.Models;
using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewManager _newManager;

        public HomeController(ILogger<HomeController> logger, INewManager newManager)
        {
            _logger = logger;
            _newManager = newManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newManager.GetAll(),

            };
            return View(vm);
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