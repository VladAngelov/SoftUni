﻿namespace RentACarWeb.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using RentACar.Data.Models.User;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;


    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<RentACarUser> _signInManager;

        public LoginModel(SignInManager<RentACarUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            // [Display(Name = "Потребителско име")]
            [MaxLength(30)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            //[Display(Name = "Парола")]
            [Display(Name = "Password")]
            // [DataType(DataType.Password)]
            public string Password { get; set; }

            // [Display(Name = "Запомни ме?")]
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Home/Index";

            if (ModelState.IsValid)
            {
                var result = Microsoft.AspNetCore.Identity.SignInResult.Failed;

                try
                {
                    result = await _signInManager.PasswordSignInAsync(
                      Input.Username,
                      Input.Password,
                      Input.RememberMe,
                      lockoutOnFailure: true);
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }


                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    // ModelState.AddModelError(string.Empty, "Невалиден!");

                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                    return Page();
                }
            }

            return Page();
        }
    }
}