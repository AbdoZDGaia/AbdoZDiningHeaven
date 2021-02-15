using AbdoZDiningHeaven.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace AbdoZDiningHeaven.Data
{
    public class SqlBaseData<TEntity> where TEntity : BaseEntity
    {
        private readonly DiningDBContext _ctx;

        public SqlBaseData(DiningDBContext ctx)
        {
            _ctx = ctx;
        }

        public TEntity Add(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.AddedOn = DateTime.Now;
            _ctx.Add(entity);
            return entity;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public TEntity Delete(int id)
        {
            //implementing soft delete
            var entity = _ctx.Set<TEntity>().Find(id);
            entity.IsDeleted = true;
            entity.ModifiedOn = DateTime.Now;
            var result = _ctx.Set<TEntity>().Attach(entity);
            result.State = EntityState.Modified;
            return entity;


            //var entity = _ctx.Set<TEntity>().Find(id);
            //if (entity != null)
            //    _ctx.Set<TEntity>().Remove(entity);
            //return entity;
        }

        public TEntity GetById(int id)
        {
            var entity = _ctx.Set<TEntity>().Find(id);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var result = _ctx.Set<TEntity>().Attach(entity);
            result.State = EntityState.Modified;
            return entity;
        }
    }
}
