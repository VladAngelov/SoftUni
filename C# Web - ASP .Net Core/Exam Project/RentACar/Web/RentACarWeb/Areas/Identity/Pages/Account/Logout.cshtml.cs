namespace RentACarWeb.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using RentACar.Data.Models.User;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<RentACarUser> _signInManager;

        public LogoutModel(SignInManager<RentACarUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return Redirect("/Identity/Account/Login");
        }
    }
}