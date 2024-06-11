using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.Models.Models;

namespace WorkRport.DataAccess.Repository.IRepository
{
    public interface ITimeSheetRepository : IRepository<TimeSheet>
    {
        void update(TimeSheet obj);

        
        void save();

        IEnumerable<TimeSheet> GetTimeSheetsByEmployeeId(string employeeId);

        IEnumerable<TimeSheet> GetTimeSheetsById(Guid Tsid);
    }
}
