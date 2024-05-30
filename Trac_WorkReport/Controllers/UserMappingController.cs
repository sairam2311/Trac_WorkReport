//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Data.Entity;
//using WorkReport.DataAccess.Data;
//using WorkReport.Models;
//using WorkReport.Models.Models;
//using WorkRport.DataAccess.Repository.IRepository;

//namespace Trac_WorkReport.Controllers
//{
//    public class UserMappingController : Controller
//    {
//        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
//        private readonly Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> _roleManager;
//        private readonly ApplicationDbContext _context;
//        private readonly IProjectRepository _ProjectsRepo;

//        //public EmployeeMappingController(AppDbContext context)
//        //{
//        //    _context = context;
//        //}

//        public UserMappingController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> roleManager, ApplicationDbContext context, IProjectRepository db)
//        {
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _context = context;
//            _ProjectsRepo = db;
//        }
//        private static List<EmployeeMapping> employeeMappings = new List<EmployeeMapping>();
//        // Action to display employee mappings
//        public IActionResult Index()
//        {
//            var employeeMappings = _context.employeeMappings.ToList();

//            var viewModelList = new List<EmployeeMappingViewModel>();

//            foreach (var mapping in employeeMappings)
//            {
//                var viewModel = new EmployeeMappingViewModel
//                {
//                    Id = mapping.Id,
//                    EmployeeName = GetEmployeeName(mapping.EmployeeId),
//                    ReviewingOfficerName = GetEmployeeName(mapping.ReviewingOfficerId),
//                    ReportingOfficerName = GetEmployeeName(mapping.ReportingOfficerId)
//                };

//                viewModelList.Add(viewModel);
//            }

//            return View(viewModelList);
//        }

//        private string GetEmployeeName(string employeeId)
//        {
//            var employee = _userManager.Users.FirstOrDefault(e => e.Id == employeeId);
//            return employee != null ? employee.EmployeeName : "N/A";
//        }

//        // Action to add or edit employee mapping
//        //[HttpGet]
//        //public IActionResult Add()
//        //{
//        //    var employees = _userManager.Users.ToList(); // Fetch all employees
//        //    var model = new EmployeeMappingViewModel
//        //    {
//        //        EmployeeOptions = employees.Select(e => new SelectListItem { Value = e.Id, Text = e.EmployeeName }).ToList()
//        //    };
//        //    return View(model);
//        //}

//        //[HttpPost]
//        //    public IActionResult Add(EmployeeMapping model)
//        //    {
//        //        // Add validation and save logic here
//        //        if (ModelState.IsValid)
//        //        {
//        //            // Save or update the employee mapping
//        //            // For simplicity, I'm assuming a list-based storage here
//        //            if (model.Id == Guid.Empty)
//        //            {
//        //            model.Id = Guid.NewGuid();
//        //            try
//        //            {
//        //                employeeMappings.Add(model);
//        //            }
//        //            catch(Exception ex)
//        //            {

//        //            }

//        //            }
//        //            else
//        //            {
//        //                var existingMapping = employeeMappings.FirstOrDefault(e => e.Id == model.Id);
//        //                if (existingMapping != null)
//        //                {
//        //                    existingMapping.EmployeeId = model.EmployeeId;
//        //                    existingMapping.ReviewingOfficerId = model.ReviewingOfficerId;
//        //                    existingMapping.ReportingOfficerId = model.ReportingOfficerId;
//        //                }
//        //            }
//        //            return RedirectToAction("Index");
//        //        }
//        //        return View(model);
//        //    }




//        //[HttpGet]
//        //public IActionResult Add()
//        //{
//        //   // var employees = _userManager.Users.ToList(); // Fetch all employees
//        //   // var officers = _userManager.Users.fir; // Fetch all users for officers (can be a separate list)
//        //    //var model = new EmployeeMappingViewModel
//        //    //{
//        //    //    EmployeeOptions = employees.Select(e => new SelectListItem { Value = e.Id, Text = e.EmployeeName }).ToList(),
//        //    //    OfficerOptions = officers.Select(e => new SelectListItem { Value = e.Id, Text = e.EmployeeName }).ToList()
//        //    //};

