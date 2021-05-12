using System;
using System.Data.SqlClient;


namespace PODuSl01
{
    public class ExistingStudentException : Exception
    {
        public ExistingStudentException(string message) : base(message) { }

    }
    public class Student
    {
        string connectionString = @"Data source=DESKTOP-RINIORC\SQLEXPRESS; Initial Catalog=programowanieOb; Integrated Security=True";
        public int Id;
        public string NrAlbumu;
        public void createStudent(string imie, string nazwisko, string nr, string grupa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
               
                SqlCommand cmd = new SqlCommand("SELECT * FROM students where NrAlbumu = @Nr", connection);
                cmd.Parameters.AddWithValue("@Nr", nr);
                cmd.Connection.Open();

                Object rows = cmd.ExecuteScalar();
                int rowsCount = Convert.ToInt32(rows);
                

                cmd.Connection.Close();

                if (rowsCount != 0)
                {
                    throw new ExistingStudentException("User exist.");
                }

                else
                {
                    cmd.Connection.Close();

                    cmd = new SqlCommand("INSERT INTO students (Imie, Nazwisko, NrAlbumu, Grupa) VALUES (@Imie, @Nazwisko, @Nr, @Grupa)",
                        connection);

                    cmd.Parameters.AddWithValue("@Imie", imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    cmd.Parameters.AddWithValue("@Nr", nr);
                    cmd.Parameters.AddWithValue("@Grupa", grupa);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
            }
        }

       

        public void updateStudent(int id, string imie, string nazwisko, string nr, string grupa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM students where NrAlbumu = @Nr", connection);
                cmd.Parameters.AddWithValue("@Nr", nr);
                cmd.Connection.Open();

                Object rows = cmd.ExecuteScalar();
                int rowsCount = Convert.ToInt32(rows);


                cmd.Connection.Close();

                if (rowsCount != 0)
                {
                    throw new ExistingStudentException("User exist.");
                }
                else
                {
                    cmd.Connection.Close();

                    cmd = new SqlCommand("update students set Imie=@Imie, Nazwisko=@Nazwisko, NrAlbumu=@Nr, Grupa=@Grupa WHERE Id=@id",
                        connection);
                    
                    cmd.Parameters.AddWithValue("@Imie", imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    cmd.Parameters.AddWithValue("@Nr", nr);
                    cmd.Parameters.AddWithValue("@Grupa", grupa);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        public void usunStudenta(string nr)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE from students where NrAlbumu=@Nr", connection);
                command.Parameters.AddWithValue("@Nr", nr);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }



    }
}