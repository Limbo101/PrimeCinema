using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;

namespace RazorPagesTest2.Pages
{
    public class RegisterModel : PageModel
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

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostRegister()
        {
            await communication.POSTRegistrationData(registerUsername, registerPassword, registerConfirmPassword, registerEmail);
            return Page();
        }

        public async Task<IActionResult> OnPostLogin()
        {
            await communication.POSTLoginData(loginUsername, loginPassword);
            return Page();
        }

    }
}
