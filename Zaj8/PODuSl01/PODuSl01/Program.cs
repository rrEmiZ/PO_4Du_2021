
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace PODuSl01
{
    

    class Program
    {
        static void Main(string[] args)
        {
            Student Studenciak = new Student();

            try
            {
                Studenciak.AddStudent("a", "b", "w61903", "IID-P-Du");

            }
            catch (ExistingStudentExeption e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Studenciak.UpdateStudent(7, "Kamil", "Ślimak", "w61902", "WSRH");
            }
            catch (ExistingStudentExeption e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Studenciak.AddStudent("f", "g", "w655555", "Idadddu");

            }
            catch (ExistingStudentExeption e)
            {
                Console.WriteLine(e);
            }
            Studenciak.WypiszStudentow();
            //Studenciak.DeleteStudent(8);
            //Studenciak.WypiszStudentow();

            Console.ReadLine();

        }






    }

}
