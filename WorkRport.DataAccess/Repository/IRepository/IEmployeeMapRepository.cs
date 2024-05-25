using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.Models.Models;

namespace WorkRport.DataAccess.Repository.IRepository
{
    public interface IEmployeeMapRepository :IRepository<EmployeeMapping>
    {
        void update(EmployeeMapping obj);
        void save();

        // New method to get reporting officer names by employee IDs
       // List<string> GetReportingOfficerNames(List<string> employeeIds);


      //  List<string> GetReportingOfficerName(string employeeIds);

        string GetReviewingOfficerName(string employeeId);

        string GetReportingOfficerName(string employeeId);
    }
}
