using Library.Data.Models;
using Library.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<LibraryUser> userManager;
        private readonly SignInManager<LibraryUser> signInManager;

        public UserController(
            UserManager<LibraryUser> userManager,
            SignInManager<LibraryUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            LibraryUser user = new LibraryUser
            {
                Email = model.Email,
                UserName = model.UserName,
                EmailConfirmed = true
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);

                return this.RedirectToAction("Login", "User");
            }

            foreach (IdentityError error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            LogInViewModel model = new LogInViewModel
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            LibraryUser user = await this.userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    false,
                    false);
                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return this.Redirect(model.ReturnUrl);
                    }

                    return this.RedirectToAction("All", "Books");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Invalid login!");

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
