using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTest2.Model
{
    public class DateNavigator
    {
        public int navDay { get; set; }
        public int navMonthNum { get; set; }
        public int navYear { get; set; }



        public DateNavigator()
        {
            navDay = DateTime.Now.Day;
            navMonthNum = DateTime.Now.Month;
            navYear = DateTime.Now.Year;
        }

        public int getDay()
        {
            return navDay;
        }

        public String NumToMonth()
        {
            switch (navMonthNum)
            {
                default: return "January";
                case (2): return "February";
                case (3): return "March";
                case (4): return "April";
                case (5): return "May";
                case (6): return "June";
                case (7): return "July";
                case (8): return "August";
                case (9): return "September";
                case (10): return "October";
                case (11): return "November";
                case (12): return "December";
            }
        }

        public int getDaysInMonth()
        {
            return DateTime.DaysInMonth(navYear, navMonthNum);
        }
    }
}
