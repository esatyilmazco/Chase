using System;
using System.Collections.Generic;
using System.Linq;
using Chase.Entities.Notional;
using Chase.Entities.Tangible;

namespace Chase.Entities.DTOs
{
    public class DutyDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<Report> Reports { get; set; }
        public AppUser AppUser { get; set; }
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
        public List<Urgency> Urgencies { get; set; }

        
    }
}