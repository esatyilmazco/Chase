using System.Collections.Generic;
using Chase.Core.DataAccess;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Notional
{
    public interface IDeclarationDal : IEntityRepository<Declaration>
    {
        List<Declaration> UnreadNotification(int userId);
    }
}