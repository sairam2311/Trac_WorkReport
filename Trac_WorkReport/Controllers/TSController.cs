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

        public TSController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmployeeMapRepository employeeMapRep)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _employeeMapRep = employeeMapRep;
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
            var alluserswithRRR = new List<EditUserViewModelTS>();

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

            // Fetch reporting officer names using EmployeeMapRepository
            //var reportingOfficerNames = _employeeMapRep.GetReportingOfficerName(currentUser.Id).ToList();

            // Fetch the reviewing officer name for the current user
            var reviewingOfficerName = _employeeMapRep.GetReviewingOfficerName(currentUser.Id);
            var reportingOfficerName = _employeeMapRep.GetReportingOfficerName(currentUser.Id);

            // Assign reporting officer names to corresponding users
            //for (int i = 0; i < allUsersWithRoles.Count; i++)
            //{
            //    allUsersWithRoles[i].ReportingOfficerName = reportingOfficerNames[i];
            //}

            var model = new UserIndexViewModelTS
            {
                CurrentUser = new EditUserViewModelTS
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    EmployeeID = currentUser.EmployeeID,
                    EmployeeName = currentUser.EmployeeName,
                    ReviewingofficerName=reviewingOfficerName,
                    ReportingOfficerName = reportingOfficerName,
                    
                    Roles = currentUserRoles.Select(r => new RoleViewModelTS
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                },
                AllUsersWithRoles = allUsersWithRoles
            };

            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TimeSheet TimeS)
        {
            // _ProjectsRepo.Add(obj);
            // _ProjectsRepo.save();
            return RedirectToAction("Index");
        }
    }

   

    public class UserIndexViewModelTS
    {
        public EditUserViewModelTS CurrentUser { get; set; }
        public List<EditUserViewModelTS> AllUsersWithRoles { get; set; }
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
}
