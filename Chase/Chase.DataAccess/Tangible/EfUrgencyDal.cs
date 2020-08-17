
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Tangible
{
    public class EfUrgencyDal:EfEntityRepository<Urgency,ChaseContext>,IUrgencyDal
    {
     
    }
}