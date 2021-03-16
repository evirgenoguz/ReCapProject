using Business.Concrete;
using Core.Utilities.Results;
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
            Console.WriteLine("Dirmil Rent A Car");
            
            //AddRentalTest();

            //CarDetailsTest();

            //CarTest();

            //CategoryTest();

            //CustomerTestWithDto();

            //UserTest();

            //CustomerTestWithoutDTO();

        }

        private static void AddRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                RentalId = 2,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(3)
            });
        }

        private static IDataResult<Car> GetCarById(int selectedCarId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var selectedCar = carManager.GetById(selectedCarId);
            return selectedCar;
        }

        private static IDataResult<Customer> GetCustomerById(int selectedCustomerId)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var selectedCustomer = customerManager.GetById(selectedCustomerId);
            return selectedCustomer;
        }

        private static void CustomerTestWithDto()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetCustomerDetails();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CustomerId + "\t" + customer.FirstName + "\t" + customer.LastName + "\t" + customer.Email + "\t" + customer.CompanyName);
                }
            }
        }

        private static void CustomerTestWithoutDTO()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            foreach (var customer in result.Data)
            {
                //DTO yaptıktan sonra burada customer name vs gelicek user ıd ile yapıcam
                Console.WriteLine(customer.CustomerId + "\t" + customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName + "\t" + user.LastName + "\t" + user.Email);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId + "\tBrand Name : " + car.BrandName + "\tColor Name : " + car.ColorName + "\tModel Year : " + car.ModelYear + "\tDaily Price : " + car.DailyPrice);
                }
            }
        }

        private static void CategoryTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId + "   " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            foreach (Car car in result.Data)
            {
                Console.WriteLine("\nCar ID : " + car.CarId + "\nDaily Price : " + car.DailyPrice + "\nDescription : " + car.Description);
                Console.WriteLine("--------------------------------");
            }

            Console.WriteLine("********************************");

            var result2 = carManager.GetCarsByBrandId(1);

            foreach (var car in result2.Data)
            {
                Console.WriteLine("\nCar ID : " + car.CarId + "\nDaily Price : " + car.DailyPrice + "\nDescription : " + car.Description);
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
