//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Text.Encodings.Web;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.Extensions.Logging;
//using Trac_WorkReport.Models;
//using WorkReport.Models;
//using WorkRport.DataAccess.Repository.IRepository;

//namespace Trac_WorkReport.Areas.Identity.Pages.Account
//{
//    public class RegisterModel : PageModel
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IUserStore<ApplicationUser> _userStore;
//        private readonly IUserEmailStore<ApplicationUser> _emailStore;
//        private readonly ILogger<RegisterModel> _logger;
//        private readonly IEmailSender _emailSender;
//        private readonly IDesignationRepository _designationRepo;
//        private readonly IProjectRepository _projectRepo;

//        public RegisterModel(
//            UserManager<ApplicationUser> userManager,
//            IUserStore<ApplicationUser> userStore,
//            SignInManager<ApplicationUser> signInManager,
//            ILogger<RegisterModel> logger,
//            IEmailSender emailSender,
//            IDesignationRepository designationRepo,
//            IProjectRepository projectRepo)
//        {
//            _userManager = userManager;
//            _userStore = userStore;
//           _emailStore = GetEmailStore();
//            _signInManager = signInManager;
//            _logger = logger;
//            _emailSender = emailSender;
//            _designationRepo = designationRepo;
//            _projectRepo = projectRepo;
//        }

//        [BindProperty]
//        public RegisterViewModel RegisterViewModel { get; set; }

//        public IList<AuthenticationScheme> ExternalLogins { get; set; }

//        [ValidateNever]
//        public string ReturnUrl { get; set; }

//        public async Task OnGetAsync(string returnUrl = null)
//        {
//            //ReturnUrl = returnUrl;

//            ReturnUrl = returnUrl ?? Url.Content("~/");
//            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

//            var designations = _designationRepo.GetAll().ToList();
//            var projects = _projectRepo.GetAll().ToList();

//            RegisterViewModel = new RegisterViewModel
//            {
//                Designations = new List<SelectListItem>
//        {
//            new SelectListItem { Value = "", Text = "Please select" }
//        }.Concat(designations.Select(d => new SelectListItem
//        {
//            Value = d.DesId.ToString(),
//            Text = d.DesFull
//        })).ToList(),

//                Projects = new List<SelectListItem>
//        {
//            new SelectListItem { Value = "", Text = "Please select" }
//        }.Concat(projects.Select(p => new SelectListItem
//        {
//            Value = p.ProjectId.ToString(),
//            Text = p.ProjectName
//        })).ToList(),

//                Input = new InputModel()
//            };


//        }


//        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
//        {
//            returnUrl ??= Url.Content("~/");
//            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

//            if (ModelState.IsValid)
//            {
//                var user = CreateUser();
//                await _userStore.SetUserNameAsync(user, RegisterViewModel.Input.Email, CancellationToken.None);
//                await _emailStore.SetEmailAsync(user, RegisterViewModel.Input.Email, CancellationToken.None);
//                user.DesignationID = RegisterViewModel.Input.DesignationID;
//                user.ProjectID = RegisterViewModel.Input.ProjectID;

//                var result = await _userManager.CreateAsync(user, RegisterViewModel.Input.Password);

//                if (result.Succeeded)
//                {
//                    _logger.LogInformation("User created a new account with password.");

//                    var userId = await _userManager.GetUserIdAsync(user);
//                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
//                    var callbackUrl = Url.Page(
//                        "/Account/ConfirmEmail",
//                        pageHandler: null,
//                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
//                        protocol: Request.Scheme);

//                    await _emailSender.SendEmailAsync(RegisterViewModel.Input.Email, "Confirm your email",
//                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

//                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
//                    {
//                        return RedirectToPage("RegisterConfirmation", new { email = RegisterViewModel.Input.Email, returnUrl = returnUrl });
//                    }
//                    else
//                    {

//                        await _signInManager.SignInAsync(user, isPersistent: false);
//                        return LocalRedirect(returnUrl);
//                    }
//                }

//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
//            }

//            // If we got this far, something failed, redisplay form
//            var designations = _designationRepo.GetAll().ToList();
//            RegisterViewModel.Designations = new List<SelectListItem>
//            {
//                new SelectListItem { Value = "", Text = "Please select" }
//            }.Concat(designations.Select(d => new SelectListItem
//            {
//                Value = d.DesId.ToString(),
//                Text = d.DesFull
//            })).ToList();

//            var projects = _projectRepo.GetAll().ToList();
//            RegisterViewModel.Projects = new List<SelectListItem>
//            {
//                new SelectListItem { Value = "", Text = "Please select" }
//            }.Concat(projects.Select(p => new SelectListItem
//            {
//                Value = p.ProjectId.ToString(),
//                Text = p.ProjectName
//            })).ToList();

//            return Page();
//        }

//        private ApplicationUser CreateUser()
//        {
//            try
//            {
//                return Activator.CreateInstance<ApplicationUser>();
//            }
//            catch
//            {
//                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
//                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
//                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
//            }
//        }

//        private IUserEmailStore<ApplicationUser> GetEmailStore()
//        {
//            if (!_userManager.SupportsUserEmail)
//            {
//                throw new NotSupportedException("The default UI requires a user store with email support.");
//            }
//            return (IUserEmailStore<ApplicationUser>)_userStore;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Trac_WorkReport.Models;
using WorkReport.Models;
using WorkRport.DataAccess.Repository.IRepository;

namespace Trac_WorkReport.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IDesignationRepository _designationRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
           
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
     
            _roleManager = roleManager;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [ValidateNever]
        public string ReturnUrl { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            await LoadDesignationsAndProjectsAsync();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, RegisterViewModel.Input.EmployeeID, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, RegisterViewModel.Input.Email, CancellationToken.None);
                user.EmployeeID = RegisterViewModel.Input.EmployeeID;
                user.EmployeeName = RegisterViewModel.Input.EmployeeName;
                
                //user.empl
                //user.DesignationID = RegisterViewModel.Input.DesignationID;
                //user.ProjectID = RegisterViewModel.Input.ProjectID;

                var result = await _userManager.CreateAsync(user, RegisterViewModel.Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, RegisterViewModel.Input.role);

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(RegisterViewModel.Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = RegisterViewModel.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                       // await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await LoadDesignationsAndProjectsAsync();
            return Page();
        }

        private async Task LoadDesignationsAndProjectsAsync()
        {
            //var designations = await Task.Run(() => _designationRepo.GetAll().ToList());
           // var projects = await Task.Run(() => _projectRepo.GetAll().ToList());

            RegisterViewModel = new RegisterViewModel
            {
                //Designations = new List<SelectListItem>
                //{
                //    new SelectListItem { Value = "", Text = "Please select" }
                //}.Concat(designations.Select(d => new SelectListItem
                //{
                //    Value = d.DesId.ToString(),
                //    Text = d.DesFull
                //})).ToList(),

                //Projects = new List<SelectListItem>
                //{
                //    new SelectListItem { Value = "", Text = "Please select" }
                //}.Concat(projects.Select(p => new SelectListItem
                //{
                //    Value = p.ProjectId.ToString(),
                //    Text = p.ProjectName
                //})).ToList(),

                

                Input = new InputModel()
                {
                    RoleList = _roleManager.Roles.Select(x => x.NormalizedName).Select(i => new SelectListItem
                    {
                        Text = i,
                        Value=i
                    })
                }
            };
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return new ApplicationUser();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}

