using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;
using RazorPagesTest2.Model;

namespace RazorPagesTest2.Pages
{
    public class CalendarModel : PageModel
    {

        [BindProperty]
        public String date { get; set; }
        private T2Communication communication = new T2Communication(); 
        public List<Movie> Movie = new List<Movie>();

        public async Task OnGet() 
        {
            communication.GETMovieData(date);

        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Getting and printing out data!");
            Console.WriteLine(date);
            communication.GETMovieData(date);
            // String response = await communication.getData();
            //Console.WriteLine(response);
            


            return Page();
        }


    }
}
