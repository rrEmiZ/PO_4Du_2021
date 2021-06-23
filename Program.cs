using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Zadanie5
{
    //5.2.Zadania.pdf
    class Program
    {
        static string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";
        static SqlConnection connection = new SqlConnection(connectionString);
        //2. Zaktualizuj program ze skryptu, by pobierane dane były zapisywane do listy typu Student.
        public static List<Student> students = new List<Student>();
        //3. Napisz funkcję „dodajStudenta” oraz skrypt, który doda do bazy danych nowy wpis         studenta.        
        static void dodajStudenta(string album)
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
            cmd.Parameters.AddWithValue("@nazwisko", "kowalsky");
            cmd.Parameters.AddWithValue("@imie", "John");
            cmd.Parameters.AddWithValue("@nrAlb", album);//w666666
            cmd.Parameters.AddWithValue("@grp", "IID-Du");

            int result = cmd.ExecuteNonQuery();
        }

        static void Main(string[] args)
        {
            int i = 0;
            bool walidacja = false;//tu powinno być true, ale coś ta moja walidacja nie działa
            string album = "w666666";
            int Id = 7;
            try
            {
                //to chyba otwiera jak nazwa głosi
                connection.Open();


                {
                    //trzy linijki "ukradzione" z lekcji
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students";// WHERE Id = @param1";
                                                                      //sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));


                    //przestrzeń nazw, co by życie studenta nie było za proste
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //Console.WriteLine("Wiersze znajdujące się w tabeli students: ");
                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = (int)reader[0],
                                NrAlbumu = reader["NrAlbumu"].ToString()
                            });
                            if (students[i].NrAlbumu== album)//ta moja walidacja chyba nie działa, ale idk jak zrobić inaczej
                            {
                                walidacja = false;
                                //6. W przypadku, gdy istnieje taki student funkcja powinna rzucić błąd „ExistingStudentException”.
                                throw new ExistingStudentException("error sie pojawil, problem jest posiadany");
                            }
                            {
                                //Console.WriteLine(
                                //            reader[0].ToString() + " " +
                                //            reader["Nazwisko"].ToString() + " " +
                                //        reader["Imie"].ToString() + " " +
                                //        reader["NrAlbumu"].ToString() + " " +
                                //        reader["Grupa"].ToString());
                            }
                            i++;
                        }
                    }

                    //5. Do funkcji „dodajStudenta” dodaj walidację danych, gdzie funkcja sprawdza czy nie istnieje już student z danym nr albumu.
                    //no totalnie nie wiem jak inaczej "profesionalnie" to zrobić, kaj na laborkach nic Pan nie powiedział, to o tak wymyśliłem
                    if (walidacja)
                    {
                        dodajStudenta(album);
                    }
                    //7. Napisz funkcję „zaktualizujStudenta” oraz skrypt, która zaktualizuje dane studenta, weryfikacja rekordu powinna odbywać się po kluczu głównym.
                    //to nie działa, a ja nie mam bladego pojęcia jak zrobić aktualizację i to jeszcze w funkcji, te laborki to już chyba 4 razy oglądam, tam na prawdę tego nie ma :c
                    //8. Do funkcji „zaktualizujStudenta” dodaj walidację danych, gdzie funkcja sprawdza czy nie istnieje już student z danym nr albumu(w przypadku, gdy chcemy studentowi zmienić nr albumu).
                    //no w tym przypadku to również nie wiem, nie było na laborkach jak robić walidacje
                    sqlCommand.CommandText = "SELECT * FROM students WHERE Id = @param1";
                    sqlCommand.Parameters.Add(new SqlParameter("@param1", Id));
                    var cmd = connection.CreateCommand();
                    cmd.Parameters.AddWithValue("@nrAlb", "w111111");
                    //9. no tu też powinno być, ale nie ma bo nie było na laborkach, to możemy potraktować że nie zrobiłem tych zadań, sql to czarna magia, a jeszcze jak szukam samemu na necie
                    // to pokazuje się jeszcze bardziej czarna magia
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("TO JEST ERROR: ");
                Console.WriteLine(e.Message);
            }
            catch (ApplicationException studentError)
            {
                Console.WriteLine("To jest error studentowy: " + studentError.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //to chyba zamyka jak nazwa głosi
                connection.Close();
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
            }
        }
    }

    public class ExistingStudentException: SystemException
    {
        public ExistingStudentException() : base() { }
        public ExistingStudentException(string message) : base(message) { }
    }

    //1. Stwórz nową klasę „Student”, wg schematu tabeli.
    public class Student
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
    }
}
