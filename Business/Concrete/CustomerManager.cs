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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerManager;
        public CustomerManager(ICustomerDal colourDal)
        {
            _customerManager = colourDal;

        }
        public List<Customer> GetAll()
        {
            return _customerManager.GetAll();
        }
    }
}
