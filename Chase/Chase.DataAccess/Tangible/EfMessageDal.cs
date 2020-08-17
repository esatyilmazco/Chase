using System.Collections.Generic;
using System.Linq;
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;

namespace Chase.DataAccess.Tangible
{
    public class EfMessageDal : EfEntityRepository<Message, ChaseContext>, IMessageDal
    {
        private readonly ChaseContext _chaseContext;

        public EfMessageDal(ChaseContext chaseContext)
        {
            _chaseContext = chaseContext;
        }

        public List<Message> UnReadMessage(int userId)
        {
            return _chaseContext.Messages.Where(I => I.AppUserId == userId && !I.Case).OrderByDescending(I => I.Id)
                .ToList();
        }
        
    }
}