using Business.Abstract;
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
        public List<Colour> GetAll()
        {
            return _colourDal.GetAll();
        }

        public List<Colour> GetByColourId(int ıd)
        {
            return _colourDal.GetAll(c => c.ColourId == ıd);
        }
    }
}
