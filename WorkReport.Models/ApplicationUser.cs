
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;

namespace WorkReport.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
     
    }
}
