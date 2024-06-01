using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReport.Models.Models
{
    public class UserIndexViewModelTS
    {
        public EditUserViewModelTS CurrentUser { get; set; }
        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
        public TimeSheet TimeSheet { get; set; } // Add TimeSheet property

        public List<EmployeeWithRole> employeeWithRoles { get; set; }
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
}
