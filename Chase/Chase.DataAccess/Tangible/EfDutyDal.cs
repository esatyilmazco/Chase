using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Chase.Core.DataAccess;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;

namespace Chase.DataAccess.Tangible
{
    public class EfDutyDal : EfEntityRepository<Duty, ChaseContext>, IDutyDal
    {
        private readonly ChaseContext _chaseContext;

        public EfDutyDal(ChaseContext chaseContext)
        {
            _chaseContext = chaseContext;
        }

        public List<Duty> Minus()
        {
            //Durumu False Olanları  ve en son oluşturulmuş görevi tarihli Getir.
            //Görevler İşler ile gelecek.
            //Görevleri ve İşleri Dahil ettik.
            return _chaseContext.Duties.Include(I => I.Urgency).Where(I => !I.Case)
                .OrderByDescending(I => I.CreationDate).ToList();
        }

        public List<Duty> FetchAllTables()
        {
            //Tüm Tablolar getirilecek.
            return _chaseContext.Duties.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser)
                .Where(I => !I.Case).OrderByDescending(I => I.CreationDate).ToList();
        }

        public List<Duty> FetchAllTables(Expression<Func<Duty, bool>> filter)
        {
            return _chaseContext.Duties.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser)
                .Where(filter)
                .OrderByDescending(I => I.CreationDate).ToList();
        }

        public Duty BringWithUrgencyId(int id)
        {
            //tamamlanmamış görevleri getir ve benim vermiş oldugum Id'sine eşit olanı getir.
            return _chaseContext.Duties.Include(I => I.Urgency).FirstOrDefault(I => !I.Case && I.Id == id);
        }

        public List<Duty> GetByUserId(int userId)
        {
            return _chaseContext.Duties.Where(I => I.AppUserId == userId).ToList();
        }

        //Görevi Raporlar ile getir.(Görev'i Id ile getireceğiz) ve Kullanıcıları da getireceğiz.
        public Duty GetReportsAndUsers(int id)
        {
            return _chaseContext.Duties.Include(I => I.Reports).Include(I => I.AppUser).FirstOrDefault(I => I.Id == id);
        }

        public List<Duty> GetAllTablesAndCompleteJobs(int userId)
        {
            //tüm tablolar ve tamamlanmış işler.
            return _chaseContext.Duties.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser)
                .Where(I => I.AppUserId == userId && I.Case).OrderByDescending(I => I.CreationDate).ToList();
            
        }

        //Personelin Tamamladığı Görev Sayısı
        public int GetNumberOfTasksCompletedByTheStaff(int id)
        {
            //Case=tamamlanan(TRUE)
            return _chaseContext.Duties.Count(I => I.AppUserId == id && I.Case);
        }

        //Personelin Gerçekleştirecek Görev Sayısı
        public int GetNumberOfTasksToBePerformedByTheStaff(int id)
        {
            return _chaseContext.Duties.Count(I => I.AppUserId == id && !I.Case);
            //!Case=tamamlanmayan(FALSE)

        }

      
    }
}