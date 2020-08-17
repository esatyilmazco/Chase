using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chase.Core.DataAccess;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;

namespace Chase.DataAccess.Notional
{
    public interface IDutyDal : IEntityRepository<Duty>
    {
        List<Duty> Minus();
        List<Duty> FetchAllTables();
        List<Duty> FetchAllTables(Expression<Func<Duty, bool>> filter); 
        Duty BringWithUrgencyId(int id);
        List<Duty> GetByUserId(int userId);
        Duty GetReportsAndUsers(int id);
        List<Duty> GetAllTablesAndCompleteJobs(int userId);
        int GetNumberOfTasksCompletedByTheStaff(int id);
        int GetNumberOfTasksToBePerformedByTheStaff(int id);
    }
}