//        //    var employeesU = _userManager.Users.Select(u => new SelectListItem
//        //    {
//        //        Value = u.Id,
//        //        Text = u.EmployeeName
//        //    }).ToList();


//        //    var officersU = _roleManager.Roles
//        //      .Where(r => r.RoleName == "SO" || r.RoleName == "ASO" || r.RoleName == "HOD" || r.RoleName == "ADG" || r.RoleName == "JD" || r.RoleName == "AO")
//        //      .SelectMany(r => r.Users)
//        //      .Select(u => new SelectListItem
//        //      {
//        //          Value = u.Id,
//        //          Text = u.EmployeeName
//        //      }).ToList();

//        //    var model = new EmployeeMappingViewModel
//        //    {
//        //        EmployeeOptions = employeesU,
//        //        OfficerOptions = officersU,
//        //       // ReportingOfficerOptions = officersU
//        //    };
//        //    return View(model);
//        //}

//        //[HttpPost]
//        //public IActionResult Add(EmployeeMapping model, List<string> selectedEmployees)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        // Save or update the employee mapping
//        //        if (model.Id == Guid.Empty)
//        //        {
//        //            try
//        //            {
//        //                _context.employeeMappings.Add(model); // Add to database context
//        //                _context.SaveChanges(); // Save changes to the database
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                // Handle the exception (e.g., log the error)
//        //                return RedirectToAction("Error", "Home"); // Redirect to an error page
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var existingMapping = _context.employeeMappings.FirstOrDefault(e => e.Id == model.Id);
//        //            if (existingMapping != null)
//        //            {
//        //                existingMapping.EmployeeId = model.EmployeeId;
//        //                existingMapping.ReviewingOfficerId = model.ReviewingOfficerId;
//        //                existingMapping.ReportingOfficerId = model.ReportingOfficerId;
//        //                _context.SaveChanges(); // Save changes to the database
//        //            }
//        //        }

//        //        // Save selected employees for mapping
//        //        foreach (var employeeId in selectedEmployees)
//        //        {
//        //            // Save mapping between employee and officers
//        //            var employeeMapping = new EmployeeMapping
//        //            {
//        //                EmployeeId = model.EmployeeId,
//        //                ReviewingOfficerId = model.ReviewingOfficerId,
//        //                ReportingOfficerId = model.ReportingOfficerId
//        //            };

//        //            // Add to database context and save changes
//        //            _context.employeeMappings.Add(employeeMapping);
//        //            _context.SaveChanges();
//        //        }

//        //        return RedirectToAction("Index");
//        //    }
//        //    return View(model);
//        //}

//        //[HttpPost]
//        //public IActionResult Add(EmployeeMappingViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        var employeeMapping = new EmployeeMapping
//        //        {
//        //            Id = Guid.NewGuid(),
//        //            EmployeeId = model.EmployeeName,
//        //            ReviewingOfficerId = model.ReportingOfficerName,
//        //            ReportingOfficerId = model.ReportingOfficerName
//        //            // Other properties assignment
//        //        };

//        //        _context.employeeMappings.Add(employeeMapping);
//        //        _context.SaveChanges();
//        //        return RedirectToAction("Index");
//        //    }
//        //    return View(model);
//        //}




//        [HttpGet]
//        public IActionResult Add()
//        {
//            // Fetch all employees
//            var employees = new List<SelectListItem>();
//            var pr = new List<SelectListItem>();
//            //var employees = _userManager.Users
//            //    .Where(u => !string.IsNullOrWhiteSpace(u.EmployeeName))
//            //    .Select(u => new SelectListItem
//            //    {
//            //        Value = u.Id,
//            //        Text = u.EmployeeName
//            //    }).ToList();

