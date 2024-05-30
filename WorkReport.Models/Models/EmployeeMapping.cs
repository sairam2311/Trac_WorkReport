using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReport.Models.Models
{
    public class EmployeeMapping
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string ReviewingOfficerId { get; set; }
        public string ReportingOfficerId { get; set; }
        public string ProjectId { get; set; }
    }
}
