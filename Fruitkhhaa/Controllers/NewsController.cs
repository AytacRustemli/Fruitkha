using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewManager _newManager;
        private readonly IOrganicManager _organicManager;
        private readonly IPhotoManager _photoManager;
        public NewsController(INewManager newManager, IOrganicManager organicManager, IPhotoManager photoManager)
        {
            _newManager = newManager;
            _organicManager = organicManager;
            _photoManager = photoManager;
        }


        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newManager.GetAll(),
                Organic = _organicManager.GetById(10),
                Photos = _photoManager.GetAll()
            };
            return View(vm);
        }
    }
}
