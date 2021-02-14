using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbdoZDiningHeaven.Core;
using AbdoZDiningHeaven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbdoZDiningHeaven.App.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restId.HasValue)
            {
                Restaurant = _restaurantData.GetById(restId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }

            TempData["Message"] = "Restaurant Saved Successfully.";
            _restaurantData.Commit();
            return RedirectToPage("./Detail", new { restId = Restaurant.Id });
        }
    }
}
