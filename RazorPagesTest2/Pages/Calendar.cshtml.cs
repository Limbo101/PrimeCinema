using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;
using RazorPagesTest2.Model;

namespace RazorPagesTest2.Pages
{
    [Authorize]
    public class CalendarModel : PageModel
    {
        public List<Movie> movies;
        [BindProperty]
        public String date { get; set; }
        private T2Communication communication = T2Communication.getInstance(); 

        public async Task<IActionResult> OnGet() 
        {
            String today = DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Year.ToString();
            date = today;
            movies = await communication.GETMovieData(date);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine(date);
            movies = await communication.GETMovieData(date);
            return Page();
        }

        public async Task<IActionResult> OnPostBook()
        {


            return Page();
        }


    }
}
