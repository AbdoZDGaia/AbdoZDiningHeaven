using System.Collections.Generic;

namespace AbdoZDiningHeaven.Data
{
    public interface IBaseData<T>
    {
        T GetById(int id);
        T Update(T restaurant);
        T Add(T restaurant);
        T Delete(int restId);
        int Commit();
    }
}