//            // var pr1 = _ProjectsRepo.GetAll();

//            pr = (List<SelectListItem>)_ProjectsRepo.GetProjectSelectListItems();

//            //var employees1 =  _roleManager.Roles
//            //     .Where(r => r.RoleName == "SO" || r.RoleName == "ASO" || r.RoleName == "HOD" || r.RoleName == "ADG" || r.RoleName == "JD" || r.RoleName == "AO")
//            //  .SelectMany(r => r.users.)
//            // .Select(u => new SelectListItem
//            // {
//            //      Value = u.Id,
//            //      Text = u.EmployeeName
//            // }).ToList();

//            // Fetch users for officer roles
//            var officerRoles = new[] { "SO", "ASO", "HOD", "ADG", "JD", "AO" };
//            var employeeRoles = new[] { "SO", "ASO", "SA", "PA" };
//            var officers = new List<SelectListItem>();

//            foreach (var roleName in officerRoles)
//            {
//                var role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName);
//                if (role != null)
//                {
//                    var usersInRole = _userManager.GetUsersInRoleAsync(role.Name).Result;
//                    officers.AddRange(usersInRole.Select(u => new SelectListItem
//                    {
//                        Value = u.Id,
//                        Text = u.EmployeeName
//                    }));
//                }
//            }

//            foreach (var roleName in employeeRoles)
//            {
//                var role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName);
//                if (role != null)
//                {
//                    var usersInRole = _userManager.GetUsersInRoleAsync(role.Name).Result;
//                    employees.AddRange(usersInRole.Select(u => new SelectListItem
//                    {
//                        Value = u.Id,
//                        Text = u.EmployeeName
//                    }));
//                }
//            }

