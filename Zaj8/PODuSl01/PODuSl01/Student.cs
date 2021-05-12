using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PODuSl01
{
    public class Student
    {
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Grupa { get; set; }
        private List<Student> ListaStudentow;
        public void AddStudent(string Imie, string Nazwisko, string NumerAlbumu, string Grupa)
        {
            if (CheckExisting(NumerAlbumu))
            {
                throw new ExistingStudentExeption("W bazie istnieje już student o takim numerze albumu");
            }
            else
            {
                string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionString);
                var students = new List<Student>();

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
                    cmd.Parameters.AddWithValue("@nrAlb", NumerAlbumu);
                    cmd.Parameters.AddWithValue("@grp", Grupa);

                    int result = cmd.ExecuteNonQuery();
                }





                connection.Close();



            }
        }
        public void WypiszStudentow()
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

            SqlConnection connection = new SqlConnection(connectionString);
            ListaStudentow = new List<Student>();
            try
            {
                connection.Open();

                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT NrAlbumu, Id, Imie, Nazwisko, Grupa FROM students";


                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            ListaStudentow.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                NrAlbumu = reader["NrAlbumu"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
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

            foreach (var student in ListaStudentow)
            {
                Console.WriteLine($"{student.Id} - {student.NrAlbumu} {student.Imie} {student.Nazwisko} {student.Grupa}");
            }

        }
        public bool CheckExisting(string NumerAlbumu)
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

            SqlConnection connection = new SqlConnection(connectionString);
            ListaStudentow = new List<Student>();
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
                            ListaStudentow.Add(new Student()
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

            for (int i = 0; i < ListaStudentow.Count; i++)
            {
                string bufor = ListaStudentow[i].NrAlbumu.Trim(' ');
                if (NumerAlbumu == bufor)
                {
                    return true;
                }
            }
            return false;
        }
        public void UpdateStudent(int Id, string Imie, string Nazwisko, string NumerAlbumu, string Grupa)
        {
            if (CheckExisting(NumerAlbumu))
            {

                throw new ExistingStudentExeption("W bazie istnieje już student o takim numerze albumu");
            }
            else
            {
                string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionString);
                var students = new List<Student>();

                connection.Open();
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"Update [dbo].[students]
                                         Set Imie = @imie, Nazwisko = @nazwisko, Grupa = @grp, NrAlbumu = @nrAlb
                                         Where Id = @id";

                    cmd.Parameters.AddWithValue("@nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@imie", Imie);
                    cmd.Parameters.AddWithValue("@nrAlb", NumerAlbumu);
                    cmd.Parameters.AddWithValue("@grp", Grupa);
                    cmd.Parameters.AddWithValue("@id", Id);

                    int result = cmd.ExecuteNonQuery();
                }





                connection.Close();




            }
        }
        public void DeleteStudent(int Id)
        {           
                string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionString);
                var students = new List<Student>();

                connection.Open();
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"DELETE FROM [dbo].[students]
                                         Where Id = @id";
                    cmd.Parameters.AddWithValue("@id", Id);

                    int result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            
        }
    }
}


