
using Chase.Entities.Notional;

namespace Chase.Entities.DTOs
{
    public class ReportDto : IDto
    {
        public string ReportDefinition { get; set; }
        public string ReportDetail { get; set; }
        public int DutyId { get; set; }
    }
}