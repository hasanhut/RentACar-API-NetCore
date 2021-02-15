using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                return filter == null
                    ? sqlContext.Set<Car>().ToList()
                    : sqlContext.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                return sqlContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                var addedEntity = sqlContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                sqlContext.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                var updatedEntity = sqlContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                var deletedEntity = sqlContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                sqlContext.SaveChanges();
            }
        }
    }
}