//            var model = new EmployeeMappingViewModel
//            {
//                EmployeeOptions = employees,
//                OfficerOptions = officers,
//                Projects = pr
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Add(EmployeeMappingViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                foreach (var employeeId in model.SelectedEmployeeIds)
//                {
//                    var employeeMapping = new EmployeeMapping
//                    {
//                        Id = Guid.NewGuid(),
//                        EmployeeId = employeeId,
//                        ReviewingOfficerId = model.ReviewingOfficerId,
//                        ReportingOfficerId = model.ReportingOfficerId,
//                        ProjectId  = model.ProjectId

//                    };

//                    _context.employeeMappings.Add(employeeMapping);
//                }

//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(model);
//        }


//        [HttpGet]
//        public IActionResult Edit(Guid id)
//        {
//            var model = _context.employeeMappings.FirstOrDefault(e => e.Id == id);
//            return View(model); // Ensure this line returns the correct view name
//        }

//        [HttpPost]
//        public IActionResult Edit(EmployeeMapping model)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Update(model);
//                _context.SaveChanges();

//                return RedirectToAction("Index");
//            }

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult UpdateUsers(List<string> selectedUsers)
//        {
//            // Your logic to update users based on the selectedUsers list

//            // For example, you can iterate through the selected user IDs
//            foreach (var userId in selectedUsers)
//            {
//                // Perform the update operation for each selected user
//                // For demonstration purposes, let's just print the selected user IDs
//                Console.WriteLine($"Selected user ID: {userId}");
//            }

//            // Redirect back to the index action or any other action
//            return RedirectToAction("Index");
//        }

//        public class EmployeeMappingViewModel
//        {
//            public Guid Id { get; set; }
//            public string ReviewingOfficerId { get; set; }
//            public string ReportingOfficerId { get; set; }

//            public string ProjectId { get;set; }
//            public List<string> SelectedEmployeeIds { get; set; } = new List<string>();

//            public List<SelectListItem> EmployeeOptions { get; set; } = new List<SelectListItem>();
//            public List<SelectListItem> OfficerOptions { get; set; } = new List<SelectListItem>();

//            public List<SelectListItem> Projects { get; set; } = new List<SelectListItem>();

//            [ValidateNever]
//            public string EmployeeName { get; set; }
//            [ValidateNever]
//            public string ReviewingOfficerName { get; set; }
//            [ValidateNever]
//            public string ReportingOfficerName { get; set; }
//        }

//    }
//}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkReport.DataAccess.Data;
using WorkReport.Models;
using WorkReport.Models.Models;
using WorkRport.DataAccess.Repository.IRepository;

namespace Trac_WorkReport.Controllers
{
    public class UserMappingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IProjectRepository _ProjectsRepo;

        public UserMappingController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context, IProjectRepository projectsRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _ProjectsRepo = projectsRepo;
        }

        public IActionResult Index()
        {
            var employeeMappings = _context.employeeMappings.ToList();

            var viewModelList = employeeMappings.Select(mapping => new EmployeeMappingViewModel
            {
                Id = mapping.Id,
                EmployeeName = GetEmployeeName(mapping.EmployeeId),
                ReviewingOfficerName = GetEmployeeName(mapping.ReviewingOfficerId),
                ReportingOfficerName = GetEmployeeName(mapping.ReportingOfficerId)
            }).ToList();

            return View(viewModelList);
        }

        private string GetEmployeeName(string employeeId)
        {
            var employee = _userManager.Users.FirstOrDefault(e => e.Id == employeeId);
            return employee?.EmployeeName ?? "N/A";
        }

        [HttpGet]
        public IActionResult Add()
        {
            var employees = GetUsersInRoles(new[] { "SO", "ASO", "SA", "PA" });
            var officers = GetUsersInRoles(new[] { "SO", "ASO", "HOD", "ADG", "JD", "AO" });
            var projects = _ProjectsRepo.GetProjectSelectListItems().ToList();

            var model = new EmployeeMappingViewModel
            {
                EmployeeOptions = employees,
                OfficerOptions = officers,
                Projects = projects
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EmployeeMappingViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var employeeId in model.SelectedEmployeeIds)
                {
                    var employeeMapping = new EmployeeMapping
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = employeeId,
                        ReviewingOfficerId = model.ReviewingOfficerId,
                        ReportingOfficerId = model.ReportingOfficerId,
                        ProjectId = model.ProjectId
                    };

                    _context.employeeMappings.Add(employeeMapping);
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var mapping = _context.employeeMappings.FirstOrDefault(e => e.Id == id);
            if (mapping == null)
            {
                return NotFound();
            }

            var model = new EmployeeMappingViewModel
            {
                Id = mapping.Id,
                EmployeeName = GetEmployeeName(mapping.EmployeeId),
                ReviewingOfficerName = GetEmployeeName(mapping.ReviewingOfficerId),
                ReportingOfficerName = GetEmployeeName(mapping.ReportingOfficerId)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeMapping model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUsers(List<string> selectedUsers)
        {
            foreach (var userId in selectedUsers)
            {
                Console.WriteLine($"Selected user ID: {userId}");
            }

            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetUsersInRoles(string[] roleNames)
        {
            var usersInRoles = new List<SelectListItem>();

            foreach (var roleName in roleNames)
            {
                var role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    var users = _userManager.GetUsersInRoleAsync(role.Name).Result;
                    usersInRoles.AddRange(users.Select(u => new SelectListItem
                    {
                        Value = u.Id,
                        Text = u.EmployeeName
                    }));
                }
            }

            return usersInRoles;
        }

        public class EmployeeMappingViewModel
        {
            public Guid Id { get; set; }
            public string ReviewingOfficerId { get; set; }
            public string ReportingOfficerId { get; set; }
            public string ProjectId { get; set; }
            public List<string> SelectedEmployeeIds { get; set; } = new List<string>();

            public List<SelectListItem> EmployeeOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> OfficerOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> Projects { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public string EmployeeName { get; set; }
            [ValidateNever]
            public string ReviewingOfficerName { get; set; }
            [ValidateNever]
            public string ReportingOfficerName { get; set; }
        }
    }
}

