
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace PODuSl01
{
    public class Student
    {
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Grupa { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();


             Export(students);

            //var studentsImported = Import();


            Console.ReadLine();

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
                        if (rowObj != null) //null w przypadku gdy wiersz zawiera      tylko puste komórki
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
            bool useXlsx = false;
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

            using (FileStream stream = new FileStream("test.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
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

                //{
                //    var cmd = connection.CreateCommand();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = @"INSERT INTO [dbo].[students]
                //                               ([Nazwisko]
                //                               ,[Imie]
                //                               ,[NrAlbumu]
                //                               ,[Grupa])
                //                         VALUES
                //                               (@nazwisko
                //                               ,@imie
                //                               ,@nrAlb
                //                               ,@grp)";

                //    cmd.Parameters.AddWithValue("@nazwisko", "Kowalsky");
                //    cmd.Parameters.AddWithValue("@imie", "John");
                //    cmd.Parameters.AddWithValue("@nrAlb", "w666666");
                //    cmd.Parameters.AddWithValue("@grp", "IID-Du");

                //    int result = cmd.ExecuteNonQuery();
                //}

                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students";// WHERE Id = @param1" ;
                                                                      // sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));


                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");

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

                            // Console.WriteLine(
                            //     reader[0].ToString() + " " +
                            //     reader["Nazwisko"].ToString() + " " +
                            //reader["Imie"].ToString() + " " +
                            //reader["NrAlbumu"].ToString() + " " +
                            //reader["Grupa"].ToString());
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
            return students;
        }


    }

}
