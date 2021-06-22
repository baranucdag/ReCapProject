using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetAllByBrand(int BrandId);
        List<Car> GetAllById(int CarId);
        void Add(Car car);
        void Uptade(Car car);
        void Delete(Car car);
   
    }
}
