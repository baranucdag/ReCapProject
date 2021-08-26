using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : IEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colours
                             on c.ColourId equals co.ColourId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId=b.BrandId,
                                 BrandName = b.BrandName,
                                 ColourId=c.ColourId,
                                 ColourName = co.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
