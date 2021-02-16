using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    BrandId = 1,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 100,
                    Description = "BMW 420i Cabrio"
                },
                new Car
                {
                    Id = 2,
                    BrandId = 1,
                    ColorId = 2,
                    ModelYear = 2016,
                    DailyPrice = 500,
                    Description = "BMW 740i"
                },
                new Car
                {
                    Id = 3,
                    BrandId = 2,
                    ColorId = 3,
                    ModelYear = 2018,
                    DailyPrice = 50,
                    Description = "Mercedes A200"
                },new Car
                {
                    Id = 4,
                    BrandId = 3,
                    ColorId = 1,
                    ModelYear = 2012,
                    DailyPrice = 20,
                    Description = "Ford Focus"
                },
                new Car
                {
                    Id = 5,
                    BrandId = 4,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 40,
                    Description = "Volkswagen Golf"
                }
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> getById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<CarDetailDto> getCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
