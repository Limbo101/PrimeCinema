using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Model;

namespace RazorPagesTest2.Pages
{
    public class MoviesModel : PageModel
    {

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
             /*
            for (int i=0;i<10;i++) // generate a temporary list of movies for testing purposes
            {
                Movie.Add(new Model.Movie() { title = "Movie " + i, ID = i, price = i*10});  ;
            }
            */

        }


    }
}
