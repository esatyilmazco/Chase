using System.Collections.Generic;
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IUserService
    {
        List<AppUser> FetchNonAdmins();
        List<AppUser> FetchNonStaff();

    }
}