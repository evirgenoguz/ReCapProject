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

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("\nCar ID : " + car.CarId + "\nDaily Price : " +  car.DailyPrice + "\nDescription : " + car.Description);
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
