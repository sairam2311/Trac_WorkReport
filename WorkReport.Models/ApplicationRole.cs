﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReport.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string RoleName { get; set; }
    }
}
