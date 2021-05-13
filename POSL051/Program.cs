using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace POSL051
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
            var students = GetStudentsFromDB();

            //Export(students);

            var studentsImported = Import();


            Console.ReadLine();
        }
        //test
        private static List<Student> Import()
        {
            var students = new List<Student>();
            try
            {
                using (FileStream stream = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    IWorkbook workbook;
                    bool useXlsx = true;

                    if (useXlsx)
                        workbook = new XSSFWorkbook(stream);
                    else
                        workbook = new HSSFWorkbook(stream);

                    var sheet = workbook.GetSheet("Ark1");

                    for (int row = 0; row <= sheet.LastRowNum; row++)
                    {
                        var rowObj = sheet.GetRow(row);
                        if (rowObj != null)
                        {
                            students.Add(new Student()
                            {
                                Imie = rowObj.GetCell(1).StringCellValue,
                                Nazwisko = rowObj.GetCell(2).StringCellValue,
                                Id = Convert.ToInt32(rowObj.GetCell(0).NumericCellValue)
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

        private static void Export(List<Student> studens)
        {
            IWorkbook workbook;
            bool useXlsx = true;

            if (useXlsx)
                workbook = new XSSFWorkbook();
            else
                workbook = new HSSFWorkbook();

            var sheet = workbook.CreateSheet("Ark1");

            var rowIdx = 0;

            foreach (var student in studens)
            {
                var row = sheet.CreateRow(rowIdx++);
                int cellIdx = 0;
                {
                    var cell = row.CreateCell(cellIdx++);
                    cell.SetCellValue(student.Id);
                }
                {
                    var cell = row.CreateCell(cellIdx++);
                    cell.SetCellValue(student.Imie);
                }
                {
                    var cell = row.CreateCell(cellIdx++);
                    cell.SetCellValue(student.Nazwisko);
                }
                {
                    var cell = row.CreateCell(cellIdx++);
                    cell.SetCellValue(student.NrAlbumu);
                }
            }

            using (FileStream stream = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
        }

        static List<Student> GetStudentsFromDB()
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;User id=sl05;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            var list = new List<Student>();
            try
            {
                connection.Open();

                //Dodawanie
                //           {
                //               var cmd = connection.CreateCommand();
                //               cmd.CommandText = @"INSERT INTO [dbo].[students]
                //      ([Nazwisko]
                //      ,[Imie]
                //      ,[NrAlbumu]
                //      ,[Grupa])
                //VALUES
                //      (@nazw
                //      ,@imie
                //      ,@nrAlb
                //      ,@gr)";
                //               cmd.CommandType = CommandType.Text;
                //               cmd.Parameters.AddWithValue("@nazw", "Jońca");
                //               cmd.Parameters.AddWithValue("@imie", "Jakub");
                //               cmd.Parameters.AddWithValue("@nrAlb", "w50038");
                //               cmd.Parameters.AddWithValue("@gr", "IIDP");

                //               int reslt = cmd.ExecuteNonQuery();



                //           }


                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students"; // WHERE Id = @param1";
                    //sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {



                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");
                        while (reader.Read())
                        {
                            list.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                NrAlbumu = reader["NrAlbumu"].ToString(),
                                Grupa = reader["Grupa"].ToString()
                            });


                            // Console.WriteLine(
                            //       reader[0].ToString() + " " +
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
            return list;
        }


    }
}
