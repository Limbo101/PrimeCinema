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
        public String userName { get; set; }
        [BindProperty]
        public String password { get; set; }
        [BindProperty]
        public String confirmPassword { get; set; }
        [BindProperty]
        public String email { get; set; }


        private T2Communication communication = new T2Communication();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Sending post request!");
            await communication.POSTRegistrationData(userName, password, confirmPassword, email);
            Console.WriteLine("Post request sent!");

            return Page();
        }

    }
}
