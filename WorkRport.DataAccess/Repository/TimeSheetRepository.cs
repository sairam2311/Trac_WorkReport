using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkReport.Models.Models;
using WorkRport.DataAccess.Repository.IRepository;

namespace WorkRport.DataAccess.Repository
{
    public class TimeSheetRepository : Repository<TimeSheet>, ITimeSheetRepository
    {

        private ApplicationDbContext _db;

        public TimeSheetRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void update(TimeSheet obj)
        {
            _db.timeSheets.Update(obj);   
        }

        public IEnumerable<TimeSheet> GetTimeSheetsByEmployeeId(string employeeId)
        {
            return _db.timeSheets.Where(t => t.EmployeeGUID == employeeId).ToList();
        }

        public IEnumerable<TimeSheet> GetTimeSheetsById(Guid Tsid)
        {
            return _db.timeSheets.Where(t => t.TSid == Tsid).ToList();
        }

    }
}
