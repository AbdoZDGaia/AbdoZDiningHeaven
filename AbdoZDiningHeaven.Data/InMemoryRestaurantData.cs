using AbdoZDiningHeaven.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbdoZDiningHeaven.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> RestaurantsList { get; set; }
        public InMemoryRestaurantData()
        {
            RestaurantsList = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="AbdoZ Rest",Cuisine=CuisineType.None,Location="Tanta"},
                new Restaurant{Id=2,Name="Yankee's Rest",Cuisine=CuisineType.Mexican,Location="NY"},
                new Restaurant{Id=3,Name="Le Monde Rest",Cuisine=CuisineType.Italian,Location="Toronto"},
                new Restaurant{Id=4,Name="Trees Rest",Cuisine=CuisineType.Indian,Location="London"}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var result = RestaurantsList.Where(r => string.IsNullOrEmpty(name) || r.Name.ToUpper().Contains(name.ToUpper())).OrderBy(r => r.Name);
            return result;
        }

        public Restaurant GetById(int id)
        {
            var result = RestaurantsList.SingleOrDefault(r => r.Id == id);
            return result;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var rest = RestaurantsList.SingleOrDefault(r => r.Id == restaurant.Id);
            if (rest == null)
                return new Restaurant();

            RestaurantsList.Remove(rest);
            RestaurantsList.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = RestaurantsList.Max(r => r.Id) + 1;
            RestaurantsList.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int restId)
        {
            var rest = RestaurantsList.SingleOrDefault(r => r.Id == restId);
            if (rest != null)
            {
                RestaurantsList.Remove(rest);
            }

            return rest;
        }
    }
}
