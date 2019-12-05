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
        {        // on get request (when you open the page probably
            

        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Getting and printing out data!");
           
            String response = await communication.getData();
            Console.WriteLine(response);




            Console.WriteLine("Loading movies II");
            
            for (int i = 0; i < communication.NEW_MOVIES.Count; i++) // generate a temporary list of movies for testing purposes
            {
                Movie.Add(communication.NEW_MOVIES[i]);
            }

            return Page();
        }


    }
}
