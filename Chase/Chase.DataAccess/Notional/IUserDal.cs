using System.Collections.Generic;
using System.Linq;
using Chase.Core.DataAccess;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Notional
{
    public interface IUserDal : IEntityRepository<AppUser>
    {
        List<AppUser> FetchNonAdmins();
        List<AppUser> FetchNonStaff();

    }
}