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
        public List<CarDetailDto> getCarDetails()
        {
            using (SqlContext sqlContext = new SqlContext())
            {
                var result =
                    from car in sqlContext.Cars
                    join color in sqlContext.Colors on car.ColorId equals color.Id
                    join Brand in sqlContext.Brands on car.BrandId equals Brand.Id
                    select new CarDetailDto
                    {
                        CarName = car.Description, ColorName = color.ColorName, BrandName = Brand.BrandName,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
