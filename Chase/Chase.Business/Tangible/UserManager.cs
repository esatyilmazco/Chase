using System.Collections.Generic;
using Chase.Business.Notional;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;

namespace Chase.Business.Tangible
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> FetchNonAdmins()
        {
            return _userDal.FetchNonAdmins();
        }

        public List<AppUser> FetchNonStaff()
        {
            return _userDal.FetchNonStaff();
        }
    }
}