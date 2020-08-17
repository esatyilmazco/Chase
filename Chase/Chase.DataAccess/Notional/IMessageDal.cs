using System.Collections.Generic;
using Chase.Core.DataAccess;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Notional
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> UnReadMessage(int userId);
    }
}