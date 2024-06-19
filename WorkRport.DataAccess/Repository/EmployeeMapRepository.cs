using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public List<empreviewreport> GetOfficersID(string employeeId)
        {
            // Query the database for matching records
            var employeeMappings = _db.employeeMappings
                .Where(emp => emp.EmployeeId == employeeId)
                .ToList(); // Get a list of matching records


            var revrep = employeeMappings.Select(emp => new empreviewreport
            {
                EmployeeGUID = emp.EmployeeId,
                ReportGUID = emp.ReportingOfficerId,
                ReviewGUID = emp.ReviewingOfficerId
            }).ToList();

            //(select * from  _db.employeeMappings  emp where emp.EmployeeId = employeeId).FirstOrDefault();
            return revrep;
        }
     


        public List<EmployeeWithRole> GeEmployeesbyrevieworRep(string employeeId)
        {
            //var employeesUnderReportingOfficer = (from empMap in _db.employeeMappings
            //                                      join emp in _db.Users on empMap.EmployeeId equals emp.Id
            //                                      join reportingOfficer in _db.Users on empMap.ReportingOfficerId equals reportingOfficer.Id || empMap.ReviewingOfficerId equals reportingOfficer.Id

            //                                      join userRole in _db.UserRoles on emp.Id equals userRole.UserId
            //                                      join role in _db.Roles on userRole.RoleId equals role.Id
            //                                      where empMap.ReportingOfficerId == employeeId
            //                                      select new EmployeeWithRole
            //                                      {
            //                                          Id = emp.Id,
            //                                          employeeID = emp.EmployeeID,
            //                                          EmployeeName = emp.EmployeeName,
            //                                          RoleName = role.Name
            //                                      }).ToList();

            //return employeesUnderReportingOfficer;


            var employeesUnderReportingOfficer = (from empMap in _db.employeeMappings
                                                  join emp in _db.Users on empMap.EmployeeId equals emp.Id
                                                  join reportingOfficer in _db.Users on empMap.ReportingOfficerId equals reportingOfficer.Id
                                                  join reviewingOfficer in _db.Users on empMap.ReviewingOfficerId equals reviewingOfficer.Id into roGroup
                                                  from reviewingOfficer in roGroup.DefaultIfEmpty() // Left join for reviewing officer
                                                  join userRole in _db.UserRoles on emp.Id equals userRole.UserId
                                                  join role in _db.Roles on userRole.RoleId equals role.Id
                                                  where empMap.ReportingOfficerId == employeeId || empMap.ReviewingOfficerId == employeeId
                                                  select new EmployeeWithRole
                                                  {
                                                      Id = emp.Id,
                                                      employeeID = emp.EmployeeID,
                                                      EmployeeName = emp.EmployeeName,
                                                      RoleName = role.Name
                                                  }).ToList();

            return employeesUnderReportingOfficer;
        }

        //// Define the EmployeeWithRole class to hold the result
        //public class EmployeeWithRole
        //{
          
        //}

    }
}
