
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;

namespace PODuSl01
{
    public class Student
    {
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public string Imie { get;  set; }
        public string Nazwisko { get;  set; }
        public string Grupa { get;  set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();

            StringBuilder sb = new StringBuilder();      

            sb.AppendLine("Id,Nazwisko,Imie,Grupa");
            foreach (var item in students)
            {
                sb.AppendLine($"{item.Id},{item.Nazwisko},{item.Imie},{item.NrAlbumu}");
            }

            using (var sw = new StreamWriter("students.csv"))
            {
                sw.Write(sb.ToString());
            }


            var listImported = new List<Student>();

            using (var sr = new StreamReader("students.csv"))
            {
                var line = sr.ReadLine();
                var hdSplitted = line.Split(',').ToList();
                int idxNazw = hdSplitted.IndexOf("Nazwisko");
                int idxImie = hdSplitted.IndexOf("Imie");
                int idxGrp = hdSplitted.IndexOf("Grupa");
                int idxId = hdSplitted.IndexOf("Id");

                line = sr.ReadLine();

                while (line != null)
                {
                    var splited = line.Split(',');

                    listImported.Add(new Student()
                    {
                        Imie = splited[idxImie],
                         Nazwisko = splited[idxNazw],
                         Grupa = splited[idxGrp],
                          Id= Convert.ToInt32(splited[idxId])
                    });

                    line = sr.ReadLine();
                }

            }

            

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
