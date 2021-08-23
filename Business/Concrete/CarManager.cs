using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRuıles;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results.Utilities;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add")]
        public IResult Add(Car car)
        {
           IResult result = BusinessRules.Run(controlBrandLimitCar(car.BrandId), CheckModelAndPrice(car.ModelYear, car.DailyPrice));

            if (result !=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Uptade(Car car)
        {
            controlBrandLimitCar(car.BrandId);

            _carDal.Uptade(car);
            return new Result(true, Messages.CarUpdated);
        }

        private IResult controlBrandLimitCar(int brandId)
        {
            var modelCount = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (modelCount >= 15)
            {
                return new ErrorResult(Messages.carLimitError);
            }
            return new SuccesResult();
        }
        private IResult CheckModelAndPrice(int modelYear, int price)
        {
            if (modelYear>=2015 && price<250)
            {
                return new ErrorResult(Messages.carPriceLower);   
            }
            return new SuccesResult();
        }

        
    }
}
