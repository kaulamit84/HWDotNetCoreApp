﻿using HWRestaurant.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);      

        //Add Restaurant
        Restaurant Add(Restaurant addRestaurant);

        Restaurant Delete(int id);
        int Commit();

    }
}
