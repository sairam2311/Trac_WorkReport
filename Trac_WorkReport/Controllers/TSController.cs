﻿//////using Microsoft.AspNetCore.Mvc;
//////using Microsoft.AspNetCore.Identity;
//////using WorkReport.Models;
//////using WorkRport.DataAccess.Repository.IRepository;
//////using System.Collections.Generic;
//////using System.Linq;
//////using System.Threading.Tasks;
//////using Trac_WorkReport.Models;
//////using WorkReport.Models.Models;

//////namespace Trac_WorkReport.Controllers
//////{
//////    public class TSController : Controller
//////    {
//////        private readonly UserManager<ApplicationUser> _userManager;
//////        private readonly RoleManager<ApplicationRole> _roleManager;
//////        private readonly IEmployeeMapRepository _employeeMapRep;

//////        public TSController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmployeeMapRepository employeeMapRep)
//////        {
//////            _userManager = userManager;
//////            _roleManager = roleManager;
//////            _employeeMapRep = employeeMapRep;
//////        }

//////        public async Task<IActionResult> Index()
//////        {
//////            var currentUser = await _userManager.GetUserAsync(User);
//////            if (currentUser == null)
//////            {
//////                return NotFound();
//////            }

//////            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
//////            var allUsers = _userManager.Users.ToList();
//////            var allUsersWithRoles = new List<EditUserViewModelTS>();
//////            var alluserswithRRR = new List<EditUserViewModelTS>();

//////            foreach (var user in allUsers)
//////            {
//////                var roles = await _userManager.GetRolesAsync(user);
//////                allUsersWithRoles.Add(new EditUserViewModelTS
//////                {
//////                    Id = user.Id,
//////                    Email = user.Email,
//////                    EmployeeID = user.EmployeeID,
//////                    EmployeeName = user.EmployeeName,
//////                    Roles = roles.Select(r => new RoleViewModelTS
//////                    {
//////                        RoleName = r,
//////                        IsSelected = true
//////                    }).ToList()

//////                });
//////            }

//////            // Fetch reporting officer names using EmployeeMapRepository
//////            //var reportingOfficerNames = _employeeMapRep.GetReportingOfficerName(currentUser.Id).ToList();

//////            // Fetch the reviewing officer name for the current user
//////            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);
//////            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);

//////            // Assign reporting officer names to corresponding users
//////            //for (int i = 0; i < allUsersWithRoles.Count; i++)
//////            //{
//////            //    allUsersWithRoles[i].ReportingOfficerName = reportingOfficerNames[i];
//////            //}

//////            var model = new UserIndexViewModelTS
//////            {
//////                CurrentUser = new EditUserViewModelTS
//////                {
//////                    Id = currentUser.Id,
//////                    Email = currentUser.Email,
//////                    EmployeeID = currentUser.EmployeeID,
//////                    EmployeeName = currentUser.EmployeeName,
//////                    ReviewingofficerName=reviewingOfficerName,
//////                    ReportingOfficerName = reportingOfficerName,

//////                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
//////                    {
//////                        RoleName = r,
//////                        IsSelected = true
//////                    }).ToList()
//////                },
//////                AllUsersWithRoles = allUsersWithRoles
//////            };

//////            return View(model);
//////        }


//////        public async Task<IActionResult> Create(TimeSheet timeSheet)
//////        {
//////            var currentUser = await _userManager.GetUserAsync(User);
//////            if (currentUser == null)
//////            {
//////                return NotFound();
//////            }

//////            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
//////            var allUsers = _userManager.Users.ToList();
//////            var allUsersWithRoles = new List<EditUserViewModelTS>();
//////            var alluserswithRRR = new List<EditUserViewModelTS>();

//////            foreach (var user in allUsers)
//////            {
//////                var roles = await _userManager.GetRolesAsync(user);
//////                allUsersWithRoles.Add(new EditUserViewModelTS
//////                {
//////                    Id = user.Id,
//////                    Email = user.Email,
//////                    EmployeeID = user.EmployeeID,
//////                    EmployeeName = user.EmployeeName,
//////                    Roles = roles.Select(r => new RoleViewModelTS
//////                    {
//////                        RoleName = r,
//////                        IsSelected = true
//////                    }).ToList()

//////                });
//////            }

//////            // Fetch reporting officer names using EmployeeMapRepository
//////            //var reportingOfficerNames = _employeeMapRep.GetReportingOfficerName(currentUser.Id).ToList();

//////            // Fetch the reviewing officer name for the current user
//////            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);
//////            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);

//////            // Assign reporting officer names to corresponding users
//////            //for (int i = 0; i < allUsersWithRoles.Count; i++)
//////            //{
//////            //    allUsersWithRoles[i].ReportingOfficerName = reportingOfficerNames[i];
//////            //}

//////            var model = new UserIndexViewModelTS
//////            {
//////                CurrentUser = new EditUserViewModelTS
//////                {
//////                    Id = currentUser.Id,
//////                    Email = currentUser.Email,
//////                    EmployeeID = currentUser.EmployeeID,
//////                    EmployeeName = currentUser.EmployeeName,
//////                    ReviewingofficerName = reviewingOfficerName,
//////                    ReportingOfficerName = reportingOfficerName,

//////                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
//////                    {
//////                        RoleName = r,
//////                        IsSelected = true
//////                    }).ToList()
//////                },
//////                AllUsersWithRoles = allUsersWithRoles
//////            };

//////            return View(model);
//////        }

//////        [HttpPost]
//////        public IActionResult Create(TimeSheet TimeS)
//////        {
//////            // _ProjectsRepo.Add(obj);
//////            // _ProjectsRepo.save();
//////            return RedirectToAction("Index");
//////        }
//////    }



//////    public class UserIndexViewModelTS
//////    {
//////        public EditUserViewModelTS CurrentUser { get; set; }
//////        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
//////    }

//////    public class EditUserViewModelTS
//////    {
//////        public string Id { get; set; }
//////        public string Email { get; set; }
//////        public string EmployeeName { get; set; }
//////        public string EmployeeID { get; set; }
//////        public List<RoleViewModelTS> Roles { get; set; }
//////        public string ReportingOfficerName { get; set; }

//////        public string ReviewingofficerName { get; set; }
//////    }

//////    public class RoleViewModelTS
//////    {
//////        public string RoleName { get; set; }
//////        public bool IsSelected { get; set; }
//////    }
//////}

////using Microsoft.AspNetCore.Mvc;
////using Microsoft.AspNetCore.Identity;
////using WorkReport.Models;
////using WorkRport.DataAccess.Repository.IRepository;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Trac_WorkReport.Models;
////using WorkReport.Models.Models;

////namespace Trac_WorkReport.Controllers
////{
////    public class TSController : Controller
////    {
////        private readonly UserManager<ApplicationUser> _userManager;
////        private readonly RoleManager<ApplicationRole> _roleManager;
////        private readonly IEmployeeMapRepository _employeeMapRep;

////        public TSController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmployeeMapRepository employeeMapRep)
////        {
////            _userManager = userManager;
////            _roleManager = roleManager;
////            _employeeMapRep = employeeMapRep;
////        }

////        public async Task<IActionResult> Index()
////        {
////            var currentUser = await _userManager.GetUserAsync(User);
////            if (currentUser == null)
////            {
////                return NotFound();
////            }

