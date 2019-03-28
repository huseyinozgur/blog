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


        public IActionResult Login() => View();
        

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(Email);

            if (user == null )
            {
                ModelState.AddModelError(string.Empty, "kullanıcı bulunamadı lütfen Admin ile temasa geçiniz.");
                return View();
            }

            var result = await SignInManager.PasswordSignInAsync(user.UserName, Password,false,false);

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
