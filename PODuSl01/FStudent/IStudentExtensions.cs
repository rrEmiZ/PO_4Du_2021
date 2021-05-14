using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PODuSl01.FStudent
{
    public static class IStudentExtensions
    {
        public static void wypiszStudentow(this List<IStudent> stud)
        {
            string connectionString = @"Data source=.\SQLExpress01;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students";


                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stud.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                NrAlbumu = reader["NrAlbumu"].ToString(),
                                Grupa = reader["Grupa"].ToString()
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

            foreach (var student in stud)
            {
                Console.WriteLine($"{student.Id} - {student.Imie} {student.Nazwisko} {student.NrAlbumu} {student.Grupa}");
            }


        }
        public static void dodajStudenta(this List<IStudent> stud, string Nazwisko, string Imie, string NrAlbumu, string Grupa)
        {
            string connectionString = @"Data source=.\SQLExpress01;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            if (sprawdzStudenta(NrAlbumu))
            {
                throw new ExistingStudentExeption( "Student już jest w bazie");
            }
            else
            {
                connection.Open();
                {
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
                                               ,@nrAlb
                                               ,@grp)";

                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlb", NrAlbumu);
                    cmd.Parameters.AddWithValue("@grp", Grupa);

                    int result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }


        }
        public static void zaktualizujStudenta(this List<IStudent> stud, int Id, string Nazwisko, string Imie, string NrAlbumu, string Grupa)
        {
            string connectionString = @"Data source=.\SQLExpress01;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            if (sprawdzStudenta(NrAlbumu, Id))
            {
                throw new ExistingStudentExeption("Numer albumu jest już używany ");
            }
            else
            {
                connection.Open();
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"UPDATE [dbo].[students]
                                        SET [Nazwisko] =@nazwisko
                                            ,[Imie] = @imie
                                            ,[NrAlbumu] = @nrAlb
                                            ,[Grupa] = @grp
                                            WHERE Id=@id";


                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlb", NrAlbumu);
                    cmd.Parameters.AddWithValue("@grp", Grupa);

                    int result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }


        }
        public static void usunStudenta(this List<IStudent> stud, string NrAlbumu)
        {
            string connectionString = @"Data source=.\SQLExpress01;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);      
            connection.Open();
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [dbo].[students]
                                         Where NrAlbumu = @nrAlb";


                cmd.Parameters.AddWithValue("@nrAlb", NrAlbumu);
                int result = cmd.ExecuteNonQuery();
            }
                connection.Close();                     

        }
        public static bool sprawdzStudenta(string NrAlbumu, int Id=-1)
        {
            string connectionString = @"Data source=.\SQLExpress01;database=programowanieOb;Trusted_Connection=True";
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
                if (student.NrAlbumu.Trim(' ') == NrAlbumu && student.Id!=Id)
                    return true;
            }
            return false;
        }


    }
}
