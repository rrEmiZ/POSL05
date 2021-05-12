using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections.Generic;
namespace zad1
{
    class Student
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
            // Zad 1, 2, 3, 4, 5, 6

            string connectionString = @"Data source= DESKTOP-57VIT9O;database=programowanieOb;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            var list = new List<Student>();
            connection.Open();


            void DodajStudenta(string imie, string nazwisko, string nralbumu, string grupa)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT  NrAlbumu FROM students";
                using (SqlDataReader sr = sqlCommand.ExecuteReader())
                {
                    while (sr.Read())
                    {
                        var x = sr["NrAlbumu"].ToString().Trim();
                        if (x == nralbumu)
                        {
                            Console.WriteLine("BŁĄD!");
                            break;
                        }
                    }
                    sr.Close();
                }
                SqlCommand sql = new SqlCommand();
                sql.Connection = connection;
                sql.CommandText = @"INSERT INTO [dbo].[students]
                   ([Nazwisko]
                   ,[Imie]
                   ,[NrAlbumu]
                   ,[Grupa])
                VALUES
                   (
                    @nazwisko,
                    @imie,
                    @nralbumu, 
                    @grupa
                    )";
                sql.CommandType = CommandType.Text;
                sql.Parameters.AddWithValue("@nazwisko", nazwisko);
                sql.Parameters.AddWithValue("@imie", imie);
                sql.Parameters.AddWithValue("@nralbumu", nralbumu);
                sql.Parameters.AddWithValue("@grupa", grupa);
                int reslt = sql.ExecuteNonQuery();
                Console.WriteLine("Dodano " + reslt + " studenta");
            }
            DodajStudenta("Dawid", "Mielniczek", "90854", "IIDP");

            // zad 9
            void usunStudenta(string nralbumu)
            {

                var sql2 = connection.CreateCommand();
                sql2.CommandText = @"Delete from students where NrAlbumu = @nrAlb";

                sql2.CommandType = CommandType.Text;

                sql2.Parameters.AddWithValue("@nrAlb", nralbumu);

                int reslt = sql2.ExecuteNonQuery();
                Console.WriteLine("Usunięto " + reslt + " studenta");
            }
            usunStudenta("90854");
        }
    }
}
