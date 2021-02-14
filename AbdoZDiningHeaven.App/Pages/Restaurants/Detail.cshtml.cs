using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbdoZDiningHeaven.Core;
using AbdoZDiningHeaven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbdoZDiningHeaven.App.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restId)
        {
            Restaurant = _restaurantData.GetById(restId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
