using GigHub.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager userManager;
        

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false)
                }
            }
        }
    }
}