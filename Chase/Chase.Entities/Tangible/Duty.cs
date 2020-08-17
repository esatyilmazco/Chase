using System;
using System.Collections.Generic;
using Chase.Core.Entities;

namespace Chase.Entities.Tangible
{
    public class Duty : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Case { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int UrgencyId { get; set; }
        //bir görevin acele olma durumu
        public Urgency Urgency { get; set; }
        //bir görevi bir kullanıcı olmak zorunda.
        public int? AppUserId { get; set; } //boş geçilebilir.
        public AppUser AppUser { get; set; }
        //bir görevin bir'den çok raporu olabilir.
        public List<Report> Reports { get; set; }
    }
}