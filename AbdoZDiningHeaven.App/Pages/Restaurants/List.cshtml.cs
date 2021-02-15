using AbdoZDiningHeaven.Core;
using AbdoZDiningHeaven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AbdoZDiningHeaven.App.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;

        public IEnumerable<Restaurant> RestaurantsList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            RestaurantsList = _restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}
