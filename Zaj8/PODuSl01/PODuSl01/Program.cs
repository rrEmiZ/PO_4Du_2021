using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PODuSl01
{
   
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-RINIORC\SQLEXPRESS;Initial Catalog=programowanieOb;Integrated Security=True";

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
