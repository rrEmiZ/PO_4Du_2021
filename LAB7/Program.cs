using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    class Student
    {
        static string connectionString = @"Data source=(LocalDb)\MSSQLLocalDB;database=ProgramowanieObiektoweLAB7;Trusted_Connection=True;MultipleActiveResultSets=true;";
        SqlConnection connection = new SqlConnection(connectionString);

        List<Student> studentList = new List<Student>();
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
        public class ExistingStudentException : Exception
        {
            public ExistingStudentException()
            {
                Console.WriteLine($"Student exist");
            }

            public ExistingStudentException(string message)
                : base(message)
            {
                Console.WriteLine($"Student exist");
            }

            public ExistingStudentException(string message, Exception inner)
                : base(message, inner)
            {
                Console.WriteLine($"Student exist");
            }
        }
        public class CreateStudentException : Exception
        {
            public CreateStudentException()
            {
                Console.WriteLine($"Create student\n tego nrAlbumu nie ma w bazie danych");
            }

            public CreateStudentException(string message)
                : base(message)
            {
                Console.WriteLine($"Create student\n tego nrAlbumu nie ma w bazie danych");
            }

            public CreateStudentException(string message, Exception inner)
                : base(message, inner)
            {
                Console.WriteLine($"Create student\n tego nrAlbumu nie ma w bazie danych");
            }
        }
        public void AddStudent(string imie, string nazwisko, string nrAlbumu, string grupa)
        {
            int resullt=0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string query = $"select * from Student where NrAlbumu = '{nrAlbumu}'"; 
                cmd.CommandText = query;
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text; //(Imie, Nazwisko, NrAlbumu, Grupa) 
                        string query1 = "INSERT INTO Student VALUES (@imie, @nazwisko, @nrAlbumu, @grupa);";
                        sqlCommand.CommandText = query1;
                        sqlCommand.Connection = connection;

                        SqlParameter parm = new SqlParameter("@imie", imie);
                        sqlCommand.Parameters.Add(parm);

                        SqlParameter parm1 = new SqlParameter("@nazwisko", nazwisko);
                        sqlCommand.Parameters.Add(parm1);

                        SqlParameter parm2 = new SqlParameter("@nrAlbumu", nrAlbumu);
                        sqlCommand.Parameters.Add(parm2);

                        SqlParameter parm3 = new SqlParameter("@grupa", grupa);
                        sqlCommand.Parameters.Add(parm3);
                        resullt = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine($"Result: {resullt}");
                    }
                }
                else
                {
                    throw new ExistingStudentException();
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            finally
            {
                
                connection.Close();
            }
        
        }
        public void UpdateStudent(int id,string imie, string nazwisko, string nrAlbumu, string grupa)
        {
            int resullt = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string query = $"select * from Student where NrAlbumu = '{nrAlbumu}'";
                cmd.CommandText = query;
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text; //(Imie, Nazwisko, NrAlbumu, Grupa) 
                        string query1 = "UPDATE Student SET Imie=@imie, Nazwisko=@nazwisko, NrAlbumu=@nrAlbumu, Grupa=grupa where Id=@id";
                        sqlCommand.CommandText = query1;
                        sqlCommand.Connection = connection;

                        SqlParameter parm = new SqlParameter("@imie", imie);
                        sqlCommand.Parameters.Add(parm);

                        SqlParameter parm1 = new SqlParameter("@nazwisko", nazwisko);
                        sqlCommand.Parameters.Add(parm1);

                        SqlParameter parm2 = new SqlParameter("@nrAlbumu", nrAlbumu);
                        sqlCommand.Parameters.Add(parm2);

                        SqlParameter parm3 = new SqlParameter("@grupa", grupa);
                        sqlCommand.Parameters.Add(parm3);

                        SqlParameter parm4 = new SqlParameter("@id", id);
                        sqlCommand.Parameters.Add(parm4);

                        resullt = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine($"Result: {resullt}");
                    }
                }
                else
                {
                    throw new CreateStudentException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            finally
            {

                connection.Close();
            }

        }
        public void DeleteStudent(string nrAlbumu)
        {
            int resullt = 0;
            try
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.Text; //(NrAlbumu) 
                    string query1 = "Delete from Student where NrAlbumu=@nrAlbumu";
                    sqlCommand.CommandText = query1;
                    sqlCommand.Connection = connection;

                    SqlParameter parm = new SqlParameter("@nrAlbumu", nrAlbumu);
                    sqlCommand.Parameters.Add(parm);

                    resullt = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Result: {resullt}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            finally
            {

                connection.Close();
            }

        }
        public void ShowDataInList()
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Student";
                /*SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine("Wiersze znajdujące się w tabeli students:"); 
                while (reader.Read()) 
                { 
                    Console.WriteLine(reader["Nazwisko"].ToString() + "   " + reader["Imie"].ToString() + "   " + reader["NrAlbumu"].ToString() + "   " + reader["Grupa"].ToString()); 
                }*/
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        studentList.Add(new Student
                        {
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            NrAlbumu = reader["NrAlbumu"].ToString(),
                            Grupa = reader["Grupa"].ToString()
                        });
                    }
                    reader.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            finally
            {
                foreach (var item in studentList)
                {
                    Console.WriteLine($"\n{item.Imie} {item.Nazwisko} {item.NrAlbumu} {item.Grupa}");
                }
                connection.Close();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student();
            s.AddStudent("Asia", "Marzec", "w45672", "3IID");
            //s.UpdateStudent(1002, "Asia", "Marzec", "w45673", "3IID");
            //s.DeleteStudent("w45672");
            s.ShowDataInList();
        }
    }
}
