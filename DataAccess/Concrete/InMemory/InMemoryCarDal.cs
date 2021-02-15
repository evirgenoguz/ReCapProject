using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //Database simüle ediyoruz constructorda arabalarımızı oluşturduk
                new Car{CarId = 1, CategoryId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 150, Description = "Standart Kiralık Araç" },
                new Car{CarId = 2, CategoryId = 2, ColorId = 2, ModelYear = 2014, DailyPrice = 200, Description = "Orta Seviye Kiralik Araç"},
                new Car{CarId = 3, CategoryId = 3, ColorId = 2, ModelYear = 2016, DailyPrice = 250, Description = "Üst Seviye Kiralık Araç" },
                new Car{CarId = 4, CategoryId = 3, ColorId = 3, ModelYear = 2016, DailyPrice = 250, Description = "Üst Seviye Kiralık Araç" },
                new Car{CarId = 5, CategoryId = 4, ColorId = 7, ModelYear = 2019, DailyPrice = 500, Description = "Lüks Kiralık Araç" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car); //eklenecek arabayı ekledik. //Database eklemiş gibi
        }

        public void Delete(Car car)
        {
            Car productToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId); //linq kullanarak referansı c ye atayıp işlem yaptık c# ın güzel yanı
            _cars.Remove(productToDelete); //burada remove metodu ile listeden çıkardık
        }

        public List<Car> GetAll()
        {
            //listedeki tüm araçları ve özelliklerini çağıracağız
            return _cars; //_cars daki elemanları return ile methoddan döndürdük.
        }

        public List<Car> GetById(int carId)
        {
            //Carıd sine göre araba nesnesini çağıracağız
            return _cars.Where(c => c.CarId == carId).ToList(); //liste döndürdük buradan ama where ile liste alınmadığından listeye çevirdik
        }

        public void Update(Car car)
        {
            Car updateToCar = _cars.SingleOrDefault(c => c.CarId == car.CarId); //değişecek kar ıdsine göre bulunur ve alttaki satırlarda özellikleri değişir.
            
            updateToCar.CategoryId = car.CategoryId;
            updateToCar.ColorId = car.ColorId;
            updateToCar.ModelYear = car.ModelYear;
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.Description = car.Description;
        }
    }
}
