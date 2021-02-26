using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalDetail);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null && _rentalDal.GetRentalDetails(I => I.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.InvalidRental);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }
    }
}
