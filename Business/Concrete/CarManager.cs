using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //Databaseye erişecek olan nesne
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        public List<Car> GetAll()
        {

            return _carDal.GetAll();
        }
    }
}
