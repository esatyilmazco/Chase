using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Chase.Business.Notional;
using Chase.Business.ValidationRules.FluentValidation;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;
using FluentValidation;

namespace Chase.Business.Tangible
{
    public class DutyManager : IDutyService
    {
        private readonly IDutyDal _dutyDal;

        public DutyManager(IDutyDal dutyDal)
        {
            _dutyDal = dutyDal;
        }

        public Duty GetByDutyId(int id)
        {
            return _dutyDal.Get(d => d.Id == id);
        }

        public List<Duty> ListOfDuty()
        {
            //Eklenen Son Görevi Listeleyecek.
            return _dutyDal.GetAll().OrderByDescending(d => d.Id).ToList();
        }

        public void AddedDuty(Duty duty)
        {
            _dutyDal.Add(duty);
        }

        public void UpdatedDuty(Duty duty)
        {
            _dutyDal.Update(duty);
        }


        public void DeletedDuty(int deletedDutyId)
        {
            _dutyDal.Delete(new Duty {Id = deletedDutyId});
        }


        public List<Duty> Minus()
        {
            return _dutyDal.Minus();
        }

        public List<Duty> FetchAllTables()
        {
            return _dutyDal.FetchAllTables();
        }

        public List<Duty> FetchAllTables(Expression<Func<Duty, bool>> filter)
        {
            return _dutyDal.FetchAllTables(filter);
        }

        public Duty BringWithUrgencyId(int id)
        {
            return _dutyDal.BringWithUrgencyId(id);
        }

        public List<Duty> GetByUserId(int userId)
        {
            return _dutyDal.GetByUserId(userId);
        }

        public Duty GetReportsAndUsers(int id)
        {
            return _dutyDal.GetReportsAndUsers(id);
        }

        public List<Duty> GetAllTablesAndCompleteJobs(int userId)
        {
            return _dutyDal.GetAllTablesAndCompleteJobs(userId);
        }

        public int GetNumberOfTasksCompletedByTheStaff(int id)
        {
            return _dutyDal.GetNumberOfTasksCompletedByTheStaff(id);
        }

        public int GetNumberOfTasksToBePerformedByTheStaff(int id)
        {
            return _dutyDal.GetNumberOfTasksToBePerformedByTheStaff(id);
        }
    }
}