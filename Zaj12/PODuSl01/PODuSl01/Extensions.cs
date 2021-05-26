using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01
{
   public static  class Extensions
    {

        public static void PrintProps(this object obj)
        {
            var type = obj.GetType();

            var props = type.GetProperties();


            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(obj));
            }
        }

    }
}
