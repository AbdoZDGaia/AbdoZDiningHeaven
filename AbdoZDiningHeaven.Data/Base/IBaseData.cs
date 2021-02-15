namespace AbdoZDiningHeaven.Data
{
    public interface IBaseData<T> where T : class
    {
        T GetById(int id);
        T Update(T entity);
        T Add(T entity);
        T Delete(int id);
        int Commit();
    }
}