
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
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Grupa { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Data Source=LAPTOP-1TBJF8P6\SQLEXPRESS;Initial Catalog=programowanieOb;Integrated Security=True";
            
            SqlConnection connection = new SqlConnection(connectionString);
            var students = new List<Student>();
            
            
            void DodajStudenta(string Imie, string Nazwisko, string NrAlbumu, string Grupa)
            {
                connection.Open();

                if (students.Exists(student => student.NrAlbumu.Trim(' ') == NrAlbumu))
                {
                    throw new ExistingStudentException($"Student o numerze albumu:{NrAlbumu} jest już w bazie.");
                }
                else
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO [dbo].[students]
                                                              ([Nazwisko],[Imie],[NrAlbumu],[Grupa]) VALUES 
                                                               (@nazwisko, @imie, @nrAlbumu,@grupa)";

                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);
                    cmd.Parameters.AddWithValue("@grupa", Grupa);

                    int result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

            void ZaktualizujStudenta(int Id, string Imie, string Nazwisko, string NrAlbumu, string Grupa)
            {
                connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE students set Imie=@imie, Nazwisko=@nazwisko, NrAlbumu=@nrAlbumu, Grupa=@grupa WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);
                    cmd.Parameters.AddWithValue("@grupa", Grupa);
                    cmd.Parameters.AddWithValue("@id", Id);

                    int result = cmd.ExecuteNonQuery();
                
                connection.Close();
            }

            void UsunStudenta(string NrAlbumu)
            {
                connection.Open();


                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM students WHERE NrAlbumu=@nrAlbumu";
                cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);

                int result = cmd.ExecuteNonQuery();

                connection.Close();
            }

            void FetchStudents()
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT NrAlbumu, Id, Imie, Nazwisko, Grupa FROM students"
                };

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        students.Add(new Student()
                        {
                            Id = (int)reader["Id"],
                            Imie = reader["Imie"].ToString(),
                            NrAlbumu=reader["NrAlbumu"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Grupa=reader["Grupa"].ToString(),
                        }) ;
                    }
                }
                connection.Close();
            }

           FetchStudents();

           DodajStudenta("Paweł", "Misiewicz", "w62252", "4IIDP-Du");
           //ZaktualizujStudenta(6, "Paweł", "Misiewicz", "w62230", "4IIDP-Du");
           //UsunStudenta("w62230");

            
            
            foreach (var student in students)
            {
               Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
            }


            Console.ReadLine();

        }


    }

    public class ExistingStudentException : Exception
    {
        public ExistingStudentException(string message) : base(message)
        {

        }
    }
}
