using CarvillaMVC.MVC.Models;
using CarvillaMVC.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarvillaMVC.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly FeaturedCarsService _featuredCarsService;
        public HomeController()
        {
            _featuredCarsService = new FeaturedCarsService();
        }
        public IActionResult Index()
        {
            List<FeaturedCars> featuredCars = _featuredCarsService.GetAllFeaturedCars();
            return View(featuredCars);
        }
    }
}
