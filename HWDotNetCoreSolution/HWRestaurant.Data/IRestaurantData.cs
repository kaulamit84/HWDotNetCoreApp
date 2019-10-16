using HWRestaurant.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll(); //get all restaurants
        IEnumerable<Restaurant> GetRestaurantsByName(string name); //get restaurant by name
        Restaurant GetById(int id); //get restaurant by Id
        Restaurant Update(Restaurant updateRestaurant); //update restaurant
        Restaurant Add(Restaurant addRestaurant); //add
        Restaurant Delete(int id); //delete
        int GetCountOfRestaurants(); //count restaurants
        int Commit();

    }
}
