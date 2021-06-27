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
    public class UserManager : IUserService
    {
        IUserDal _userService;
        public UserManager(IUserDal userDal)
        {
            _userService = userDal;
        }
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }
    }
}
