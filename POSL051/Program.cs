using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace POSL051
{

    public class Student
    {
        public int Id { get; set; }

        public string Nazwisko { get; set; }
        public string Imie { get;  set; }
        public string NrAlbumu { get;  set; }
        public string Grupa { get;  set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudentsFromDB();

           // EXPORT
            using (var sw = new StreamWriter("export.csv"))
            {
                sw.WriteLine("Id,Imie,Nazwisko,NrAlbumu");
                foreach (var student in students)
                {
                    sw.WriteLine($"{student.Id},{student.Imie},{student.Nazwisko},{student.NrAlbumu}");
                }

            }

            var listImported = new List<Student>();
            using (var sr = new StreamReader("export.csv"))
            {
                var line = sr.ReadLine();
                var splitedHdr = line.Split(',').ToList();
                var idxId = splitedHdr.IndexOf("Id"); 
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
                        Id = Convert.ToInt32(splited[idxId])

                    });

                    line = sr.ReadLine();
                }
            }


            Console.ReadLine();
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
