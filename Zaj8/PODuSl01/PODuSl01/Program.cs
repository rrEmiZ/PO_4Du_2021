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
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=true";

            SqlConnection connection = new SqlConnection(connectionString);
            var students = new List<Student>();

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
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            Id = (int)reader["Id"],
                            Imie = reader["Imie"].ToString(),
                            NrAlbumu = reader["NrAlbumu"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Grupa = reader["Grupa"].ToString(),
                        });
                    }
                }

                connection.Close();
            }

            void DodajStudenta(string Imie, string Nazwisko, string NrAlbumu, string Grupa)
            {
                connection.Open();

                if (students.Exists(student => student.NrAlbumu.Trim(' ') == NrAlbumu))
                {
                    throw new ExistingStudentException($"Student o podanym numerze albumu: {NrAlbumu} istnieje już w bazie!!!");
                }
                else {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO [dbo].[students]
                                               ([Nazwisko]
                                               ,[Imie]
                                               ,[NrAlbumu]
                                               ,[Grupa])
                                         VALUES
                                               (@nazwisko
                                               ,@imie
                                               ,@nrAlbumu
                                               ,@group)";

                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);
                    cmd.Parameters.AddWithValue("@group", Grupa);

                    int result = cmd.ExecuteNonQuery();
                }

                connection.Close();
            }

            void ZaaktualizujStudenta(int Id, string Imie, string Nazwisko, string NrAlbumu, string Grupa)
            {
                connection.Open();

                if (students.Exists(student => student.Id == Id))
                {
                    
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"UPDATE [dbo].[students] 
                                        SET [Nazwisko]=@nazwisko,
                                            [Imie]=@imie,
                                            [NrAlbumu]=@nrAlbumu,
                                            [Grupa]=@group
                                       WHERE [Id]=@id;";

                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);
                    cmd.Parameters.AddWithValue("@group", Grupa);
                    int result = cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new ExistingStudentException($"Student o podanym id: {Id} nie istnieje w bazie!!!");
                }
            }

            void UsunStudenta(string NrAlbumu)
            {
                connection.Open();
                if (students.Exists(student => student.NrAlbumu.Trim(' ') == NrAlbumu))
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"DELETE FROM [dbo].[students]
                                            WHERE [NrAlbumu]=@nrAlbumu;";
                    cmd.Parameters.AddWithValue("@nrAlbumu", NrAlbumu);
                    int result = cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new ExistingStudentException($"Student o podanym id: {NrAlbumu} nie istnieje w bazie!!!");
                }
            }
            try
            {
                FetchStudents();
                DodajStudenta("Patryk","Zając","W61955","4IIDP-DU");

                //W aktualizacji dodamy _2 do numeru albumu
                //ZaaktualizujStudenta(4,"Patryk", "Zając", "W61955_2","4IIDP-DU");

                //Usuwanie studenta o podanym w parametrze numerze albumu 
                //UsunStudenta("W61955");
            }
            catch (ExistingStudentException e)
            {
                Console.WriteLine(e.Message);
            }

            //Wypisanie listy studentów
            //foreach (var student in students)
            //{
                //Console.WriteLine($"{student.Id} - {student.NrAlbumu} - {student.Imie}");
            //}
          

        }


    }

}
