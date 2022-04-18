using Core.Helper;
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


        public IActionResult Index(int? recordSize = 6, int? pageNo = 1)
        {
            HomeVM vm = new()
            {
                Organic = _organicManager.GetById(10),
                Photos = _photoManager.GetAll(),
                News = _newManager.GetAll(pageNo, recordSize.Value),
            };
            vm.Pager = new Pager(_newManager.GetAllCount(), pageNo, 2, 3);
            return View(vm);
        }
    }
}
