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
        private readonly IOrganicManager _organicManager;
        private readonly IFreeManager _freeManager;
        private readonly IDealManager _dealManager;
        private readonly IOwnerManager _ownerManager;

        public HomeController(ILogger<HomeController> logger, INewManager newManager, IOrganicManager organicManager, IFreeManager freeManager, IDealManager dealManager, IOwnerManager ownerManager)
        {
            _logger = logger;
            _newManager = newManager;
            _organicManager = organicManager;
            _freeManager = freeManager;
            _dealManager = dealManager;
            _ownerManager = ownerManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newManager.GetAll(),
                Organies = _organicManager.GetAll(),
                Frees = _freeManager.GetAll(),
                Deals = _dealManager.GetAll(),
                Owners = _ownerManager.GetAll()

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