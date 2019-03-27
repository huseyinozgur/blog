using Blog.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Blog.BackOffice.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
        }

        [Route("~/auth/login")]
        public IActionResult Login() { return View(); }
    }
}
