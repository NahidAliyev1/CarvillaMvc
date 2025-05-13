using CarvillaMVC.MVC.Models;
using CarvillaMVC.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarvillaMVC.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedCarsController : Controller
    {
        private readonly FeaturedCarsService _featuredCarsService;
        public FeaturedCarsController()
        {
            _featuredCarsService = new FeaturedCarsService();
        }
        public IActionResult Index()
        {
            List<FeaturedCars> featuredCars = _featuredCarsService.GetAllFeaturedCars();
            return View(featuredCars);
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            FeaturedCars featuredCars = _featuredCarsService.GetFeaturedCarsById(id);
            return View(featuredCars);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FeaturedCars featuredCars) 
        {
            _featuredCarsService.CreateFeaturedCars(featuredCars);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
           FeaturedCars featuredCars= _featuredCarsService.GetFeaturedCarsById(id);
            return View(featuredCars);
        }
        [HttpPost]
        public IActionResult Update(int id, FeaturedCars car) 
        {
            _featuredCarsService.UpdateFeaturedCars(id, car);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _featuredCarsService.DeleteFeaturedCars(id);
            return RedirectToAction(nameof(Index));
    }


    }
}
