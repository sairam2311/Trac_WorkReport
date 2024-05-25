using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.Models;

namespace Trac_WorkReport.Controllers
{
    public class UserController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> _roleManager;

        public UserController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Display logged-in user details and all users
        public async Task<IActionResult> Index()
        {
            // Get the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            // Fetch the roles of the logged-in user
            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);
           
            var allUsers = await _userManager.Users.ToListAsync();
            var allUsersWithRoles = new List<EditUserViewModel>();
           
            //var model = new UserIndexViewModel
            //{
            //    CurrentUser = new EditUserViewModel
            //    {
            //        Id = currentUser.Id,
            //        Email = currentUser.Email,
            //        EmployeeName = currentUser.EmployeeName,
            //        Roles = currentUserRoles.Select(r => new RoleViewModel
            //        {
            //            RoleName = r,
            //            IsSelected = true
            //        }).ToList()
            //    },

            //};

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                allUsersWithRoles.Add(new EditUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    employeeID = user.EmployeeID,
                    EmployeeName = user.EmployeeName,
                    Roles = roles.Select(r => new RoleViewModel
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList()
                });
            }

            var model = new UserIndexViewModel
            {
                CurrentUser = new EditUserViewModel
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    EmployeeName = currentUser.EmployeeName,
                    Roles = currentUserRoles.Select(r => new RoleViewModel
                    {
                        RoleName = r,
                        IsSelected = true
                    }).ToList(),
                  
                },
                AllUsersWithRoles = allUsersWithRoles
            };

            return View(model);
        }


            // Display the form for editing a user
            public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                EmployeeName = user.EmployeeName,
                Roles = allRoles.Select(r => new RoleViewModel
                {
                    RoleName = r.Name,
                    IsSelected = userRoles.Contains(r.Name)
                }).ToList()
            };

            return View(model);
        }

        // Handle the form submission to edit a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.Email;
            user.UserName = model.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName);
            var rolesToAdd = selectedRoles.Except(userRoles);
            var rolesToRemove = userRoles.Except(selectedRoles);

            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("Index");
        }

        // Display the form for deleting a user
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // Handle the form submission to delete a user
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            return RedirectToAction("Index");
        }
    }

    // View model for editing user
    //public class EditUserViewModel
    //{
    //    public string Id { get; set; }
    //    public string Email { get; set; }
    //    public List<RoleViewModel> Roles { get; set; }
    //}

    //// View model for user roles
    //public class RoleViewModel
    //{
    //    public string RoleName { get; set; }
    //    public bool IsSelected { get; set; }
    //}


    // View model for the user index page
    public class UserIndexViewModel
    {
        public EditUserViewModel CurrentUser { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }
        public List<EditUserViewModel> AllUsersWithRoles { get; set; }
    }

    // View model for editing user
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; } 
        public string EmployeeName { get; set; }

        public string employeeID { get; set; }
        public List<RoleViewModel> Roles { get; set; }
      
    }

    // View model for user roles
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }

   
}
