using Core.Results.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetByColourId(int id);
        IResult Add(Colour colour);
        IResult Update(Colour colour);
        IResult Delete(Colour colour);
    }
}
