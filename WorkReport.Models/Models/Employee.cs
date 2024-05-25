using System.ComponentModel.DataAnnotations;

namespace Trac_WorkReport.Models
{
    public class Employee
    {
        public int Id { get; set; }  // Assuming this is the primary key
        public string Name { get; set; }  // Assuming this is the name of the employee

        public string EmployeePhone { get; set; }  // Changed type to string

        public string Email { get; set; }  // Changed property name to camel case

        public Designation Designation { get; set; }
    }
}