////            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
////            var allUsers = _userManager.Users.ToList();
////            var allUsersWithRoles = new List<EditUserViewModelTS>();

////            foreach (var user in allUsers)
////            {
////                var roles = await _userManager.GetRolesAsync(user);
////                allUsersWithRoles.Add(new EditUserViewModelTS
////                {
////                    Id = user.Id,
////                    Email = user.Email,
////                    EmployeeID = user.EmployeeID,
////                    EmployeeName = user.EmployeeName,
////                    Roles = roles.Select(r => new RoleViewModelTS
////                    {
////                        RoleName = r,
////                        IsSelected = true
////                    }).ToList()
////                });
////            }

////            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
////            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

////            var model = new UserIndexViewModelTS
////            {
////                CurrentUser = new EditUserViewModelTS
////                {
////                    Id = currentUser.Id,
////                    Email = currentUser.Email,
////                    EmployeeID = currentUser.EmployeeID,
////                    EmployeeName = currentUser.EmployeeName,
////                    ReportingOfficerName = reportingOfficerName,
////                    ReviewingofficerName = reviewingOfficerName,
////                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
////                    {
////                        RoleName = r,
////                        IsSelected = true
////                    }).ToList()
////                },
////                AllUsersWithRoles = allUsersWithRoles
////            };

////            return View(model);
////        }

////        public async Task<IActionResult> Create()
////        {
////            var currentUser = await _userManager.GetUserAsync(User);
////            if (currentUser == null)
////            {
////                return NotFound();
////            }

////            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
////            var allUsers = _userManager.Users.ToList();
////            var allUsersWithRoles = new List<EditUserViewModelTS>();

////            foreach (var user in allUsers)
////            {
////                var roles = await _userManager.GetRolesAsync(user);
////                allUsersWithRoles.Add(new EditUserViewModelTS
////                {
////                    Id = user.Id,
////                    Email = user.Email,
////                    EmployeeID = user.EmployeeID,
////                    EmployeeName = user.EmployeeName,
////                    Roles = roles.Select(r => new RoleViewModelTS
////                    {
////                        RoleName = r,
////                        IsSelected = true
////                    }).ToList()
////                });
////            }

////            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
////            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

////            var model = new UserIndexViewModelTS
////            {
////                CurrentUser = new EditUserViewModelTS
////                {
////                    Id = currentUser.Id,
////                    Email = currentUser.Email,
////                    EmployeeID = currentUser.EmployeeID,
////                    EmployeeName = currentUser.EmployeeName,
////                    ReportingOfficerName = reportingOfficerName,
////                    ReviewingofficerName = reviewingOfficerName,
////                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
////                    {
////                        RoleName = r,
////                        IsSelected = true
////                    }).ToList()
////                },
////                AllUsersWithRoles = allUsersWithRoles
////            };

////            return View(model);
////        }

////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public async Task<IActionResult> Create(TimeSheet timeSheet)
////        {
////            if (ModelState.IsValid)
////            {
////                // Implement your repository logic here to save the timesheet
////                // _timeSheetRepository.Add(timeSheet);
////                // await _timeSheetRepository.SaveAsync();

////                return RedirectToAction(nameof(Index));
////            }

////            var currentUser = await _userManager.GetUserAsync(User);
////            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
////            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
////            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

////            var model = new UserIndexViewModelTS
////            {
////                CurrentUser = new EditUserViewModelTS
////                {
////                    Id = currentUser.Id,
////                    Email = currentUser.Email,
////                    EmployeeID = currentUser.EmployeeID,
////                    EmployeeName = currentUser.EmployeeName,
////                    ReportingOfficerName = reportingOfficerName,
////                    ReviewingofficerName = reviewingOfficerName,
////                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
////                    {
////                        RoleName = r,
////                        IsSelected = true
////                    }).ToList()
////                }
////            };

////            return View(model);
////        }
////    }

////    public class UserIndexViewModelTS
////    {
////        public EditUserViewModelTS CurrentUser { get; set; }
////        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
////    }

////    public class EditUserViewModelTS
////    {
////        public string Id { get; set; }
////        public string Email { get; set; }
////        public string EmployeeName { get; set; }
////        public string EmployeeID { get; set; }
////        public List<RoleViewModelTS> Roles { get; set; }
////        public string ReportingOfficerName { get; set; }
////        public string ReviewingofficerName { get; set; }
////    }

////    public class RoleViewModelTS
////    {
////        public string RoleName { get; set; }
////        public bool IsSelected { get; set; }
////    }
////}

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using WorkReport.Models;
//using WorkRport.DataAccess.Repository.IRepository;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Trac_WorkReport.Models;
//using WorkReport.Models.Models;

//namespace Trac_WorkReport.Controllers
//{
//    public class TSController : Controller
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly RoleManager<ApplicationRole> _roleManager;
//        private readonly IEmployeeMapRepository _employeeMapRep;

//        public TSController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmployeeMapRepository employeeMapRep)
//        {
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _employeeMapRep = employeeMapRep;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var currentUser = await _userManager.GetUserAsync(User);
//            if (currentUser == null)
//            {
//                return NotFound();
//            }

//            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
//            var allUsers = _userManager.Users.ToList();
//            var allUsersWithRoles = new List<EditUserViewModelTS>();

//            foreach (var user in allUsers)
//            {
//                var roles = await _userManager.GetRolesAsync(user);
//                allUsersWithRoles.Add(new EditUserViewModelTS
//                {
//                    Id = user.Id,
//                    Email = user.Email,
//                    EmployeeID = user.EmployeeID,
//                    EmployeeName = user.EmployeeName,
//                    Roles = roles.Select(r => new RoleViewModelTS
//                    {
//                        RoleName = r,
//                        IsSelected = true
//                    }).ToList()
//                });
//            }

//            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
//            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

//            var model = new UserIndexViewModelTS
//            {
//                CurrentUser = new EditUserViewModelTS
//                {
//                    Id = currentUser.Id,
//                    Email = currentUser.Email,
//                    EmployeeID = currentUser.EmployeeID,
//                    EmployeeName = currentUser.EmployeeName,
//                    ReportingOfficerName = reportingOfficerName,
//                    ReviewingofficerName = reviewingOfficerName,
//                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
//                    {
//                        RoleName = r,
//                        IsSelected = true
//                    }).ToList()
//                },
//                AllUsersWithRoles = allUsersWithRoles
//            };

//            return View(model);
//        }

//        public async Task<IActionResult> Create()
//        {
//            var currentUser = await _userManager.GetUserAsync(User);
//            if (currentUser == null)
//            {
//                return NotFound();
//            }

//            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
//            var allUsers = _userManager.Users.ToList();
//            var allUsersWithRoles = new List<EditUserViewModelTS>();

//            foreach (var user in allUsers)
//            {
//                var roles = await _userManager.GetRolesAsync(user);
//                allUsersWithRoles.Add(new EditUserViewModelTS
//                {
//                    Id = user.Id,
//                    Email = user.Email,
//                    EmployeeID = user.EmployeeID,
//                    EmployeeName = user.EmployeeName,
//                    Roles = roles.Select(r => new RoleViewModelTS
//                    {
//                        RoleName = r,
//                        IsSelected = true
//                    }).ToList()
//                });
//            }

