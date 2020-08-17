using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IDutyService
    {
        Duty GetByDutyId(int id);
        void AddedDuty(Duty duty);
        void UpdatedDuty(Duty duty);
        void DeletedDuty(int deletedDutyId);
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