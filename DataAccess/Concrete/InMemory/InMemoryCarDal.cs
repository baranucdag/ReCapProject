using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            { new Car { CarId = 1, BrandId = 1, DailyPrice = 35, Description = "just a car", ModelYear = 1012 },
              new Car {CarId=2, BrandId=2,DailyPrice=30, Description="not just a car", ModelYear=1010 },
              new Car {CarId=3, BrandId=1,DailyPrice=12, Description="not just a car means everything", ModelYear=2021 },
              new Car {CarId=4, BrandId=2,DailyPrice=39, Description="really a car", ModelYear=2022 }
            };
        }

        public void Add(Car car)
        {
            Car carToAdd = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Add(carToAdd);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int Brand)
        {
            return _cars.Where(p=>p.BrandId==Brand).ToList();
        }

        public List<Car> GetAllById(int CarId)
        {
            return _cars.Where(p => p.CarId == CarId).ToList();
        }

      

        public void Uptade(Car car)
        {
            Car carToUptade = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUptade.CarId = car.CarId;
            carToUptade.BrandId = car.BrandId;
            carToUptade.DailyPrice = car.DailyPrice;
            carToUptade.Description = car.Description;
            carToUptade.ModelYear = car.ModelYear;
        }
    }
}
