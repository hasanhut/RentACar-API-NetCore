using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car
            {
                Id = 10,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 50,
                ModelYear = 2015,
                Description = "BMW 210i"
            });

            carManager.Delete(new Car
            {
                Id = 3
            });

            carManager.Update(new Car
            {
                Id=10,
                ColorId = 1,
                BrandId = 1,
                ModelYear = 2020,
                DailyPrice = 50,
                Description = "BMW 120i"
            });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
