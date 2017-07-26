using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant { Id = 1, Name = "The Restaurant" };
            var model = _restaurantData.GetAll();
            //return new ObjectResult(model);
            return View(model);

            //return Content("Hello, from the HomeController");
        }
    }
}
