using api.Services;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant { Id = 1, Name = "The Restaurant" };
            //var model = _restaurantData.GetAll();
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            //return new ObjectResult(model);
            return View(model);

            //return Content("Hello, from the HomeController");
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if(model == null)
            {
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
