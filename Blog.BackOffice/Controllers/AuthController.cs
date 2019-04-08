using Blog.BackOffice.Models.AuthView;
using Blog.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.BackOffice.Controllers
{
    public class AuthController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public RoleManager<ApplicationRole> RoleManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }


        public IActionResult Login() => View(new LoginViewModel());
        

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                //foreach (var item in ModelState.Values.Where(q => q.ValidationState != Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid))
                //{
                //    ModelState.AddModelError(string.Empty, item.Errors.FirstOrDefault().ToString());
                //}

                return View(loginViewModel);
            }
            ApplicationUser user = await UserManager.FindByEmailAsync(loginViewModel.Email);

            if (user == null )
            {
                ModelState.AddModelError(string.Empty, "kullanıcı bulunamadı lütfen Admin ile temasa geçiniz.");
                return View();
            }

            var result = await SignInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, false,false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }

        public async Task<IActionResult> Logout() {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

    }
}
