using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Core
{
    public class Restaurant
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
           
        public CuisineType Cuisine { get; set; }


    }
}
