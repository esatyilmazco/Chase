using System;
using System.Collections.Generic;
using Chase.Entities.Notional;
using Chase.Entities.Tangible;

namespace Chase.Entities.DTOs
{
    public class MessageDto : IDto
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime? MessageSendingDate { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool Case { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public string ThePersonWhoSentTheMessage { get; set; }
    }
}