using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chase.Entities.Notional;
using Chase.Entities.Tangible;

namespace Chase.Entities.DTOs
{
    public class DutyListAllDto :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Urgency Urgency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
        public int StaffId { get; set; }//Personel Id


        
    }
}