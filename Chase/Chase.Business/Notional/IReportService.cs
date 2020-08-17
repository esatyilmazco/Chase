
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IReportService
    {
        void AddedReport(Report report);
        Report GetByReportId(int id);
        void DeletedReports(int id);
        void ModifiedReports(Report report);
        int GetStaffReportCount(int id);

    }
}