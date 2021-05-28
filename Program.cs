using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Lab7
{
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
    class Student
    {
        static string connectionString = @"Data source=(LocalDb)\MSSQLLocalDB;database=ProgramowanieObiektoweLAB7;Trusted_Connection=True;MultipleActiveResultSets=true;";
        SqlConnection connection = new SqlConnection(connectionString);

        List<Student> studentList = new List<Student>();
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
        public void AddStudent(string imie, string nazwisko, string nrAlbumu, string grupa)
        {
            int resullt=0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string query = $"select * from Student where NrAlbumu='{nrAlbumu}'"; 
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
                string query = $"select * from Student where NrAlbumu='{nrAlbumu}'";
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
        //Lab8
        public void ExportListOfStudentsCSV()
        {
            //File is located in bin\Debug\netcoreapp3.1\
            try
            {
            string filePath = @"ExportListOfStudentsCSV.csv";
                using StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Nazwisko, Imie, NrAlbumu, Grupa");
                foreach (var item in studentList)
                {
                    sb.AppendLine($"{item.Nazwisko}, {item.Imie}, {item.NrAlbumu}, {item.Grupa}");
                }
                writer.WriteLine(sb.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void ImportStudentDataToDatabase()
        {
            using (var sr = new StreamReader("testCSV.csv"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    string[] vs = line.Split(",");
                    AddStudent(vs[0],vs[1],vs[2],vs[3]);
                    
                    line = sr.ReadLine();
                }
            }
        }
        //Exel File + NPOI
        public void Import()
        {
            try
            {
                using (FileStream stream = new FileStream("test.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    //bool useXlsx = true;
                    IWorkbook workbook;
                    /*if (useXlsx)
                        workbook = new XSSFWorkbook(stream);
                    else*/
                        workbook = new HSSFWorkbook(stream);

                    ISheet sheet = workbook.GetSheet("StudentList");
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        var rowObj = sheet.GetRow(row);
                        if (rowObj != null) //null w przypadku gdy wiersz zawiera tylko puste komórki
                        {
                            var Imie = rowObj.GetCell(0).StringCellValue;
                            var Nazwisko = rowObj.GetCell(1).StringCellValue;
                            var NrAlbumu = rowObj.GetCell(2).StringCellValue;
                            var Grupa = rowObj.GetCell(3).StringCellValue;
                            AddStudent(Imie,Nazwisko,NrAlbumu,Grupa);
                           /* students.Add(new Student()
                            {
                                //Id = Convert.ToInt32(rowObj.GetCell(0).NumericCellValue),
                                Imie = rowObj.GetCell(0).StringCellValue,
                                Nazwisko = rowObj.GetCell(1).StringCellValue,
                                NrAlbumu = rowObj.GetCell(2).StringCellValue,
                                Grupa = rowObj.GetCell(3).StringCellValue
                            }) ;
                           */
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Export()
        {
            bool useXlsx = false;
            IWorkbook workbook;
            if (useXlsx)
                workbook = new XSSFWorkbook();
            else
                workbook = new HSSFWorkbook();

            var sheet = workbook.CreateSheet("StudentList");

            int rowIdx = 0;
            {
                var rowHf = sheet.CreateRow(rowIdx);
                int colIdx = 0;
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
                    cellHd.SetCellValue("NrAlbumu");
                }
                {
                    var cellHd = rowHf.CreateCell(colIdx++);
                    cellHd.SetCellValue("Grupa");
                }
            }
            rowIdx++;

            foreach (var student in studentList)
            {
                var row = sheet.CreateRow(rowIdx);
                int colIdx = 0;

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
                    cell.SetCellValue(student.NrAlbumu);
                }

                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Grupa);
                }
                rowIdx++;
            }

            using (FileStream stream = new FileStream("testEXEL.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student();
            //s.AddStudent("Asia", "Marzec", "w45672", "3IID");
            //s.UpdateStudent(1002, "Asia", "Marzec", "w45673", "3IID");
            //s.DeleteStudent("w456743");
            //s.ShowDataInList();
            //s.ExportListOfStudentsCSV();
            //s.ImportStudentDataToDatabase();
            //s.ShowDataInList();
            s.Import();
            s.ShowDataInList();
            //s.Export();
        }
    }
}
