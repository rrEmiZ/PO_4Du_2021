using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PODuSl01
{

    public class Student
    {
        string connectionString = @"Data Source=DESKTOP-RBA97HA\SQLEXPRESS;Initial Catalog=programowanieOb;Integrated Security=True";
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public class ExistingStudentException : Exception { public ExistingStudentException(string message) : base(message) {} }
        public void createStudent(string imie, string nazwisko, string nr_albumu, string grupa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string preQueryString = "SELECT * FROM students where NrAlbumu=@NrAlbumu";
                SqlCommand preCommand = new SqlCommand(preQueryString, connection);
                preCommand.Parameters.AddWithValue("@NrAlbumu", nr_albumu);
                preCommand.Connection.Open();
                Object o = preCommand.ExecuteScalar();
                int count = Convert.ToInt32(o);
                preCommand.Connection.Close();
                if (count>1)
                {
                    throw new ExistingStudentException($"Student o numerze albumu:{nr_albumu} jest już w bazie.");
                }
                else
                {
                    preCommand.Connection.Close();
                    string queryString =
                        "INSERT INTO students (Imie, Nazwisko, NrAlbumu, Grupa) VALUES (@Imie, @Nazwisko, @NrAlbumu, @Grupa)";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Imie", imie);
                    command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@NrAlbumu", nr_albumu);
                    command.Parameters.AddWithValue("@Grupa", grupa);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void deleteStudent(string nr_albumu)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string queryString = "DELETE from students where NrAlbumu=@NrAlbumu";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@NrAlbumu", nr_albumu);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        public void updateStudent(int id, string imie, string nazwisko, string nr_albumu, string grupa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string preQueryString = "SELECT * FROM students where NrAlbumu=@NrAlbumu";
                SqlCommand preCommand = new SqlCommand(preQueryString, connection);
                preCommand.Parameters.AddWithValue("@NrAlbumu", nr_albumu);
                preCommand.Connection.Open();
                Object o = preCommand.ExecuteScalar();
                int count = Convert.ToInt32(o);
                preCommand.Connection.Close();
                if (count > 1)
                {
                    throw new ExistingStudentException($"Student o numerze albumu:{nr_albumu} jest już w bazie.");
                }
                else
                {
                    string queryString =
                        "UPDATE students SET Imie=@Imie, Nazwisko=@Nazwisko, NrAlbumu=@NrAlbumu, Grupa=@Grupa WHERE Id=@id ";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Imie", imie);
                    command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@NrAlbumu", nr_albumu);
                    command.Parameters.AddWithValue("@Grupa", grupa);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }



    }
}
