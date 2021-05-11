
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
            string connectionString = @"Data Source=DESKTOP-RBA97HA\SQLEXPRESS;Initial Catalog=programowanieOb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            var students = new List<Student>();
            try
            {
                connection.Open();
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT NrAlbumu, Id FROM students";
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                NrAlbumu = reader["NrAlbumu"].ToString()
                            });
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

            var studentTest = new Student();
           // studentTest.createStudent("Radosław", "Micał", "w61957", "4IIDPdu");
           // studentTest.createStudent("Radosław", "Micał", "w61957", "4IIDPdu");
           // studentTest.updateStudent(11,"Radosław222", "Micał", "w61957", "4IIDPdu");
            studentTest.deleteStudent("w61957");

            Console.ReadLine();

        }






    }

}
