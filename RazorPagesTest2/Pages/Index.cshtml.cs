using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;

namespace RazorPagesTest2.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public String registerUsername { get; set; }
        [BindProperty]
        public String registerPassword { get; set; }
        [BindProperty]
        public String registerConfirmPassword { get; set; }
        [BindProperty]
        public String registerEmail { get; set; }
        [BindProperty]
        public String loginUsername { get; set; }
        [BindProperty]
        public String loginPassword { get; set; }


        private T2Communication communication = new T2Communication();

        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated) return RedirectToPage("Calendar");
            return Page();
        }

        public async Task<IActionResult> OnPostRegister()
        {
            await communication.POSTRegistrationData(registerUsername, registerPassword, registerConfirmPassword, registerEmail);
            return Page();
        }

        public async Task<IActionResult> OnPostLogin()
        {

            //if(await communication.POSTLoginData(loginUsername, loginPassword != OkObjectResult))
            //{
            var identity = new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Name, loginUsername) },
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);
            //}
            return RedirectToAction("Register");
        }
    }
}