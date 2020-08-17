using Chase.Core.Entities;

namespace Chase.Entities.Tangible
{
    public class Report : IEntity
    {
        public int ReportId { get; set; }
        public string ReportDefinition { get; set; }
        public string ReportDetail { get; set; }
        public int DutyId { get; set; }
        //tek olan nesne Duty
        public Duty Duty { get; set; }
    }
}