using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReport.Models.Models
{
    public class UserIndexViewModelTS
    {

        [ValidateNever]
        public IEnumerable<TimeSheet> TimeSheets { get; set; } // Add this property

        public TimeSheet TimeSheet { get; set; } // Add TimeSheet property

        [ValidateNever]
        public EditUserViewModelTS CurrentUser { get; set; }
        [ValidateNever]
        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
        [ValidateNever]

        public List<EmployeeWithRole> employeeWithRoles { get; set; }

        [ValidateNever]
        public List<ViewReportViewModel> reportViewModels { get; set; }


        [ValidateNever]
        public List<ErrorViewModel> ErrorViewModel { get; set; }

    }

    public class EditUserViewModelTS
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public List<RoleViewModelTS> Roles { get; set; }
        public string ReportingOfficerName { get; set; }
        public string ReviewingofficerName { get; set; }


    }

    public class RoleViewModelTS
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class EmployeeWithRole
    {
        public string Id { get; set; }
        public string employeeID { get; set; }
        public string EmployeeName { get; set; }
        public string RoleName { get; set; }
    }

    public class ViewReportViewModel
    {
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<TimeSheet> TimeSheets { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeID { get; set; }

        public string currentuser { get; set; } 

        public string ReviewOfc { get; set; }   
        public string ReportOfc { get; set; }
    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Add this property
        public string ErrorMessage { get; set; }
    }

    public class empreviewreport
    {
        public string EmployeeGUID { get; set; }
        public string ReviewGUID { get; set; }
        public string ReportGUID { get; set; }
    }


}
