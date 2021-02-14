using AbdoZDiningHeaven.Core;
using System.Collections.Generic;
using System.Text;

namespace AbdoZDiningHeaven.Data
{
    public interface IRestaurantData : IBaseData<Restaurant>
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }
}
