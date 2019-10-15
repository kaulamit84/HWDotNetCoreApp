using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;

namespace HWRestaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;       

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {id = 1, Name ="Domino", Location="Maryland", Cuisine=CuisineType.Chinese},
                new Restaurant {id = 2, Name ="Cinnamon", Location="London", Cuisine=CuisineType.Indian},
                new Restaurant {id = 3, Name ="La Costa", Location="California", Cuisine=CuisineType.Mexican},
                new Restaurant {id = 4, Name ="Marriagnos", Location="Atlanta", Cuisine=CuisineType.Italian},
            };
        }


        public IEnumerable<Restaurant> GetAll()
        {
            //LINQ
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            //LINQ
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.id == id);
        }
       
    }
}
