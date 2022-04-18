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
        private readonly ISaleManager _saleManager;
        private readonly ISinceManager _sinceManager;
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IPhotoManager _photoManager;

        public HomeController(ILogger<HomeController> logger, INewManager newManager, IOrganicManager organicManager, IFreeManager freeManager, IDealManager dealManager, IOwnerManager ownerManager, ISaleManager saleManager, ISinceManager sinceManager, IProductManager productManager, ICategoryManager categoryManager, IPhotoManager photoManager)
        {
            _logger = logger;
            _newManager = newManager;
            _organicManager = organicManager;
            _freeManager = freeManager;
            _dealManager = dealManager;
            _ownerManager = ownerManager;
            _saleManager = saleManager;
            _sinceManager = sinceManager;
            _productManager = productManager;
            _categoryManager = categoryManager;
            _photoManager = photoManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newManager.GetNewAll(),
                Organies = _organicManager.GetAll(),
                Frees = _freeManager.GetAll(),
                Deals = _dealManager.GetAll(),
                Owners = _ownerManager.GetAll(),
                Sales = _saleManager.GetAll(),
                Sinces = _sinceManager.GetAll(),
                Products = _productManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                Photos = _photoManager.GetAll()
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