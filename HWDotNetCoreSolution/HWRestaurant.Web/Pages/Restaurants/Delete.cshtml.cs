using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HWRestaurant.Web.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public ActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {               
                return RedirectToPage("./NotFound");
            }          

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);

            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

                TempData["Message"] = $"{restaurant.Name} deleted";
                 return RedirectToPage("./List");

            
        }
       
    }
}