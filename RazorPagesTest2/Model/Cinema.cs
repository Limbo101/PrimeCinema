using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTest2.Model
{
    public class Cinema
    {
        public String name { get; set; }
        public String location { get; set; }
        public List<Hall> halls { get; set; }
        public int noSeatsPerHall { get; set; }
    }
}
