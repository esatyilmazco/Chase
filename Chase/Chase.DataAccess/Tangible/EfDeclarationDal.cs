using System.Collections.Generic;
using System.Linq;
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Tangible
{
    public class EfDeclarationDal : EfEntityRepository<Declaration, ChaseContext>, IDeclarationDal
    {
        private readonly ChaseContext _chaseContext;

        public EfDeclarationDal(ChaseContext chaseContext)
        {
            _chaseContext = chaseContext;
        }
        public List<Declaration> UnreadNotification(int userId)
        {
            //Okunmamış Bildirimleri getir.(Bildirimlerin Sayısı ve appUserId 'yi getirecek.)
            //En Son Yapılan İş Bildirimi en Başta Çıkacak.
            return _chaseContext.Declarations.Where(I => I.AppUserId == userId && !I.Case).OrderByDescending(I => I.Id)
                .ToList();
        }

     
    }
}