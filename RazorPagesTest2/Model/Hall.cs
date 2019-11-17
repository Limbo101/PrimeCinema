using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTest2.Model
{
    public class Hall
    {
        public String id { get; set; }
        public int numberOfSeats { get; set; }
        public List<seat> seats { get; set; }
    }
}
