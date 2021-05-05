using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace POSL051
{

    public class Student
    {
        public int Id { get; set; }

        public string Nazwisko { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;User id=sl05;Password=P@$$w0rd;";
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
                    sqlCommand.CommandText = "SELECT Nazwisko, Id FROM students"; // WHERE Id = @param1";
                    //sqlCommand.Parameters.Add(new SqlParameter("@param1", 2));

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {



                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");
                        while (reader.Read())
                        {
                            list.Add(new Student()
                            {
                                Id = (int)reader["Id"],
                                Nazwisko = reader["Nazwisko"].ToString()
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

            foreach (var std in list)
            {
                Console.WriteLine($"{std.Id} {std.Nazwisko}");
            }


            Console.ReadLine();
        }

    }
}
