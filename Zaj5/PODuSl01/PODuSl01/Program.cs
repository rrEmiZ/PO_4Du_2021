using PODuSl01.Data;
using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using PODuSl01.Extensions;

namespace PODuSl01
{
 
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IOsoba>();


            list.Add(new Osoba()
            {
                 FirstName = "Jan",
                  LastName = "B"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "A"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "C"
            });

            list.SortByLastName();
            Console.WriteLine();

            Student obj = new Student();

            obj.FirstName = "Mateusz";
            obj.LastName = "Januszowski";
            obj.Semester = "4IID-P";
            obj.year = 2017;
            obj.Uczelnia = "WSIiZ";

            Console.WriteLine(obj.WriteFullNameCollage());
            Console.WriteLine();

            IStudent obj2 = new StudentWSIiZ();
            IStudent obj3 = new StudentWSIiZ();
            IStudent obj4 = new StudentWSIiZ();

            obj2.FirstName = "Jarek";
            obj2.LastName = "Kowalski";
            obj2.Semester = "2IID-P";
            obj2.year = 2015;
            obj2.Uczelnia = "WSIiZ";

            obj3.FirstName = "Mateusz";
            obj3.LastName = "Rak";
            obj3.Semester = "4IID-P";
            obj3.year = 2017;
            obj3.Uczelnia = "WSIiZ";

            obj4.FirstName = "Jan";
            obj4.LastName = "Karlo";
            obj4.Semester = "3IID-P";
            obj4.year = 2016;
            obj4.Uczelnia = "WSIiZ";

            List<IStudent> list2 = new List<IStudent>();
            list2.Add(obj2);
            list2.Add(obj3);
            list2.Add(obj4);

            list2.WypiszOsoby();



        }



    }
}
