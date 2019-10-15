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

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant =
                restaurants.SingleOrDefault(r => r.id == updateRestaurant.id);
                if(restaurant != null)
                {
                    restaurant.Name = updateRestaurant.Name;
                    restaurant.Location = updateRestaurant.Location;
                    restaurant.Cuisine = updateRestaurant.Cuisine;
                }

                return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            restaurants.Add(addRestaurant);
            addRestaurant.id = restaurants.Max(r => r.id) + 1;
            return addRestaurant;
        }

        public Restaurant Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
