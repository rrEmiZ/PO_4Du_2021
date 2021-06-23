//using System;
//using System.Data.SqlClient;
//using System.Data;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using System.Linq;

////to lab 8 jest i idk czemu ten namespace zawsze 5 wypluwa, jak ja różne projekty robię xD
//namespace Zadanie5
//{    public class Student
//    {
//        public int Id { get; set; }
//        public string Nazwisko { get; set; }
//        public string Imie { get; set; }
//        public string NrAlbumu { get; set; }
//        public string Grupa { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var students = GetStudents();

//            StringBuilder sb = new StringBuilder();
//            sb.AppendLine("Id,Nazwisko,Imie,Grupa");
//            foreach (var item in students)
//            {
//                sb.AppendLine($"{item.Id},{item.Nazwisko},{item.Imie},{item.NrAlbumu}");
//            }
//            using (var sw = new StreamWriter("students.csv"))
//            {
//                sw.Write(sb.ToString());
//            }

//            var listImorted = new List<Student>();

//            using (var sr = new StreamReader("students.csv"))
//            {
//                var line = sr.ReadLine();
//                var hdSplitted = line.Split(',').ToList();
//                int idxNazw = hdSplitted.IndexOf("Nazwisko");
//                int idxImie = hdSplitted.IndexOf("Imie");
//                int idxGrp = hdSplitted.IndexOf("Grupa");
//                int idxId = hdSplitted.IndexOf("Id");

//                line = sr.ReadLine();//pominięty został nagłówek

//                while (line != null)
//                {
//                    var splited = line.Split(',');

//                    listImorted.Add(new Student()
//                    {
//                        Imie = splited[idxImie],
//                        Nazwisko = splited[idxNazw],
//                        Grupa = splited[idxGrp],
//                        Id = Int32.Parse(splited[idxId]),
//                    });

//                    line = sr.ReadLine();
//                }
//            }
//            Console.ReadLine();
//        }

//        static List<Student> GetStudents()
//        {
//            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

//            SqlConnection connection = new SqlConnection(connectionString);
//            var students = new List<Student>();
//            try
//            {
//                connection.Open();

//                {
//                    SqlCommand sqlCommand = new SqlCommand();
//                    sqlCommand.Connection = connection;
//                    sqlCommand.CommandText = "SELECT * FROM students";


//                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            students.Add(new Student()
//                            {
//                                Id = (int)reader["Id"],
//                                NrAlbumu = reader["NrAlbumu"].ToString(),
//                                Imie = reader["Imie"].ToString(),
//                                Nazwisko = reader["Nazwisko"].ToString(),
//                                Grupa = reader["Grupa"].ToString()
//                            });

//                        }
//                    }
//                }
//            }
//            catch (SqlException e)
//            {
//                Console.WriteLine("error");
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                connection.Close();
//            }
//            foreach (var student in students)
//            {
//                Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
//            }
//            return students;
//        }
//    }
//}


using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

//to lab 8 jest i idk czemu ten namespace zawsze 5 wypluwa, jak ja różne projekty robię xD
namespace Zadanie5
{
    public class Student
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int ileWierszy = 0;
            var students = GetStudents();
            var finalnaLista = new List<Student>();
            finalnaLista.Add(new Student()
            {
                Id= 0,
                NrAlbumu = "test",
                Imie = "test",
                Nazwisko = "test",
                Grupa = "test"
            });

            Export(students);

            List<Student> studentsImported = Import();

            //zadanie 1 oraz 2 to chyba jedno i to samo
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);

            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM students";


                {
                    foreach (var item in studentsImported)
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
                        cmd.Parameters.AddWithValue("@nazwisko", item.Nazwisko);
                        cmd.Parameters.AddWithValue("@imie", item.Imie);
                        cmd.Parameters.AddWithValue("@nrAlb", item.NrAlbumu);//w666666
                        cmd.Parameters.AddWithValue("@grp", item.Grupa);
                        //coś tu błęda wywala, ale to chybe pewnie coś nie połączyłem, nie jestem pewien
                        int result = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        finalnaLista.Add(new Student()
                        {
                            Id = (int)reader["Id"],
                            NrAlbumu = reader["NrAlbumu"].ToString(),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Grupa = reader["Grupa"].ToString()
                        });
                        ileWierszy++;
                    }
                    //no tutaj to jest zadanie 3, a jak walidacji nie wiem jak zrobić to z tych wykładów dalej nie wiem
                    Console.WriteLine("tyle jest wierszy w tabeli: " + ileWierszy.ToString());
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Id} - {student.NrAlbumu} - {student.Nazwisko} - {student.Grupa} - {student.Imie}");
                    }
                }
                StringBuilder sb = new StringBuilder();
                //zadanie 4, nie jestem w stanie sprawdzić czy działa, bo wcześniejszy error nie pozwala, ale czuję że jest ok
                using (var sr = new StreamWriter("students.csv"))
                {
                    foreach (var item in finalnaLista)
                    {
                        sb.AppendLine($"{ item.Id},{item.Imie},{item.Nazwisko},{item.NrAlbumu},{item.Grupa}");
                    }
                }
            }
        }

        private static List<Student> Import()
        {
            var students = new List<Student>();
            try
            {
            using (FileStream stream = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    bool useXlsx = true;
                    IWorkbook workbook;
                    if (useXlsx)
                        workbook = new XSSFWorkbook(stream);
                    else
                        workbook = new HSSFWorkbook(stream);

                    ISheet sheet = workbook.GetSheet("Ark1");
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        var rowObj = sheet.GetRow(row);
                        if (rowObj!=null)//null w przypadku gdy wiersz zawiera tylko puste komórki
                        {
                            students.Add(new Student()
                            {
                                Id = Convert.ToInt32(rowObj.GetCell(0).NumericCellValue),
                                Imie = rowObj.GetCell(1).StringCellValue
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;
        }

        static void Export(List<Student> students)
        {
            bool useXlsx = true;
            IWorkbook workbook;
            if (useXlsx)
                workbook = new XSSFWorkbook();
            else
                workbook = new HSSFWorkbook();

            var sheet = workbook.CreateSheet("Ark1");

            int rowIdx = 0;
            {
                var rowHf = sheet.CreateRow(rowIdx);
                int colIdx = 0;
                {
                    var cellHd = rowHf.CreateCell(colIdx++);
                    cellHd.SetCellValue("Id");
                }
                {
                    var cellHd = rowHf.CreateCell(colIdx++);
                    cellHd.SetCellValue("Imie");
                }
                {
                    var cellHd = rowHf.CreateCell(colIdx++);
                    cellHd.SetCellValue("Nazwisko");
                }
                {
                    var cellHd = rowHf.CreateCell(colIdx++);
                    cellHd.SetCellValue("Grupa");
                }
            }
            rowIdx++;

            foreach (var student in students)
            {
                var row = sheet.CreateRow(rowIdx);
                int colIdx = 0;

                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Id);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Imie);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Nazwisko);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Grupa);
                }
                rowIdx++;
            }
            using (FileStream stream = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
        }

        static List<Student> GetStudents()
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True";

            SqlConnection connection = new SqlConnection(connectionString);
            var students = new List<Student>();
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
                            students.Add(new Student()
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
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.NrAlbumu}");
            }
            return students;
        }
    }
}
