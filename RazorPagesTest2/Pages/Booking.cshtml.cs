using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;


namespace RazorPagesTest2.Pages
{
    [Authorize]
    [BindProperties]
    public class BookingModel : PageModel
    {
        private T2Communication communication = T2Communication.getInstance();

        public String username { get; set; }
        public String hour { get; set; }
        public String date { get; set; }
        public String title { get; set; }
        //public String duration;

            
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostBook()
        {
            await communication.POSTBookingData(username, title, hour, date);
            return Page();
        }
    }
}
