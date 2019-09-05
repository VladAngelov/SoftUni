
namespace RentACarWeb.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using RentACar.Data.Models.User;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<RentACarUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<RentACarUser> _userManager;
      //  private readonly ILogger<RegisterModel> _logger;
     //   private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<RentACarUser> userManager,
            SignInManager<RentACarUser> signInManager,
            RoleManager<IdentityRole> roleManager
            /*IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
         //   _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Потребителско име")]
            //[Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "Първо име")]
            [StringLength(30, ErrorMessage = "{0}, трябва да бъде между {2} и {1} символа.", MinimumLength = 3)]
            //[Display(Name = "First name")]
            //[StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            [StringLength(30, ErrorMessage = "{0}, трябва да бъде между {2} и {1} символа.", MinimumLength = 3)]
            //[Display(Name = "Last name")]
            //[StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Парола")]
            [StringLength(30, ErrorMessage = "{0}, трябва да бъде между {2} и {1} символа.", MinimumLength = 3)]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            //[DataType(DataType.Password)]
            //[Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Потвърджение на парола")]
            [Compare("Password", ErrorMessage = "Паролите не съвпадат!")]
            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Телефонен номер")]
            //[Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Електронна поща")]
            //[Display(Name = "Email")]
            public string Email { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Identity/Account/Login";

            if (ModelState.IsValid)
            {
                var isRoot = !_userManager.Users.Any();

                var user = new RentACarUser
                {
                    UserName = Input.Username,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    Email = Input.Email,
                    FullName = Input.FirstName + " " + Input.LastName

                    // TODO: maybe bug??
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    if (isRoot)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                    }

                    #region Email Functionality
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    #endregion

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}