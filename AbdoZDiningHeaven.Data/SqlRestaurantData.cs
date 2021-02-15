using AbdoZDiningHeaven.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AbdoZDiningHeaven.Data
{
    public class SqlRestaurantData : SqlBaseData<Restaurant>, IRestaurantData
    {
        private readonly DiningDBContext _ctx;

        public SqlRestaurantData(DiningDBContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var result = _ctx.Restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.ToUpper().Contains(name.ToUpper()))
                .OrderBy(r => r.Name).ToList();
            return result;
        }
    }
}