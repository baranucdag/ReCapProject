using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : IEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cust in context.Customers
                             on r.CustomerId equals cust.CustomerId
                             join u in context.Users
                             on cust.UserId equals u.UserId
                             select new RentalDetailDto()
                             {
                                 RentalId = r.RentalId,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}