//            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
//            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

//            var model = new UserIndexViewModelTS
//            {
//                CurrentUser = new EditUserViewModelTS
//                {
//                    Id = currentUser.Id,
//                    Email = currentUser.Email,
//                    EmployeeID = currentUser.EmployeeID,
//                    EmployeeName = currentUser.EmployeeName,
//                    ReportingOfficerName = reportingOfficerName,
//                    ReviewingofficerName = reviewingOfficerName,
//                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
//                    {
//                        RoleName = r,
//                        IsSelected = true
//                    }).ToList()
//                },
//                AllUsersWithRoles = allUsersWithRoles,
//                TimeSheet = new TimeSheet() // Include an empty TimeSheet for form binding
//            };

//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(UserIndexViewModelTS model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Save the TimeSheet using repository
//                var timeSheet = model.TimeSheet;
//                // _timeSheetRepository.Add(timeSheet);
//                // await _timeSheetRepository.SaveAsync();

//                return RedirectToAction(nameof(Index));
//            }

//            // Re-populate the model if ModelState is invalid
//            var currentUser = await _userManager.GetUserAsync(User);
//            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
//            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
//            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

//            model.CurrentUser = new EditUserViewModelTS
//            {
//                Id = currentUser.Id,
//                Email = currentUser.Email,
//                EmployeeID = currentUser.EmployeeID,
//                EmployeeName = currentUser.EmployeeName,
//                ReportingOfficerName = reportingOfficerName,
//                ReviewingofficerName = reviewingOfficerName,
//                Roles = currentUserRoles.Select(r => new RoleViewModelTS
//                {
//                    RoleName = r,
//                    IsSelected = true
//                }).ToList()
//            };

//            return View(model);
//        }
//    }

//    public class UserIndexViewModelTS
//    {
//        public EditUserViewModelTS CurrentUser { get; set; }
//        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
//        public TimeSheet TimeSheet { get; set; } // Add TimeSheet property
//    }

//    public class EditUserViewModelTS
//    {
//        public string Id { get; set; }
//        public string Email { get; set; }
//        public string EmployeeName { get; set; }
//        public string EmployeeID { get; set; }
//        public List<RoleViewModelTS> Roles { get; set; }
//        public string ReportingOfficerName { get; set; }
//        public string ReviewingofficerName { get; set; }
//    }

//    public class RoleViewModelTS
//    {
//        public string RoleName { get; set; }
//        public bool IsSelected { get; set; }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WorkReport.Models;
using WorkRport.DataAccess.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.Models.Models;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Borders;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Font;
using iText.Layout.Element;



