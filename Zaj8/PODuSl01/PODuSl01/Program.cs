
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace PODuSl01
{
    public class Student
    {
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
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
                    sqlCommand.CommandText = "SELECT NrAlbumu, Id FROM students";// WHERE Id = @param1" ;
                                                                      // sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));


                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");

                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                NrAlbumu = reader["NrAlbumu"].ToString()
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

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
            }


            Console.ReadLine();

        }






    }

}
