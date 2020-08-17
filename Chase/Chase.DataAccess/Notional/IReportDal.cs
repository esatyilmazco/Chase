using System.Collections.Generic;
using System.Linq;
using Chase.Core.DataAccess;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Notional
{
    public interface IReportDal:IEntityRepository<Report>
    {
        int GetStaffReportCount(int id);
    }
}