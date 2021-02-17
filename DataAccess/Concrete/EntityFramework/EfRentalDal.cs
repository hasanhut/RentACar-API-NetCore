using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,SqlContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (SqlContext context = new SqlContext())
            {
                var result =
                    from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join c in context.Cars on r.CarId equals c.Id
                    join cs in context.Customers on r.CustomerId equals cs.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    select new RentalDetailDto
                    {
                        RentalId = r.Id,
                        CarName = b.BrandName,
                        CustomerName = cs.CompanyName,
                        RentDate = r.RentTime,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
