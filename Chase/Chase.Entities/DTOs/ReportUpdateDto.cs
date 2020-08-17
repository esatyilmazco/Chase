using Chase.Entities.Notional;

namespace Chase.Entities.DTOs
{
    public class ReportUpdateDto : IDto
    {
        public int Id { get; set; }
        public string ReportDefinition { get; set; }
        public string ReportDetail { get; set; }
    }
}