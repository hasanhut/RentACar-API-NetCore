using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext sqlContext = new TContext())
            {
                return filter == null
                    ? sqlContext.Set<TEntity>().ToList()
                    : sqlContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext sqlContext = new TContext())
            {
                return sqlContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext sqlContext = new TContext())
            {
                var addedEntity = sqlContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                sqlContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext sqlContext = new TContext())
            {
                var updatedEntity = sqlContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext sqlContext = new TContext())
            {
                var deletedEntity = sqlContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                sqlContext.SaveChanges();
            }
        }
    }
}
