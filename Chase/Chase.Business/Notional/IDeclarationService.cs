using System.Collections.Generic;
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IDeclarationService
    {
        void AddedDeclaration(Declaration declaration);
        void UpdatedDeclaration(Declaration declaration);
        Declaration GetByDeclarationId(int id);
        List<Declaration> UnreadNotification(int userId);

    }
}