//////using Microsoft.AspNetCore.Mvc;
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

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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


        [HttpGet]
        public IActionResult ViewReport(string id)
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

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ViewReport(UserIndexViewModelTS model)
        {
            var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(model.reportViewModels.First().UserId);

            if (model.reportViewModels.First().StartDate.HasValue && model.reportViewModels.First().EndDate.HasValue)
            {
                reports = reports
                    .Where(t => t.ReportDate >= model.reportViewModels.First().StartDate && t.ReportDate <= model.reportViewModels.First().EndDate)
                    .ToList();
            }

            model.reportViewModels.First().TimeSheets = reports;

            return View(model);
        }


        [HttpPost]
        public IActionResult DownloadReport(string userId, DateTime? startDate, DateTime? endDate)
        {
            var reports = _timeSheetRepository.GetTimeSheetsByEmployeeId(userId);

            if (startDate.HasValue && endDate.HasValue)
            {
                reports = reports
                    .Where(t => t.ReportDate >= startDate && t.ReportDate <= endDate)
                    .ToList();
            }

            // var csv = GenerateCsv(reports);

            // var bytes = Encoding.UTF8.GetBytes(csv);


            //var output = new FileContentResult(bytes, "text/csv")
            //{
            //    FileDownloadName = $"Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.csv"
            //};
            var user = _userManager.FindByIdAsync(userId).Result;

            var pdfBytes = GeneratePdf(user, reports);
            // var pdfBytes = GeneratePdf(reports);
            var output = new FileContentResult(pdfBytes, "application/pdf")
            {
                FileDownloadName = $"Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.pdf"
            };
            return output;
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


        private byte[] GeneratePdf(ApplicationUser currentUser, IEnumerable<TimeSheet> timeSheets)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Header with User Details
                document.Add(new Paragraph("User Details"));
                document.Add(new Paragraph($"Employee Name: {currentUser.EmployeeName}"));
                document.Add(new Paragraph($"Employee ID: {currentUser.EmployeeID}"));
                document.Add(new Paragraph($"Reporting Officer: {currentUser.PhoneNumber}"));
                document.Add(new Paragraph($"Reviewing Officer: {currentUser.Id}"));
                document.Add(new Paragraph("\n"));

                var columnWidths = new float[] { 16.67f, 16.67f, 16.67f, 16.67f, 16.67f, 16.67f }; // Six columns with equal width
                var table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                // var table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();

                // Header Row
                table.AddHeaderCell("Work");
                table.AddHeaderCell("Assigned By");
                table.AddHeaderCell("Report Date");
                table.AddHeaderCell("Uploaded Date");
                table.AddHeaderCell("Remarks by Reviewing Officer");
                table.AddHeaderCell("Remarks by Reporting Officer");

                // Data Rows
                foreach (var timeSheet in timeSheets)
                {
                    table.AddCell(timeSheet.Work);
                    table.AddCell(timeSheet.AssignedBy);
                    table.AddCell(timeSheet.ReportDate.ToString("dd-MM-yyyy"));
                    table.AddCell(timeSheet.CurrentDate.ToString("dd-MM-yyyy"));
                    table.AddCell(timeSheet.RemarksByReOf);
                    table.AddCell(timeSheet.RemarksByRpOf);
                }

                document.Add(table);

                // Space for Signatures
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Reporting Officer Signature: ___________________________"));
                document.Add(new Paragraph("Reviewing Officer Signature: ___________________________"));

                document.Close();

                return memoryStream.ToArray();
            }
        }
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



