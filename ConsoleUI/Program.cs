using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //CategoryTest();

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Brand Name : " + car.BrandName + "\tColor Name : " + car.ColorName + "\tModel Year : " + car.ModelYear + "\tDaily Price : " + car.DailyPrice);
            }



        }

        private static void CategoryTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "   " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("\nCar ID : " + car.CarId + "\nDaily Price : " + car.DailyPrice + "\nDescription : " + car.Description);
                Console.WriteLine("--------------------------------");
            }

            Console.WriteLine("********************************");

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("\nCar ID : " + car.CarId + "\nDaily Price : " + car.DailyPrice + "\nDescription : " + car.Description);
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
