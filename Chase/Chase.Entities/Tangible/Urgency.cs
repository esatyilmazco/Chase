using System.Collections.Generic;
using Chase.Core.Entities;

namespace Chase.Entities.Tangible
{
    public class Urgency : IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        //bir aciliyetin'de görev alması lazım
        public List<Duty> Duties { get; set; } //çok olan görevler.
    }
}