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

        public IResult Add(User user)
        {
            _userService.Add(user);
            return new SuccesResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userService.Delete(user);
            return new SuccesResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userService.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccesDataResult<User>(_userService.Get(u => u.UserId==id));
        }

        public IResult Update(User user)
        {
            _userService.Uptade(user);
            return new SuccesResult(Messages.UserUpdated);
        }
    }
}
