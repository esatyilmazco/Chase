using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Chase.Core.Entities;

namespace Chase.Entities.Tangible
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime? MessageSendingDate { get; set; } = DateTime.Now;
        public bool Case { get; set; }
        public string ThePersonWhoSentTheMessage { get; set; }

    }
}