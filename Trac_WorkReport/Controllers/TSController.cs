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
    }
}
