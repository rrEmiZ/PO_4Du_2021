using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace PODuSl01
{
    public class Student
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
    }

    public class StudentQueries
    {
        SqlCommand sqlCommand;
        public List<Student> students { get; set; }
        public SqlConnection connection { get; set; }

        public StudentQueries(string connectionString)
        {
            sqlCommand = new SqlCommand();
            connection = new SqlConnection(connectionString); 
            students = new List<Student>();
            sqlCommand.Connection = connection;
        }

        public void GetStudents()
        {
            sqlCommand.CommandText = "SELECT * FROM students";

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                students.Clear();
                while (reader.Read())
                {
                    students.Add(new Student()
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

        public void DodajStudenta(Student student)
        {
            if (students.Any(p => p.NrAlbumu.Trim(' ') == student.NrAlbumu))
            {
                throw new ExistingStudentException($"Student o numerze albumu {student.NrAlbumu} został już wcześniej dodany");
            }
            else
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = @"INSERT INTO [dbo].[students]
                                                    ([Nazwisko]
                                                    ,[Imie]
                                                    ,[NrAlbumu]
                                                    ,[Grupa])
                                              VALUES
                                                    (@nazwisko
                                                    ,@imie
                                                    ,@nrAlb
                                                    ,@grp)";

                sqlCommand.Parameters.AddWithValue("@nazwisko", student.Nazwisko);
                sqlCommand.Parameters.AddWithValue("@imie", student.Imie);
                sqlCommand.Parameters.AddWithValue("@nrAlb", student.NrAlbumu);
                sqlCommand.Parameters.AddWithValue("@grp", student.Grupa);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine($"Dodano studenta o numerze albumu {student.NrAlbumu}");
                }
                GetStudents();
            }
        }

        public void ZaktualizujStudenta(Student student)
        {
            if (students.Any(p => p.NrAlbumu.Trim(' ') == student.NrAlbumu))
            {
                throw new ExistingStudentException($"Student o numerze albumu {student.NrAlbumu} już istnieje");
            }
            else
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = @"UPDATE [dbo].[students]
                                            SET [Nazwisko]=@nazwisko,
                                                [Imie]=@imie,
                                                [NrAlbumu]=@nrAlb,
                                                [Grupa]=@grp
                                            WHERE [Id]=@id;";

                sqlCommand.Parameters.AddWithValue("@id", student.Id);
                sqlCommand.Parameters.AddWithValue("@nazwisko", student.Nazwisko);
                sqlCommand.Parameters.AddWithValue("@imie", student.Imie);
                sqlCommand.Parameters.AddWithValue("@nrAlb", student.NrAlbumu);
                sqlCommand.Parameters.AddWithValue("@grp", student.Grupa);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.RecordsAffected != 0) Console.WriteLine($"Zaktualizowano studenta o numerze id {student.Id}");
                    else throw new ExistingStudentException($"Student o numerze id {student.Id} nie istnieje");
                }
                GetStudents();
            }
        }

        public void UsunStudenta(string nrAlbumu)
        {
            if (students.Any(p => p.NrAlbumu.Trim(' ') == nrAlbumu))
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = @"DELETE FROM [dbo].[students]
                                            WHERE [NrAlbumu]=@nrAlb;";

                sqlCommand.Parameters.AddWithValue("@nrAlb", nrAlbumu);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine($"Usunięto studenta o numerze albumu {nrAlbumu}");
                }
                GetStudents();
            }
            else
            {
                throw new ExistingStudentException($"Student o numerze albumu {nrAlbumu} nie istnieje");
            }
        }
    }

    public class ExistingStudentException : Exception
    {
        public ExistingStudentException(string message) 
            : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";
            StudentQueries SQ = new StudentQueries(connectionString);
            
            try
            {
                SQ.connection.Open();
                SQ.GetStudents();

                SQ.DodajStudenta(new Student
                {
                    Nazwisko = "Kowalski",
                    Imie = "Marcin",
                    NrAlbumu = "w12345",
                    Grupa = "TR23"
                });
                SQ.ZaktualizujStudenta(new Student
                {
                    Id = 3,
                    Nazwisko = "Kowalskiy",
                    Imie = "Marcin",
                    NrAlbumu = "w12346",
                    Grupa = "TR23"
                });
                SQ.UsunStudenta("w12346");
            }
            catch (ExistingStudentException e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                SQ.connection.Close();
            }

            Console.WriteLine("\nWiersze znajdujące się w tabeli students:");
            foreach (var student in SQ.students)
            {
                Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
            }
            Console.ReadLine();
        }
    }
}
