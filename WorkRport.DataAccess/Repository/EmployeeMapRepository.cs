using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkReport.Models.Models;
using WorkRport.DataAccess.Repository.IRepository;

namespace WorkRport.DataAccess.Repository
{
    public class EmployeeMapRepository :Repository<EmployeeMapping>, IEmployeeMapRepository
    {
        private ApplicationDbContext _db;

        public EmployeeMapRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void update(EmployeeMapping obj)
        {
            _db.employeeMappings.Update(obj);
        }

        // Implementation of GetReportingOfficerNames method
        //public List<string> GetReportingOfficerNames(List<string> employeeIds)
        //{
        //    //return _db.employeeMappings
        //    //    .Where(e => employeeIds.Contains(e.EmployeeId))
        //    //    .Select(e => e.ReportingOfficerId)
        //    //    .ToList();

        //    // Join EmployeeMapping with Employee to get ReportingOfficerName by EmployeeID
        //    var reportingOfficers = (from empMap in _db.employeeMappings
        //                             join emp in _db.Users on empMap.EmployeeId equals emp.Id
        //                             where employeeIds.Contains(empMap.EmployeeId)
        //                             select emp.EmployeeName).ToList();

        //    return reportingOfficers;
        //}


        // public List<string> GetReportingOfficerName(string employeeIds)
        public string GetReviewingOfficerName(string employeeId)
        {
            //return _db.employeeMappings
            //    .Where(e => employeeIds.Contains(e.EmployeeId))
            //    .Select(e => e.ReportingOfficerId)
            //    .ToList();

            // Join EmployeeMapping with Employee to get ReportingOfficerName by EmployeeID
            //var reportingOfficers = (from empMap in _db.employeeMappings
            //                         join emp in _db.Users on empMap.EmployeeId equals emp.Id
            //                         where employeeIds.Contains(emp.Id)
            //                         select emp.EmployeeName).ToList();

            //return reportingOfficers;


            var reviewingOfficerName = (from empMap in _db.employeeMappings
                                        join emp in _db.Users on empMap.EmployeeId equals emp.Id
                                        join reviewingOfficer in _db.Users on empMap.ReviewingOfficerId equals reviewingOfficer.Id
                                        where empMap.EmployeeId == employeeId
                                        select reviewingOfficer.EmployeeName).FirstOrDefault();

            return reviewingOfficerName;
        }


        public string GetReportingOfficerName(string employeeId)
        {
           
            var reportingingOfficerName = (from empMap in _db.employeeMappings
                                        join emp in _db.Users on empMap.EmployeeId equals emp.Id
                                        join portingingOfficer in _db.Users on empMap.ReportingOfficerId equals portingingOfficer.Id
                                        where empMap.EmployeeId == employeeId
                                        select portingingOfficer.EmployeeName).FirstOrDefault();

            return reportingingOfficerName;
        }
    }
}
