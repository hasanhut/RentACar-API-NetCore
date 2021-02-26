using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //AddCar(carManager);

            //CarDetails(carManager);

            //GetBrands(brandManager);

            //GetColors(colorManager);

            //AddRental(rentalManager);

            AllRented(rentalManager);


        }

        private static void AddRental(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentTime = DateTime.Now,
                ReturnDate = null
            });
        }

        private static void AllRented(RentalManager rentalManager)
        {
            Console.WriteLine("List of all rented cars.");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rental.RentalId + " - " + rental.CustomerName + " - " + rental.CarName + " - " + rental.RentDate +
                                  " - " + rental.ReturnDate);
            }
        }

        private static void GetColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarDetails(CarManager carManager)
        {
            foreach (var car in carManager.getCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car
            {
                Id = 6,
                BrandId = 4,
                ColorId = 2,
                DailyPrice = 75,
                ModelYear = 2021,
                Description = "Volkswagen Polo"
            });
        }
    }
}
