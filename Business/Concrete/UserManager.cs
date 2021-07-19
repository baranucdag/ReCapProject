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
    public class UserManager : IUserService
    {
        IUserDal _userService;
        public UserManager(IUserDal userDal)
        {
            _userService = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userService.GetAll(),Messages.UserListed);
        }
    }
}
