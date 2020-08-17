using System.Collections.Generic;
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IUrgencyService
    {
        List<Urgency> ListOfUrgency();
        void AddingUrgency(Urgency urgency);
        void UpdatedUrgency(Urgency urgency);
        void DeletedUrgency(int deletedUrgencyId);
        Urgency GetByUrgencyId(int id);

    }
}