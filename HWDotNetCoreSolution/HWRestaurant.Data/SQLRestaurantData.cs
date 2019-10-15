using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HWRestaurant.Data
{
    public class SQLRestaurantData : IRestaurantData
    {
        //Instance
        private readonly RestaurantDbContext db;

        //Initialize
        public SQLRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            db.Add(addRestaurant);
            return addRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name)
                        || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }
    }
}
