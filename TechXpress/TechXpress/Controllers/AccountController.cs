using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_PL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace TechXpress_PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _db;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _db = db;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpVm model)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int? userTypeId = null;
            string role = model.UserType.ToString();

            // Start transaction if needed
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                // Create ApplicationUser instance first
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    FirstName = model.Name,
                    UserType = model.UserType,
                    PhoneNumber = model.PhoneNumber,    

                };

                IdentityResult userCreateResult = await userManager.CreateAsync(user, model.Password);
                if (!userCreateResult.Succeeded)
                {
                    foreach (var error in userCreateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

              
                // Add the user to the appropriate role
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                await userManager.AddToRoleAsync(user, role);

                // Commit the transaction
                await transaction.CommitAsync();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "An error occurred while creating your account.");
                return View(model);
            }
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials.");
                return View(model);
            }


            var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {

                ModelState.AddModelError(string.Empty, "Invalid credentials.");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
