using api.Entities;
using api.Services;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            //Log.Information("Home!");

            //var model = new Restaurant { Id = 1, Name = "The Restaurant" };
            //var model = _restaurantData.GetAll();
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            HttpContext.Response.Cookies.Append("CustomCookie", "It's worth a lot!");

            //return new ObjectResult(model);
            return View(model);

            //return Content("Hello, from the HomeController");
        }

        public IActionResult Details(int id)
        {
            //Log.Information("Details!");

            var model = _restaurantData.Get(id);

            if(model == null)
            {
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Log.Information("Create Get!");

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            //Log.Information("Create Post!");

            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Cuisine = model.Cuisine,
                    Name = model.Name
                };

                newRestaurant = _restaurantData.Add(newRestaurant);

                //return View("Details", newRestaurant); // use POST - redirect - GET Pattern instead
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }

            return View();
        }
    }
}
