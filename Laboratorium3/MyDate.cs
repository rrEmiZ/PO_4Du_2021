using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium3
{
    class MyDate
    {
        DateTime date = DateTime.Now;

        public void getNowDate()
        {
            Console.WriteLine(date.ToString("d MMMM yyyy"));
        }
        public void substract7DaysBefore()
        {
           date = date.AddDays(-7);
        }
        public void add7Days()
        {
           date = date.AddDays(7);
        }
        public void getDateWithSpecificFormat(String arg)
        {
            Console.WriteLine("Today is " + date.ToString(arg));
        }
    }
}
