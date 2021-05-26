
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Reflection;

namespace PODuSl01
{
    public class Student
    {
      

        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Grupa { get; set; }

        public void Hello()
        {
            Console.WriteLine("Imie - " + Imie);
        }
    }



    class Program
    {




        static void Main(string[] args)
        {
            var studs = GetStudents();

            foreach (var stud in studs)
            {
                stud.PrintProps();
            }





            ////bez refleksji
            //Student student = new Student();
            //student.Imie = "TETT";
            //student.Hello();


        //    var type = Type.GetType("PODuSl01.Student");
        //    object obj = Activator.CreateInstance(type);


        //    //PropertyInfo[] props = type.GetProperties();

        //  //  prop.SetValue(obj, "Testowe");

        //   // Console.WriteLine(prop.GetValue(obj));

        //    MethodInfo methodInfo = type.GetMethod("Hello");

        //    methodInfo.Invoke(obj, null);



        //    dynamic d = new Student();
        //    Console.WriteLine(d.GetType());
        //    //Typ zmiennej d to: System.Int32
        //    d.Hello();

        //d = "Napis";

        

        //    //Teraz typ zmiennej d to: Systems.String
        //  //  d--; //BŁĄD zmienna jest aktualnie typu String
        //   // Console.ReadLine();

        //   // var zmienna = 10;
        //  //  Console.WriteLine(zmienna.GetType());
        //    //wyświetli System.Int32
        //   // zmienna = "napis"; // BŁĄD zmienna jest typu int



        //    object zmienna = 10;
        //    Console.WriteLine(zmienna.GetType());
        //    //wyświetli System.Int32
 
        //    zmienna = (int)zmienna + 1; //rzutowanie
        //    zmienna = "napis"; // OK
        //    Console.WriteLine(zmienna.GetType());

        //    var xx = ((string)zmienna).Length;

            //wyświetli System.String



            //            //z użyciem refleksji
            //             //string powinien zawierać
            //namespace naszej klasy
            //var foo = Activator.CreateInstance(type); //inicjalizacja obiektu
            //    określonego typu
            //MethodInfo inf = type.GetMethod("hello");
            //    inf.Invoke(foo); // jako drugi parametr metoda Invoke przyjmuje tablicę
            //Object[] są to parametry metody hello.

            Console.ReadLine();

        }




        static List<Student> GetStudents()
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

            SqlConnection connection = new SqlConnection(connectionString);
            var students = new List<Student>();
            try
            {
                connection.Open();

                //{
                //    var cmd = connection.CreateCommand();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = @"INSERT INTO [dbo].[students]
                //                               ([Nazwisko]
                //                               ,[Imie]
                //                               ,[NrAlbumu]
                //                               ,[Grupa])
                //                         VALUES
                //                               (@nazwisko
                //                               ,@imie
                //                               ,@nrAlb
                //                               ,@grp)";

                //    cmd.Parameters.AddWithValue("@nazwisko", "Kowalsky");
                //    cmd.Parameters.AddWithValue("@imie", "John");
                //    cmd.Parameters.AddWithValue("@nrAlb", "w666666");
                //    cmd.Parameters.AddWithValue("@grp", "IID-Du");

                //    int result = cmd.ExecuteNonQuery();
                //}

                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students";// WHERE Id = @param1" ;
                                                                      // sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));


                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");

                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                NrAlbumu = reader["NrAlbumu"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Grupa = reader["Grupa"].ToString()
                            });

                            // Console.WriteLine(
                            //     reader[0].ToString() + " " +
                            //     reader["Nazwisko"].ToString() + " " +
                            //reader["Imie"].ToString() + " " +
                            //reader["NrAlbumu"].ToString() + " " +
                            //reader["Grupa"].ToString());
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();

            }
            return students;
        }


    }

}
