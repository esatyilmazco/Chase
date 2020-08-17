using System.Linq;
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;

namespace Chase.DataAccess.Tangible
{
    public class EfReportDal : EfEntityRepository<Report, ChaseContext>, IReportDal
    {
        private readonly ChaseContext _chaseContext;

        public EfReportDal(ChaseContext chaseContext)
        {
            _chaseContext = chaseContext;
        }
        //Personelin Yazdığı Rapor Sayısı
        public int GetStaffReportCount(int id)
        {
            var userValue = _chaseContext.Duties.Include(I => I.Reports).Where(I => I.AppUserId == id);
            return userValue.SelectMany(I => I.Reports).Count();
        }
    }
}