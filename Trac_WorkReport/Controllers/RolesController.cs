using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.Models;

namespace Trac_WorkReport.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // List all the roles created by User
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        // Display the form for creating a new role
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handle the form submission to create a new role
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationRole obj)
        {
            // Check if the role already exists to avoid duplicates
            if (!await _roleManager.RoleExistsAsync(obj.Name))
            {
                // Create a new role instance with the provided details
                var role = new ApplicationRole
                {
                    Name = obj.Name,
                    // Uncomment the next line if you need to normalize the name
                    // NormalizedName = obj.Name.ToUpper(),
                    RoleName = obj.RoleName
                };

                // Attempt to create the role asynchronously
                var result = await _roleManager.CreateAsync(role);

                // Check if the role creation was successful
                if (result.Succeeded)
                {
                    // Redirect to the Index action if successful
                    return RedirectToAction("Index");
                }
                else
                {
                    // Add any errors to the ModelState to display to the user
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                // Add an error to ModelState if the role already exists
                ModelState.AddModelError(string.Empty, "Role already exists.");
            }

            // Return the view with any errors if the process failed
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationRole role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingRole = await _roleManager.FindByIdAsync(id);
                    if (existingRole == null)
                    {
                        return NotFound();
                    }

                    existingRole.Name = role.Name;
                    // Uncomment the next line if you need to update the normalized name
                    // existingRole.NormalizedName = role.Name.ToUpper();
                    existingRole.RoleName = role.RoleName;

                    var result = await _roleManager.UpdateAsync(existingRole);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError(string.Empty, "Concurrency error occurred.");
                }
            }

            return View(role);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(role);
        }
    }
}
