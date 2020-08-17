using System.Collections.Generic;
using System.Linq;
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Tangible
{
    public class EfUserDal : EfEntityRepository<AppUser, ChaseContext>, IUserDal
    {
        private readonly ChaseContext _chaseContext;

        public EfUserDal(ChaseContext chaseContext)
        {
            _chaseContext = chaseContext;
        }

        //Yönetici olmayan kullanıcılar listelenecek.
        public List<AppUser> FetchNonAdmins()
        {
            return _chaseContext.Users.Join(_chaseContext.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(_chaseContext.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Email = I.user.Email,
                UserName = I.user.UserName
            }).ToList();
        }

        public List<AppUser> FetchNonStaff()
        {
            return _chaseContext.Users.Join(_chaseContext.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(_chaseContext.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Admin").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Email = I.user.Email,
                UserName = I.user.UserName
            }).ToList();
        }
    }
}