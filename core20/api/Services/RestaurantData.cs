using api.Models;
using System.Collections.Generic;

namespace api.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "The Restaurant"},
                new Restaurant { Id = 2, Name = "Restaurant1"},
                new Restaurant { Id = 3, Name = "The Original Restaurant" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
