using Business.Abstract;
using Business.Constans;
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
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public IResult Add(Colour colour)
        {
            _colourDal.Add(colour);
            return new SuccesResult(Messages.ColourUpdated);
        }

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccesResult(Messages.ColourDeleted);

        }

        public IResult Update(Colour colour)
        {
            _colourDal.Uptade(colour);
            return new SuccesResult(Messages.ColourUpdated);

        }

        IDataResult<List<Colour>> IColourService.GetAll()
        {
            return new SuccesDataResult<List<Colour>>(_colourDal.GetAll());
        }

        IDataResult<Colour> IColourService.GetByColourId(int id)
        {
            return new SuccesDataResult<Colour>(_colourDal.Get(c => c.ColourId == id));
        }
    }
}