namespace Trac_WorkReport.Controllers
{
    public class TSController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmployeeMapRepository _employeeMapRep;
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TSController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmployeeMapRepository employeeMapRep, ITimeSheetRepository timeSheetRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _employeeMapRep = employeeMapRep;
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
            var allUsers = _userManager.Users.ToList();
            var allUsersWithRoles = new List<EditUserViewModelTS>();
            var allRREmps = new List<EmployeeWithRole>();

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                allUsersWithRoles.Add(new EditUserViewModelTS
                {
                    Id = user.Id,
                    Email = user.Email,
                    EmployeeID = user.EmployeeID,
                    EmployeeName = user.EmployeeName,
                    Roles = roles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                });
            }

            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);
            var RRemployees = _employeeMapRep.GeEmployeesbyrevieworRep(currentUser.Id);

            // Get the timesheets for the current user
            var timeSheets = _timeSheetRepository.GetTimeSheetsByEmployeeId(currentUser.Id);

            //var reportbyid = _timeSheetRepository.Get(TimeSheet as TimeSheet);

            //foreach(var emp in RRemployees)
            //{
            //    allRREmps.Add(new EmployeeWithRole
            //    {
            //        Id = emp.Id,
            //        employeeID = emp.employeeID,
            //        EmployeeName = emp.EmployeeName,
            //        RoleName = emp.RoleName
            //    });
            //}

            var model = new UserIndexViewModelTS
            {
                CurrentUser = new EditUserViewModelTS
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    EmployeeID = currentUser.EmployeeID,
                    EmployeeName = currentUser.EmployeeName,
                    ReportingOfficerName = reportingOfficerName,
                    ReviewingofficerName = reviewingOfficerName,
                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                },
                AllUsersWithRoles = allUsersWithRoles,
                employeeWithRoles = RRemployees,
                TimeSheets = timeSheets // Add timesheets to the model
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
            var allUsers = _userManager.Users.ToList();
            var allUsersWithRoles = new List<EditUserViewModelTS>();

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                allUsersWithRoles.Add(new EditUserViewModelTS
                {
                    Id = user.Id,
                    Email = user.Email,
                    EmployeeID = user.EmployeeID,
                    EmployeeName = user.EmployeeName,
                    Roles = roles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                });
            }

            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

            var model = new UserIndexViewModelTS
            {
                CurrentUser = new EditUserViewModelTS
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    EmployeeID = currentUser.EmployeeID,
                    EmployeeName = currentUser.EmployeeName,
                    ReportingOfficerName = reportingOfficerName,
                    ReviewingofficerName = reviewingOfficerName,
                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                },
                AllUsersWithRoles = allUsersWithRoles,
                TimeSheet = new TimeSheet() // Initialize TimeSheet object
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserIndexViewModelTS model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                // var timeSheet = model.TimeSheet;

                var timeSheet = new TimeSheet
                {
                    EmployeeGUID = currentUser.Id,
                    Work = model.TimeSheet.Work,
                    WorkTitle = model.TimeSheet.WorkTitle,
                    AssignedBy = "Self Reporting",
                    //CurrentDate = model.TimeSheet.CurrentDate.Date,
                    RemarksByReOf = model.TimeSheet.RemarksByReOf,
                    RemarksByRpOf = model.TimeSheet.RemarksByRpOf,
                    // Adjust for UTC +5:30
                    ReportDate = DateTime.SpecifyKind(model.TimeSheet.ReportDate, DateTimeKind.Utc)
                    //.AddHours(5).AddMinutes(30)

                    //ReportDate = DateTime.SpecifyKind(model.TimeSheet.ReportDate, DateTimeKind.Utc), // Ensure ReportDate is UTC
                    //ReportDate = model.TimeSheet.ReportDate.Date


                };
              

                //var timeSheet = new TimeSheet
                //{
                //    EmployeeGUID = model.TimeSheet.EmployeeGUID,
                //    Work = model.TimeSheet.Work,
                //    AssignedBy = model.TimeSheet.AssignedBy,
                //    ReportDate = model.TimeSheet.ReportDate,
                //    // Populate other properties as needed
                //};
                   _timeSheetRepository.Add(timeSheet);
                  _timeSheetRepository.save();
                return RedirectToAction(nameof(Index));
            }

            
            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

            model.CurrentUser = new EditUserViewModelTS
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                EmployeeID = currentUser.EmployeeID,
                EmployeeName = currentUser.EmployeeName,
                ReportingOfficerName = reportingOfficerName,
                ReviewingofficerName = reviewingOfficerName,
                Roles = currentUserRoles.Select(r => new RoleViewModelTS
                {
                    RoleName = r,
                    IsSelected = true
                }).ToList()
            };

            return View(model);
        }


        public async Task<IActionResult> AssignWork()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            
            if (currentUser == null)
            {
                return NotFound();
            }

            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
            var allUsers = _userManager.Users.ToList();
            var allUsersWithRoles = new List<EditUserViewModelTS>();

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                allUsersWithRoles.Add(new EditUserViewModelTS
                {
                    Id = user.Id,
                    Email = user.Email,
                    EmployeeID = user.EmployeeID,
                    EmployeeName = user.EmployeeName,
                    Roles = roles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                });
            }

            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

            var model = new UserIndexViewModelTS
            {
                CurrentUser = new EditUserViewModelTS
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    EmployeeID = currentUser.EmployeeID,
                    EmployeeName = currentUser.EmployeeName,
                    ReportingOfficerName = reportingOfficerName,
                    ReviewingofficerName = reviewingOfficerName,
                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                },
                AllUsersWithRoles = allUsersWithRoles,
                TimeSheet = new TimeSheet() // Initialize TimeSheet object
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AssignWork(string Id, UserIndexViewModelTS model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                // var timeSheet = model.TimeSheet;

                var timeSheet = new TimeSheet
                {
                    EmployeeGUID = Id,
                    Work = model.TimeSheet.Work,
                    AssignedBy = currentUser.Id,
                    WorkTitle = model.TimeSheet.WorkTitle,
                    //CurrentDate = model.TimeSheet.CurrentDate.Date,
                    RemarksByReOf = model.TimeSheet.RemarksByReOf,
                    RemarksByRpOf = model.TimeSheet.RemarksByRpOf,
                    // Adjust for UTC +5:30
                    ReportDate = DateTime.SpecifyKind(model.TimeSheet.ReportDate, DateTimeKind.Utc)
                    //.AddHours(5).AddMinutes(30)

                    //ReportDate = DateTime.SpecifyKind(model.TimeSheet.ReportDate, DateTimeKind.Utc), // Ensure ReportDate is UTC
                    //ReportDate = model.TimeSheet.ReportDate.Date


                };
                _timeSheetRepository.Add(timeSheet);
                _timeSheetRepository.save();
                return RedirectToAction(nameof(Index));
            }


            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);

            model.CurrentUser = new EditUserViewModelTS
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                EmployeeID = currentUser.EmployeeID,
                EmployeeName = currentUser.EmployeeName,
                ReportingOfficerName = reportingOfficerName,
                ReviewingofficerName = reviewingOfficerName,
                Roles = currentUserRoles.Select(r => new RoleViewModelTS
                {
                    RoleName = r,
                    IsSelected = true
                }).ToList()
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult>  ViewReport(string id)
        {
            var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(id);

            
            var viewModel = new UserIndexViewModelTS
            {
                reportViewModels = new List<ViewReportViewModel>
            {
                new ViewReportViewModel
                {
                    UserId = id,
                    TimeSheets = reports
                }

            }

               
            };

            //model.reportViewModels.First().TimeSheets = reports;
            var timeSheetViewModels = new List<TimeSheet>();

            foreach (var report in reports)
            {
                var assignedByName = report.AssignedBy;

                if (report.AssignedBy != "Self Reporting")
                {
                    var user = await _userManager.FindByIdAsync(report.AssignedBy);

                    assignedByName = user?.EmployeeName ?? "Unknown"; // Ensure there's a fallback if user is not found

                }
                // Check if AssignedBy matches Reporting Officer or Reviewing Officer

                //else
                //{
                //    assignedByName
                //}

                timeSheetViewModels.Add(new TimeSheet
                {
                    TSid = report.TSid,
                    Work = report.Work,
                    AssignedBy = assignedByName, // Still store the ID for potential use
                    //AssignedByName = assignedByName, // This is now the name or "Self Reporting"
                    ReportDate = report.ReportDate,
                    CurrentDate = report.CurrentDate,
                    RemarksByReOf = report.RemarksByReOf,
                    RemarksByRpOf = report.RemarksByRpOf
                });
            }

            viewModel.reportViewModels.First().TimeSheets = timeSheetViewModels;

            //return View(model);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ViewReport(UserIndexViewModelTS model)
        {
            //var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(model.reportViewModels.First().UserId);

            //if (model.reportViewModels.First().StartDate.HasValue && model.reportViewModels.First().EndDate.HasValue)
            //{
            //    reports = reports
            //        .Where(t => t.ReportDate >= model.reportViewModels.First().StartDate && t.ReportDate <= model.reportViewModels.First().EndDate)
            //        .ToList();
            //}

           

            var userId = model.reportViewModels.First().UserId;
            var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(userId);

            if (model.reportViewModels.First().StartDate.HasValue && model.reportViewModels.First().EndDate.HasValue)
            {
                reports = reports
                    .Where(t => t.ReportDate >= model.reportViewModels.First().StartDate && t.ReportDate <= model.reportViewModels.First().EndDate)
                    .ToList();
            }

           


            //model.reportViewModels.First().TimeSheets = reports;
            var timeSheetViewModels = new List<TimeSheet>();

            foreach (var report in reports)
            {
                var assignedByName = report.AssignedBy;

                if (report.AssignedBy != "Self Reporting")
                {
                    var user = await _userManager.FindByIdAsync(report.AssignedBy);
                  
                    assignedByName = user?.EmployeeName ?? "Unknown"; // Ensure there's a fallback if user is not found

                }
                // Check if AssignedBy matches Reporting Officer or Reviewing Officer
             
                //else
                //{
                //    assignedByName
                //}

                timeSheetViewModels.Add(new TimeSheet
                {
                    TSid = report.TSid,
                    Work = report.Work,
                    AssignedBy = assignedByName, // Still store the ID for potential use
                    //AssignedByName = assignedByName, // This is now the name or "Self Reporting"
                    ReportDate = report.ReportDate,
                    CurrentDate = report.CurrentDate,
                    RemarksByReOf = report.RemarksByReOf,
                    RemarksByRpOf = report.RemarksByRpOf
                });
            }

            model.reportViewModels.First().TimeSheets = timeSheetViewModels;

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateTS(Guid ID)
        {
            var timesheet = _timeSheetRepository.GetTimeSheetsById(ID);
            if (timesheet == null)
            {
                return NotFound();
            }

            var viewModel = new UserIndexViewModelTS
            {
                reportViewModels = new List<ViewReportViewModel>
        {
            new ViewReportViewModel
            {
                TimeSheets = timesheet
            }
        }
            };

            return View(viewModel);
        }

    [HttpGet]
        public IActionResult UpdateTSdummy(Guid ID)
        {
            var timesheet = _timeSheetRepository.GetTimeSheetsById(ID);
            if (timesheet == null)
            {
                return NotFound();
            }

            // Map the timesheet entity to the view model
           

            //model.reportViewModels.First().TimeSheets = reports;
            var timeSheetViewModels = new List<TimeSheet>();

            foreach (var report in timesheet)
            {
                var assignedByName = report.AssignedBy;

               
                // Check if AssignedBy matches Reporting Officer or Reviewing Officer

                //else
                //{
                //    assignedByName
                //}

                timeSheetViewModels.Add(new TimeSheet
                {
                    TSid = report.TSid,
                    Work = report.Work,
                    AssignedBy = assignedByName, // Still store the ID for potential use
                    //AssignedByName = assignedByName, // This is now the name or "Self Reporting"
                    ReportDate = report.ReportDate,
                    CurrentDate = report.CurrentDate,
                    RemarksByReOf = report.RemarksByReOf,
                    RemarksByRpOf = report.RemarksByRpOf
                });
            }

            // viewModel.reportViewModels.First().TimeSheets = timeSheetViewModels;

            //return View(model);

            var viewModel = new UserIndexViewModelTS
            {
                reportViewModels = new List<ViewReportViewModel>
            {
                new ViewReportViewModel
                {

                    TimeSheets = timeSheetViewModels
                }

            }


            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateTS(string ID, UserIndexViewModelTS model)
        {
            return View(model);
        }

        private string GenerateCsv(IEnumerable<TimeSheet> timeSheets)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Work,Assigned By,Report Date,Uploaded Date,Remarks by Reviewing Officer,Remarks by Reporting Officer");

            foreach (var timeSheet in timeSheets)
            {
                csv.AppendLine($"{timeSheet.Work},{timeSheet.AssignedBy},{timeSheet.ReportDate:dd-MM-yyyy},{timeSheet.CurrentDate:dd-MM-yyyy},{timeSheet.RemarksByReOf},{timeSheet.RemarksByRpOf}");
            }

            return csv.ToString();
        }
        

        [HttpPost]
        public IActionResult DownloadReport(string userId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(userId);

                if (startDate.HasValue && endDate.HasValue)
                {
                    reports = reports
                        .Where(t => t.ReportDate >= startDate && t.ReportDate <= endDate)
                        .ToList();
                }

                var user = _userManager.FindByIdAsync(userId).Result;

                // Retrieve the reporting and reviewing officer names
                var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(user.Id);
                var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(user.Id);

                // Map ApplicationUser to EditUserViewModelTS and include officer names
                var editUserViewModel = new EditUserViewModelTS
                {
                    Id = user.Id,
                    Email = user.Email,
                    EmployeeName = user.EmployeeName,
                    EmployeeID = user.EmployeeID,
                    ReportingOfficerName = reportingOfficerName,
                    ReviewingofficerName = reviewingOfficerName,
                   
                };

                var pdfBytes = GeneratePdf(editUserViewModel, reports);

                var output = new FileContentResult(pdfBytes, "application/pdf")
                {
                    FileDownloadName = $"Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.pdf"
                };
                return output;
            }
            catch (Exception ex)
            {
                // Log the error (you could use a logging framework here)
                // For now, return a simple error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        public byte[] GeneratePdf(EditUserViewModelTS currentUser, IEnumerable<TimeSheet> timeSheets)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf, PageSize.A4.Rotate());


                var logoPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.jpeg");
                // Add watermark to each page
               

                SetPageMargins(document); // Set page margins
                AddHeader(document);
                //AddTitle(document, "Time Sheet Report");
                AddUserDetails(document, currentUser);
                AddTimeSheetDetails(document, timeSheets);
                AddSignatures(document, currentUser.ReportingOfficerName, currentUser.ReviewingofficerName);

                //  AddWatermark(pdf, logoPath);


              //  AddWatermarkImage(pdf, logoPath);

                float op = 0.5F;

               // AddWatermarkText(pdf, "TGRAC", op);

                document.Close();

                return memoryStream.ToArray();
            }
        }

        private void AddWatermark_old(PdfDocument pdf, string imagePath)
        {
            ImageData imageData = ImageDataFactory.Create(imagePath);
            float width = pdf.GetDefaultPageSize().GetWidth();
            float height = pdf.GetDefaultPageSize().GetHeight();
            float x = (width - imageData.GetWidth()) / 2;
            float y = (height - imageData.GetHeight()) / 2;

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                PdfPage page = pdf.GetPage(i);
                PdfCanvas canvas = new PdfCanvas(page);
                canvas.SaveState();
                canvas.SetExtGState(new PdfExtGState().SetFillOpacity(0.2f));

                // Scale and position the image to cover the full page
                // canvas.AddImageFittedIntoRectangle(imageData, new iText.Kernel.Geom.Rectangle(0, 0, width, height), true);

               // canvas.AddImage(imageData, 50, 50, width, false);

                //canvas.RestoreState();



                 canvas.AddImageWithTransformationMatrix(imageData, imageData.GetWidth(), 50, 50, imageData.GetHeight(), x, y, true);
                //canvas.RestoreState();
            }
        }

        private void AddWatermarkImage_two(PdfDocument pdf, string imagePath)
        {
            try
            {
                // Load the image to be used as a watermark
                ImageData imageData = ImageDataFactory.Create(imagePath);

                float pageWidth = pdf.GetDefaultPageSize().GetWidth();
                float pageHeight = pdf.GetDefaultPageSize().GetHeight();

                ImageData imageData1 = ImageDataFactory.Create(imagePath);
                float width1 = pdf.GetDefaultPageSize().GetWidth();
                float height1 = pdf.GetDefaultPageSize().GetHeight();
                float x1 = (width1 - imageData1.GetWidth()) / 2;
                float y1 = (height1 - imageData1.GetHeight()) / 2;

                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    PdfPage page = pdf.GetPage(i);

                    if (page == null || page.GetPdfObject() == null)
                    {
                        Console.WriteLine($"Skipping invalid page: {i}");
                        continue;
                    }

                    int rotation = 0;

                    try
                    {
                        rotation = page.GetRotation();
                        //continue;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error getting rotation for page {i}: {ex.Message}");
                        continue;
                    }

                    float effectiveWidth = pageWidth;
                    float effectiveHeight = pageHeight;

                    if (rotation == 90 || rotation == 270)
                    {
                        effectiveWidth = pageHeight;
                        effectiveHeight = pageWidth;
                    }

                    PdfCanvas canvas = new PdfCanvas(page);
                    canvas.SaveState();

                    PdfExtGState gState = new PdfExtGState().SetFillOpacity(0.1f);
                    canvas.SetExtGState(gState);

                    try
                    {
                        float aspectRatio = imageData.GetWidth() / imageData.GetHeight();
                        float imageWidth = effectiveWidth;
                        float imageHeight = effectiveWidth / aspectRatio;

                        if (imageHeight > effectiveHeight)
                        {
                            imageHeight = effectiveHeight;
                            imageWidth = effectiveHeight * aspectRatio;
                        }

                        float x = (effectiveWidth - imageWidth) / 2;
                        float y = (effectiveHeight - imageHeight) / 2;

                         canvas.AddImageWithTransformationMatrix(imageData, imageWidth, 0, 0, imageHeight, x, y, false);

                       


                       // canvas.AddImage(imageData1, width1, 0, 0, imageHeight, x1, y1, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding watermark image on page {i}: {ex.Message}");
                    }

                    canvas.RestoreState();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddWatermark method: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        private void AddWatermarkImage_three(PdfDocument pdf, string imagePath)
        {
            try
            {
                // Load the image to be used as a watermark
                ImageData imageData = ImageDataFactory.Create(imagePath);

                // Get the total number of pages
                int numberOfPages = pdf.GetNumberOfPages();
                Console.WriteLine($"Total number of pages: {numberOfPages}");

                for (int i = 1; i <= numberOfPages; i++)
                {
                    try
                    {
                        PdfPage page = pdf.GetPage(i);

                        if (page == null)
                        {
                            Console.WriteLine($"Page {i} is null.");
                            continue;
                        }

                        if (page.GetPdfObject() == null)
                        {
                            Console.WriteLine($"PDF object for page {i} is null.");
                            continue;
                        }

                        // Safely check and log page size and rotation
                        Rectangle pageSize = page.GetPageSize();
                        if (pageSize == null)
                        {
                            Console.WriteLine($"Page size is null for page: {i}");
                            continue;
                        }

                        float pageWidth = pageSize.GetWidth();
                        float pageHeight = pageSize.GetHeight();

                        int rotation = 0;
                        try
                        {
                            rotation = page.GetRotation();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error getting rotation for page {i}: {ex.Message}");
                            // Setting a default rotation if not available
                            rotation = 0;
                        }

                        float effectiveWidth = pageWidth;
                        float effectiveHeight = pageHeight;

                        // Adjust dimensions if the page is rotated
                        if (rotation == 90 || rotation == 270)
                        {
                            effectiveWidth = pageHeight;
                            effectiveHeight = pageWidth;
                        }

                        PdfCanvas canvas = new PdfCanvas(page);
                        canvas.SaveState();

                        // Set the transparency for the watermark
                        PdfExtGState gState = new PdfExtGState().SetFillOpacity(0.1f);
                        canvas.SetExtGState(gState);

                        // Maintain the aspect ratio of the image
                        float aspectRatio = imageData.GetWidth() / imageData.GetHeight();
                        float imageWidth = effectiveWidth;
                        float imageHeight = effectiveWidth / aspectRatio;

                        if (imageHeight > effectiveHeight)
                        {
                            imageHeight = effectiveHeight;
                            imageWidth = effectiveHeight * aspectRatio;
                        }

                        // Calculate the position to center the image
                        float x = (effectiveWidth - imageWidth) / 2;
                        float y = (effectiveHeight - imageHeight) / 2;

                        // Add the image to the canvas
                        canvas.AddImageWithTransformationMatrix(imageData, imageWidth, 0, 0, imageHeight, x, y, false);

                        Console.WriteLine($"Watermark added to page {i}");

                        canvas.RestoreState();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing page {i}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddWatermarkImage method: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }



        private void AddWatermarkText_old(PdfDocument pdf, string watermarkText, float opacity)
        {
            try
            {
                float pageWidth = pdf.GetDefaultPageSize().GetWidth();
                float pageHeight = pdf.GetDefaultPageSize().GetHeight();

                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    PdfPage page = pdf.GetPage(i);

                    if (page == null || page.GetPdfObject() == null)
                    {
                        Console.WriteLine($"Skipping invalid page: {i}");
                        continue;
                    }

                    int rotation = 0;

                    try
                    {
                        rotation = page.GetRotation();
                       // continue;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error getting rotation for page {i}: {ex.Message}");
                        continue;
                    }

                    float effectiveWidth = pageWidth;
                    float effectiveHeight = pageHeight;

                    if (rotation == 90 || rotation == 270)
                    {
                        effectiveWidth = pageHeight;
                        effectiveHeight = pageWidth;
                    }

                    PdfCanvas canvas = new PdfCanvas(page);
                    canvas.SaveState();

                    // Create transparency group
                    //PdfExtGState gs = new PdfExtGState().SetFillOpacity(opacity);
                    // canvas.SetExtGState(gs);

                    // Define a font family
                    PdfFont font = PdfFontFactory.CreateFont("Helvetica");

                    float fontSize = 48;

                    // Calculate the width and height of the watermark text
                    float textWidth = font.GetWidth(watermarkText, fontSize);
                    float textHeight = font.GetFontProgram().GetFontMetrics().GetTypoAscender() * fontSize;

                    // Calculate the position to center the text horizontally and vertically
                    float x = (effectiveWidth - textWidth) / 2;
                    float y = (effectiveHeight - textHeight) / 2;

                    canvas.BeginText()
                        .SetFontAndSize(font, fontSize)
                        .SetTextMatrix(1, 0, 0, 1, textWidth, textHeight)
                        .SetColor(ColorConstants.BLACK, true)
                        .SetFillColor(ColorConstants.RED)// Adjust position to center
                        .ShowText(watermarkText)
                        .EndText();

                    canvas.RestoreState();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddWatermark method: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        private void AddWatermarkImage(PdfDocument pdf, string imagePath)
        {
            try
            {
                // Load the image to be used as a watermark
                ImageData imageData = ImageDataFactory.Create(imagePath);

                // Get the total number of pages in the document
                int numberOfPages = pdf.GetNumberOfPages();
                Console.WriteLine($"Total number of pages: {numberOfPages}");

                for (int i = 1; i <= numberOfPages; i++)
                {
                    try
                    {
                        PdfPage page = pdf.GetPage(i);

                        if (page == null)
                        {
                            Console.WriteLine($"Page {i} is null. Skipping.");
                            continue;
                        }

                        if (page.GetPdfObject() == null)
                        {
                            Console.WriteLine($"PDF object for page {i} is null. Skipping.");
                            continue;
                        }

                        // Get page dimensions and handle rotation
                        Rectangle pageSize = page.GetPageSize();
                        if (pageSize == null)
                        {
                            Console.WriteLine($"Page size is null for page {i}. Skipping.");
                            continue;
                        }

                        float pageWidth = pageSize.GetWidth();
                        float pageHeight = pageSize.GetHeight();

                        int rotation = 0;
                        try
                        {
                            rotation = page.GetRotation();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error getting rotation for page {i}: {ex.Message}");
                            rotation = 0; // Default rotation if not available
                        }

                        float effectiveWidth = pageWidth;
                        float effectiveHeight = pageHeight;

                        // Adjust dimensions if the page is rotated
                        if (rotation == 90 || rotation == 270)
                        {
                            effectiveWidth = pageHeight;
                            effectiveHeight = pageWidth;
                        }

                        PdfCanvas canvas = new PdfCanvas(page);
                        canvas.SaveState();

                        // Set the transparency for the watermark
                        PdfExtGState gState = new PdfExtGState().SetFillOpacity(0.1f);
                        canvas.SetExtGState(gState);

                        // Maintain the aspect ratio of the image
                        float aspectRatio = imageData.GetWidth() / imageData.GetHeight();
                        float imageWidth = effectiveWidth;
                        float imageHeight = effectiveWidth / aspectRatio;

                        if (imageHeight > effectiveHeight)
                        {
                            imageHeight = effectiveHeight;
                            imageWidth = effectiveHeight * aspectRatio;
                        }

                        // Calculate the position to center the image
                        float x = (effectiveWidth - imageWidth) / 2;
                        float y = (effectiveHeight - imageHeight) / 2;

                        // Add the image to the canvas
                        canvas.AddImageWithTransformationMatrix(imageData, imageWidth, 0, 0, imageHeight, x, y, false);

                        Console.WriteLine($"Watermark added to page {i}");

                        canvas.RestoreState();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing page {i}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddWatermarkImage method: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        private void AddWatermarkText(PdfDocument pdf, string watermarkText, float opacity)
        {
            int numberOfPages = pdf.GetNumberOfPages();
            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = pdf.GetPage(i);
                PdfCanvas canvas = new PdfCanvas(page);
                canvas.SaveState();

                PdfExtGState gState = new PdfExtGState().SetFillOpacity(opacity);
                canvas.SetExtGState(gState);

                // Set font and color for the watermark
                canvas.BeginText();
                //PdfCanvas pdfCanvas = canvas.SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD), 60);
                canvas.SetFontAndSize(PdfFontFactory.CreateFont("Helvetica-Bold"), 60);
                canvas.SetColor(ColorConstants.GRAY, true);





                // Rotate and position the watermark text
               // canvas.ShowTextAligned(watermarkText, 298, 421, pdf.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, 45);
                canvas.EndText();

                canvas.RestoreState();
            }
        }


        private void SetPageMargins(Document document)
        {
            // Set page margins (e.g., 36 points on all sides)
            document.SetMargins(36, 36, 36, 36);
        }



        private void AddHeader(Document document)
        {
            // Get the available width of the page
            var pageWidth = document.GetPdfDocument().GetDefaultPageSize().GetWidth();

            // Adjust logo size based on available width (e.g., 20% of the page width)
            var logoWidth = pageWidth * 0.05f;

            var logoPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.jpeg");
            var logo = ImageDataFactory.Create(logoPath);
            //var img = new Image(logo).SetWidth(logoWidth).SetMarginBottom(10).SetHorizontalAlignment(HorizontalAlignment.LEFT);
            var img = new Image(logo).SetWidth(logoWidth).SetHorizontalAlignment(HorizontalAlignment.CENTER);

            // document.Add(img);
            // document.Add(new Paragraph().SetMarginBottom(5)); // Add some space after the logo

            // Add company name and details
            var companyName = "Telangana Remote Sensing Applications Centre (TGRAC)";
            var companyDetails = "Address: XXXXXXXXXXXXXXXXXXX\nPhone: XXXXXXXXXXXXXXX\nEmail: XXXXXXXXXXXXXXXXXl";
            var companyInfo = new Paragraph()
                .Add(new Text(companyName).SetBold().SetFontSize(14)).Add("\n")
                .Add(companyDetails).SetFontSize(10);

            // Create a table for the header with two rows: logo and company information
            var headerTable = new iText.Layout.Element.Table(new float[] { pageWidth }).UseAllAvailableWidth();
            headerTable.AddCell(new Cell().Add(img).SetBorder(Border.NO_BORDER).SetHorizontalAlignment(HorizontalAlignment.CENTER));
            headerTable.AddCell(new Cell().Add(companyInfo).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.CENTER));

            document.Add(headerTable);
            // Add a line after the company details
            var line = new LineSeparator(new SolidLine()).SetMarginTop(10).SetMarginBottom(10);
            document.Add(line);
            document.Add(new Paragraph().SetMarginBottom(20)); // Add some space after the header
        }

        private void AddTitle(Document document, string titleText)
        {
            var title = new Paragraph(titleText)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(24)
                .SetBold()
                .SetFontColor(ColorConstants.BLUE)
                .SetMarginBottom(20)
                .SetBorder(new SolidBorder(1));
            document.Add(title);
        }

        //private void AddUserDetails(Document document, EditUserViewModelTS currentUser)
        //{
        //    var userDetailsTitle = new Paragraph("User Details")
        //        .SetBold()
        //        .SetFontSize(16)
        //        .SetMarginBottom(10);
        //    document.Add(userDetailsTitle);

        //    var table = new iText.Layout.Element.Table(new float[] { 2, 5 }).UseAllAvailableWidth();

        //   // table.AddHeaderCell(CreateHeaderCell("Field"));
        //   // table.AddHeaderCell(CreateHeaderCell("Value"));

        //    table.AddCell(CreateCell("Employee Name: { currentUser.EmployeeName}")).AddCell(CreateCell(currentUser.EmployeeName));
        //    table.AddCell(CreateCell("Employee ID:")).AddCell(CreateCell(currentUser.EmployeeID));
        //    table.AddCell(CreateCell("Reporting Officer:")).AddCell(CreateCell(currentUser.ReportingOfficerName));
        //    table.AddCell(CreateCell("Reviewing Officer:")).AddCell(CreateCell(currentUser.ReviewingofficerName));

        //    document.Add(table);
        //}

        private void AddUserDetails(Document document, EditUserViewModelTS currentUser)
        {
            //var userDetailsTitle = new Paragraph("User Details")
            //    .SetBold()
            //    .SetFontSize(16)
            //    .SetMarginBottom(10);
            //document.Add(userDetailsTitle);

            var tabStops = new TabStop[] {
        new TabStop(300, TabAlignment.LEFT), // Set tab stop at 300 points
    };

            var employeeNameAndId = new Paragraph()
                .AddTabStops(tabStops)
                .Add(new Text("Employee Name: ").SetBold().SetFontSize(12).SetFontColor(ColorConstants.BLUE))
                .Add(currentUser.EmployeeName).SetFontSize(10)
                .Add(new Tab())
                .Add(new Text("Employee ID: ").SetBold().SetFontSize(12).SetFontColor(ColorConstants.BLUE))
                .Add(currentUser.EmployeeID).SetFontSize(10);

            document.Add(employeeNameAndId);

            // Add reporting officer and reviewing officer details if needed
            //if (!string.IsNullOrEmpty(currentUser.ReportingOfficerName) && !string.IsNullOrEmpty(currentUser.ReviewingofficerName))
            //{
            //    var reportingAndReviewing = new Paragraph()
            //        .AddTabStops(tabStops)
            //        .Add(new Text("Reporting Officer: ").SetBold())
            //        .Add(currentUser.ReportingOfficerName)
            //        .Add(new Tab())
            //        .Add(new Text("Reviewing Officer: ").SetBold())
            //        .Add(currentUser.ReviewingofficerName);

            //    document.Add(reportingAndReviewing);
            //}
        }


        private void AddTimeSheetDetails(Document document, IEnumerable<TimeSheet> timeSheets)
        {
            var timeSheetTitle = new Paragraph("Time Sheets")
                .SetBold()
                .SetFontSize(12)
                .SetMarginTop(20)
                .SetMarginBottom(10); 
           // .SetMarginRight(50);
            document.Add(timeSheetTitle);

            var table = new iText.Layout.Element.Table(new float[] { 1, 1, 6 }).UseAllAvailableWidth();

            table.AddHeaderCell(CreateHeaderCell("S.No"));
            table.AddHeaderCell(CreateHeaderCell("Date"));
            table.AddHeaderCell(CreateHeaderCell("Details"));

            int serialNumber = 1;

            foreach (var timeSheet in timeSheets)
            {
                table.AddCell(CreateCell(serialNumber.ToString(), TextAlignment.LEFT));
                table.AddCell(CreateCell(timeSheet.ReportDate.ToString("dd-MM-yyyy"), TextAlignment.CENTER));

                //var workDetails = new StringBuilder($"Work: \n{timeSheet.Work}\n\n");
                //workDetails.Append(!string.IsNullOrEmpty(timeSheet.RemarksByRpOf)
                //    ? $"\nReporting Officer Remarks:\n {timeSheet.RemarksByRpOf}\n<hr>"
                //    : $"\nReporting Officer Remarks:\n [No remarks provided]\n");
                //workDetails.Append(!string.IsNullOrEmpty(timeSheet.RemarksByReOf)
                //    ? $"\nReviewing Officer Remarks:\n {timeSheet.RemarksByReOf}\n"
                //    : $"\nReviewing Officer Remarks:\n [No remarks provided]\n");

                var workDetails = new StringBuilder();
                workDetails.AppendLine($"Work: \n{timeSheet.Work}\n");
                // Add a line separator after Work
                // workDetails.AppendLine(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(5).ToString());
                //workDetails.AppendLine(new LineSeparator(new SolidLine()).ToString());

                workDetails.AppendLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------");

                if (!string.IsNullOrEmpty(timeSheet.RemarksByRpOf))
                {
                    workDetails.AppendLine("Reporting Officer Remarks:");
                    workDetails.AppendLine($"{timeSheet.RemarksByRpOf}");
                    workDetails.AppendLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    workDetails.AppendLine("Reporting Officer Remarks:");
                    workDetails.AppendLine("[No remarks provided]");
                    workDetails.AppendLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }

                if (!string.IsNullOrEmpty(timeSheet.RemarksByReOf))
                {
                    workDetails.AppendLine("Reviewing Officer Remarks:\n");
                    workDetails.AppendLine($"{timeSheet.RemarksByReOf}");
                    workDetails.AppendLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    workDetails.AppendLine("Reviewing Officer Remarks:\n");
                    workDetails.AppendLine("[No remarks provided]");
                    workDetails.AppendLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }

                // Convert StringBuilder to string
                var workDetailsString = workDetails.ToString();

                table.AddCell(CreateCell(workDetails.ToString().TrimEnd('\n'), TextAlignment.LEFT));
                serialNumber++;
            }

            document.Add(table);
        }

        private Cell CreateHeaderCell(string text)
        {
            return new Cell().Add(new Paragraph(text).SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetPadding(5));
        }

        private Cell CreateCell(string text, TextAlignment alignment = TextAlignment.LEFT, bool bold = false)
        {
            var paragraph = new Paragraph().SetTextAlignment(alignment).SetPadding(5);
            if (bold)
            {
                paragraph.Add(new Text(text.Substring(0, text.IndexOf(':') + 1)).SetBold());
                paragraph.Add(new Text(text.Substring(text.IndexOf(':') + 1)));
            }
            else
            {
                paragraph.Add(text);
            }
            return new Cell().Add(paragraph).SetPadding(5);
        }

        private void AddSignatures(Document document, string reportingOfficerName, string reviewingOfficerName)
        {
            var signatureTitle = new Paragraph("Signatures")
                .SetBold()
                .SetFontSize(16)
                .SetMarginTop(20)
                .SetMarginBottom(10);
            document.Add(signatureTitle);

            var table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();

            table.AddCell(new Cell().Add(new Paragraph($"Reporting Officer: {reportingOfficerName}\n\n")
                .SetFontSize(12).SetTextAlignment(TextAlignment.LEFT))
                .Add(new Paragraph("Reporting Officer Signature: ___________________________")
                .SetFontSize(12))
                .SetBorder(Border.NO_BORDER));

            table.AddCell(new Cell().Add(new Paragraph($"Reviewing Officer: {reviewingOfficerName}\n\n")
                .SetFontSize(12).SetTextAlignment(TextAlignment.LEFT))
                .Add(new Paragraph("Reviewing Officer Signature: ___________________________")
                .SetFontSize(12))
                .SetBorder(Border.NO_BORDER));

            document.Add(table);
        }





        //private byte[] GeneratePdf(ApplicationUser currentUser, IEnumerable<TimeSheet> timeSheets)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var writer = new PdfWriter(memoryStream);
        //        var pdf = new PdfDocument(writer);
        //        var document = new Document(pdf);

        //        // Header with User Details
        //        document.Add(new Paragraph("User Details"));
        //        document.Add(new Paragraph($"Employee Name: {currentUser.EmployeeName}"));
        //        document.Add(new Paragraph($"Employee ID: {currentUser.EmployeeID}"));
        //        document.Add(new Paragraph($"Reporting Officer: {currentUser.PhoneNumber}"));
        //        document.Add(new Paragraph($"Reviewing Officer: {currentUser.Id}"));
        //        document.Add(new Paragraph("\n"));

        //        var columnWidths = new float[] { 16.67f, 16.67f, 16.67f, 16.67f, 16.67f, 16.67f }; // Six columns with equal width
        //        var table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

        //        // var table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();

        //        // Header Row
        //        table.AddHeaderCell("Work");
        //        table.AddHeaderCell("Assigned By");
        //        table.AddHeaderCell("Report Date");
        //        table.AddHeaderCell("Uploaded Date");
        //        table.AddHeaderCell("Remarks by Reviewing Officer");
        //        table.AddHeaderCell("Remarks by Reporting Officer");

        //        // Data Rows
        //        foreach (var timeSheet in timeSheets)
        //        {
        //            table.AddCell(timeSheet.Work);
        //            table.AddCell(timeSheet.AssignedBy);
        //            table.AddCell(timeSheet.ReportDate.ToString("dd-MM-yyyy"));
        //            table.AddCell(timeSheet.CurrentDate.ToString("dd-MM-yyyy"));
        //            table.AddCell(timeSheet.RemarksByReOf);
        //            table.AddCell(timeSheet.RemarksByRpOf);
        //        }

        //        document.Add(table);

        //        // Space for Signatures
        //        document.Add(new Paragraph("\n\n"));
        //        document.Add(new Paragraph("Reporting Officer Signature: ___________________________"));
        //        document.Add(new Paragraph("Reviewing Officer Signature: ___________________________"));

        //        document.Close();

        //        return memoryStream.ToArray();
        //    }
        //}
    }



}


    //public IActionResult ViewReport(string id)
    //{
    //    var report = _timeSheetRepository.GetTimeSheetsByEmployeeId(id);


    //    if (report == null)
    //    {
    //        return NotFound();
    //    }

    //    //var viewModel = new UserIndexViewModelTS
    //    //{
    //    //    CurrentUser = new EditUserViewModelTS(), // You may need to populate this if needed
    //    //    AllUsersWithRoles = new List<EditUserViewModelTS>(), // You may need to populate this if needed
    //    //    employeeWithRoles = new List<EmployeeWithRole>(), // You may need to populate this if needed
    //    //    TimeSheet = (TimeSheet)report, // Set the TimeSheet property to the fetched report
    //    //    TimeSheets = new List<TimeSheet> { TimeSheet } // You may need to adjust this if you're passing multiple time sheets
    //    //};

    //    var viewModel = new UserIndexViewModelTS
    //    {
    //        TimeSheets = report,
    //       // CurrentUser.Id = id,

    //    };

    //    viewModel.CurrentUser = new EditUserViewModelTS
    //    {
    //        Id = id
    //    };

    //    return View(viewModel);
    //}



