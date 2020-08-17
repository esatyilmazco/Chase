using System;
using System.Collections.Generic;
using System.Text;
using Chase.Core.Entities;

namespace Chase.Entities.Tangible
{
   public class Declaration:IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Explanation { get; set; }
        public bool Case { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
