using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReport.Models.Models
{
    public class TimeSheet
    {
        //[Key]
        //public Guid TSid { get; set; }
        //public string EmployeeGUID { get; set; }
        //public string Work { get; set; } = string.Empty;
        //public string AssignedBy { get; set; }



        //public string RemarksBbyReOf { get; set; } = string.Empty;

        //public string RemarksbyRpOf { get; set; } = string.Empty;
        //public DateTime ReportDate { get; set; }
        //public DateTime CurrentDate { get; set; }
        //= DateTime.Now;

       
            [Key]
            public Guid TSid { get; set; }

            [ValidateNever]
            public string EmployeeGUID { get; set; }

            [Required(ErrorMessage = "Work details are required")]
            public string Work { get; set; }

        //[Required(ErrorMessage = "AssignedBy is required")]
            [ValidateNever]
            public string AssignedBy { get; set; }

        [AllowNull]
            public string RemarksBbyReOf { get; set; } = string.Empty;

        [AllowNull]
            public string RemarksbyRpOf { get; set; } = string.Empty;

            [Required(ErrorMessage = "Report date is required")]
            public DateTime ReportDate { get; set; }

            public DateTime CurrentDate { get; set; } = DateTime.UtcNow.Date;
       


    }
}
