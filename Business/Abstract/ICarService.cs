using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> getCarsByBrandId(int id);
        List<Car> getCarsByColorId(int id);
        List<CarDetailDto> getCarDetails();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
