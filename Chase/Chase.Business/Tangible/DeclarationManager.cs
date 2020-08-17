using System.Collections.Generic;
using System.Linq;
using Chase.Business.Notional;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;

namespace Chase.Business.Tangible
{
    public class DeclarationManager : IDeclarationService
    {
        private readonly IDeclarationDal _declarationDal;

        public DeclarationManager(IDeclarationDal declarationDal)
        {
            _declarationDal = declarationDal;
        } 

        public void AddedDeclaration(Declaration declaration)
        {
            _declarationDal.Add(declaration);
        }


        public void UpdatedDeclaration(Declaration declaration)
        {
            _declarationDal.Update(declaration);
        }

        public List<Declaration> GetListAllDeclarations()
        {
            return _declarationDal.GetAll().OrderByDescending(d => d.Id).ToList();
        }

        public Declaration GetByDeclarationId(int id)
        {
            return _declarationDal.Get(d => d.Id == id);
        }

        public List<Declaration> UnreadNotification(int userId)
        {
            return _declarationDal.UnreadNotification(userId).ToList();
        }
    }
}