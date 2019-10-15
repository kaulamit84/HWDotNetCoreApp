using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace HWRestaurant.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public string Message { get; set; }

        //DI Injection
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}