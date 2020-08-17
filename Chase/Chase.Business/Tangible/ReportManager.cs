using Chase.Business.Notional;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;

namespace Chase.Business.Tangible
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public void AddedReport(Report report)
        {
            _reportDal.Add(report);
        }
        
        public Report GetByReportId(int id)
        {
            //güncellenecek ReportId'yi çektik.
            return _reportDal.Get(r => r.ReportId == id);
        }

        public void DeletedReports(int id)
        {
            _reportDal.Delete(new Report {ReportId = id});
        }

        public void ModifiedReports(Report report)
        {
            _reportDal.Update(report);
        }

        public int GetStaffReportCount(int id)
        {
           return _reportDal.GetStaffReportCount(id);
        }
    }
}