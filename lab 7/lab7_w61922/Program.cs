using System;
using System.Collections.Generic;
using System.IO;

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

            //var students = GetStudentsFromDB();
            //Export(students);
            //ExportCsv(students);
            var students= ImportCsv();
            var StudentsImported = Import();
            ImportToDb(students);
            Console.ReadLine();
        }

        //zad 1

        static List<Student> GetStudentsFromDB()
        {
            string connectionString = @"Data source= DESKTOP-57VIT9O;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            var list = new List<Student>();
            try
            {
                connection.Open();

                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students";

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

                            }); ;
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
                {
                    var cell = row.CreateCell(cellIdx++);
                    cell.SetCellValue(student.Grupa);
                }
            }

            using (FileStream stream = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
        }

        //zad 2, 3
        static void ImportToDb(List<Student> students)
        {
            string connectionString = @"Data source= DESKTOP-57VIT9O;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                bool dostepnosc = true;
              
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT  NrAlbumu FROM students";
                foreach (var student in students)
                {
                    using (SqlDataReader sr = sqlCommand.ExecuteReader())
                    {
                        
                        while (sr.Read())
                        {
                            var x = sr["NrAlbumu"].ToString().Trim();
                            if (x == student.NrAlbumu.ToString().Trim())
                            {
                                Console.WriteLine("BŁĄD!");
                                Console.WriteLine("Student o podanym NrAlbumu: " + student.NrAlbumu + "Istnieje w bazie.");
                                dostepnosc = false;
                            }
                            else
                            {
                                
                               var  cmd = connection.CreateCommand();
                                cmd.CommandText = @"INSERT INTO [dbo].[students]
                                  ([Nazwisko]
                                  ,[Imie]
                                  ,[NrAlbumu]
                                  ,[Grupa])
                            VALUES
                                  (@nazw
                                  ,@imie
                                  ,@nrAlb
                                  ,@gr)";
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@nazw", student.Nazwisko);
                                cmd.Parameters.AddWithValue("@imie", student.Imie);
                                cmd.Parameters.AddWithValue("@nrAlb", student.NrAlbumu);
                                cmd.Parameters.AddWithValue("@gr", student.Grupa);

                            }

                           
                        }

                        sr.Close();
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


        }
        static List<Student> Import()
        {
            var students = new List<Student>();
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
                            NrAlbumu = rowObj.GetCell(3).StringCellValue,
                            Grupa = rowObj.GetCell(4).StringCellValue,
                            Id = Convert.ToInt32(rowObj.GetCell(0).NumericCellValue)
                        });
                    }
                }

            }
            return students;
        }
        // zad 4
        static void ExportCsv(List<Student> students)
        {

            using (var sw = new StreamWriter("export.csv"))
            {
                sw.WriteLine("Imie,Nazwisko,NrAlbumu,Grupa");
                foreach (var student in students)
                {
                    sw.WriteLine($"{student.Imie},{student.Nazwisko},{student.NrAlbumu},{student.Grupa}");
                }
            }
        }
        static List<Student> ImportCsv()
        {
            var listImported = new List<Student>();
            using (var sr = new StreamReader("export.csv"))
            {
                var line = sr.ReadLine();
                var splitedHdr = line.Split(',').ToList();
                var idxGrupa = splitedHdr.IndexOf("Grupa");
                var idxImie = splitedHdr.IndexOf("Imie");
                var idxNazwisko = splitedHdr.IndexOf("Nazwisko");
                var idxNrAlbumu = splitedHdr.IndexOf("NrAlbumu");

                line = sr.ReadLine();
                while (line != null)
                {
                    string[] splited = line.Split(',');

                    listImported.Add(new Student()
                    {
                        Imie = splited[idxImie],
                        Nazwisko = splited[idxNazwisko],
                        NrAlbumu = splited[idxNrAlbumu],
                        Grupa = splited[idxGrupa]
                    });
                    line = sr.ReadLine();
                }
                return listImported;
            }
        }
    }
}
