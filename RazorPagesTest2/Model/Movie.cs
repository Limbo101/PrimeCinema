using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTest2.Model
{
    public class Movie
    {

        public string title { get; set; }

        public Cinema cinema { get; set; }

        public int date { get; set; }


        public int duration { get; set; }


    }
}
