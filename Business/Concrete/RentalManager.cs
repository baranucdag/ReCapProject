using Business.Abstract;
using Core.Results.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccesResult("Rental added");

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult("Rental deleted");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(), "Rental listed");
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId),"rental listed.");
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccesDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(),"Rental detail listed.");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Uptade(rental);
            return new SuccesResult("Rental updated.");
        }
    }
}
