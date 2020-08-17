using System.Collections.Generic;
using System.Linq;
using Chase.Business.Notional;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;

namespace Chase.Business.Tangible
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;

        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }

        public List<Urgency> ListOfUrgency()
        {
            //Eklenen Son İşi Listeleyecek.
            return _urgencyDal.GetAll().OrderByDescending(u => u.Id).ToList();
        }

        public void AddingUrgency(Urgency urgency)
        {
            _urgencyDal.Add(urgency);
        }

        public void UpdatedUrgency(Urgency urgency)
        {
            _urgencyDal.Update(urgency);
        }

        public void DeletedUrgency(int deletedUrgencyId)
        {
            _urgencyDal.Delete(new Urgency{Id =deletedUrgencyId });
        }

        public Urgency GetByUrgencyId(int id)
        {
            return _urgencyDal.Get(u => u.Id == id);
        }

       
    }
}