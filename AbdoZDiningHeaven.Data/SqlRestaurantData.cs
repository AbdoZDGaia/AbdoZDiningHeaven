using AbdoZDiningHeaven.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AbdoZDiningHeaven.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly DiningDBContext _ctx;

        public SqlRestaurantData(DiningDBContext ctx)
        {
            _ctx = ctx;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            var result = _ctx.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public Restaurant Delete(int restId)
        {
            var rest = _ctx.Restaurants.FirstOrDefault(r => r.Id == restId);
            if (rest != null)
                _ctx.Restaurants.Remove(rest);
            return rest;
        }

        public Restaurant GetById(int id)
        {
            var result = _ctx.Restaurants.Find(id);
            return result;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var result = _ctx.Restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.ToUpper().Contains(name.ToUpper()))
                .OrderBy(r => r.Name).ToList();
            return result;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = _ctx.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}