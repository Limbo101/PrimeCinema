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

        public async Task OnGet() // whenever you get the webpage
        {        // on get request (when you open the page probably)
                 /*
                 IQueryable<string> genreQuery = from m in _context.Movie   // Get the genres from database
                                                 orderby m.Genre
                                                 select m.Genre;

                 // creates a query, without executing it yet
                 IQueryable<Movie> movies = from m in _context.Movie select m; // get the movies from the database
                 if (!string.IsNullOrEmpty(SearchString))
                 {
                     movies = movies.Where(m => m.Title.ToLower().Contains(SearchString.ToLower()));
                 }

                 if (!string.IsNullOrEmpty(MovieGenre))
                 {
                     movies = movies.Where(m => m.Genre == MovieGenre);
                 }
                 //Distint removes duplicates
                 Genres = new SelectList(await genreQuery.Distinct().ToListAsync()); // put the genres into this classes list
                 Movie = await movies.ToListAsync(); // put the movies into this classes list
                  */
        
            
        
          
            

        }

        public async Task<IActionResult> OnPost()
        {
             communication.startClient(date);
            Console.WriteLine("StartClient done!");

            Console.WriteLine("Loading movies I");
            Movie = communication.NEW_MOVIES;

            Console.WriteLine("Loading movies II");
            
            for (int i = 0; i < communication.NEW_MOVIES.Count; i++) // generate a temporary list of movies for testing purposes
            {
                Movie.Add(communication.NEW_MOVIES[i]);
            }

            return Page();
        }


    }
}
