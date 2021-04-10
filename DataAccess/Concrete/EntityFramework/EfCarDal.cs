using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,SqlContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                var result =
                    from car in sqlContext.Cars
                    join color in sqlContext.Colors on car.ColorId equals color.ColorId
                    join brand in sqlContext.Brands on car.BrandId equals brand.BrandId
                    //join image in sqlContext.CarImages on car.CarId equals image.CarId
                    select new CarDetailDto
                    {
                        CarId = car.CarId,
                        CarName = car.Description,
                        ColorName = color.ColorName, 
                        BrandName = brand.BrandName,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        //ImagePath = image.ImagePath
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
