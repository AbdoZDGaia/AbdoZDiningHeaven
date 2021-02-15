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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
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
            return Page();
        }

        public IActionResult OnPost(int restId)
        {
            Restaurant = _restaurantData.Delete(restId);
            _restaurantData.Commit();

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{Restaurant.Name} was deleted successfully.";
            return RedirectToPage("./List");
        }
    }
}
