using Business.Abstract;
using Core.Results.Utilities;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandService.Add(user);
            return new SuccesResult(Messages.UserAdded);

        }

        public IResult Delete(Brand brand)
        {
            _userService.Delete(user);
            return new SuccesResult(Messages.UserDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand brand)
        {
            _colourDal.Uptade(colour);
            return new SuccesResult(Messages.ColourUpdated);
        }
    }
}
