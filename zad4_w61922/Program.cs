using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime;


namespace zad4_w61922
{
    public class Indicator
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Country
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Statistic
    {
        public Indicator Indicator { get; set; }
        public Country Country { get; set; }
        public string Value { get; set; }
        public string Decimal { get; set; }
        public string Date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Statistic>();

            using (var sr = new StreamReader("db.json"))
            {
                var line = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Statistic>>(line);

            }
            Country con;
            double polution = 0;
            double polution2 = 0;
            Console.WriteLine("Witaj w prostym programie: ");
            Console.WriteLine("[1] - Różnica populacja pomiedzy 1970 a 2000 w Indii ");
            Console.WriteLine("[2] - Różnica populacja pomiedzy 1965 a 2010 w USA ");
            Console.WriteLine("[3] - Różnica populacja pomiedzy 1980 a 2018 w Chinach ");
            Console.WriteLine("[4] - Populacja z wskazanego kraju oraz roku");
            Console.WriteLine("[5] - Różnica populacja dla wskazanego zakresu lat i kraju ");
            Console.WriteLine("[6] - Procentowa wzrost populacji dla kazdego kraju ");
            Console.WriteLine("[Wpisanie dowolnie innej wartości] - Wyjśćie z programu ");
            Console.WriteLine("Wybierz która operacje wybierasz ");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":

                    for (int i = 0; i < list.Count; i++)
                    {
                        con = list[i].Country;
                        if (con.Value == "India" && list[i].Date == "1970")
                        {

                            polution = int.Parse(list[i].Value);
                        }
                        else if (con.Value == "India" && list[i].Date == "2000")
                        {
                            polution2 = int.Parse(list[i].Value);
                        }
                    }
                    Console.WriteLine("Roznica ludności wynosi: " + (polution2 - polution));
                    break;
                case "2":
                    for (int i = 0; i < list.Count; i++)
                    {
                        con = list[i].Country;

                        if (con.Value == "United States" && list[i].Date == "1965")
                        {

                            polution = int.Parse(list[i].Value);
                        }
                        else if (con.Value == "United States" && list[i].Date == "2010")
                        {
                            polution2 = int.Parse(list[i].Value);
                        }
                    }
                    Console.WriteLine("Roznica ludnosci wynosi: " + (polution2 - polution) + " wzgledem 2010r.");
                    break;
                case "3":
                    for (int i = 0; i < list.Count; i++)
                    {
                        con = list[i].Country;
                        if (con.Value == "China" && list[i].Date == "1980")
                        {

                            polution = int.Parse(list[i].Value);
                        }
                        else if (con.Value == "China" && list[i].Date == "2018")
                        {
                            polution2 = int.Parse(list[i].Value);
                        }
                    }
                    Console.WriteLine("Roznica ludnoscio wynosi: " + (polution2 - polution));
                    break;
                case "4":
                    Console.WriteLine("Podaj rok: ");
                    string rok = Console.ReadLine();
                    Console.WriteLine("Podaj kraj: ");
                    string kraj = Console.ReadLine();
                    for (int i = 0; i < list.Count; i++)
                    {
                        con = list[i].Country;
                        if (con.Value == kraj && list[i].Date == rok)
                        {
                            Console.WriteLine("Populacja danego kraju wynosi: " + list[i].Value);
                        }
                    }
                    break;

                case "5":
                    Console.WriteLine("Podaj rok od którego chcesz sprawdzić róznice: ");
                    string rok1 = Console.ReadLine();
                    while (int.Parse(rok1) < 1960)
                    {
                        Console.WriteLine("Rok powinien być wieszky od 1960");
                        Console.WriteLine("Podaj rok od którego chcesz sprawdzić róznice: ");
                        rok1 = Console.ReadLine();
                    }
                    Console.WriteLine("Podaj rok do którgo chcesz sprawdzić róznice: ");
                    string rok2 = Console.ReadLine();
                    while (int.Parse(rok2) > 2020 || int.Parse(rok2) < int.Parse(rok1))
                    {
                        Console.WriteLine("Rok powinien być wieszky od poprzedniego lub mniejszy od 2019");
                        Console.WriteLine("Podaj rok do którego chcesz sprawdzić róznice: ");
                        rok2 = Console.ReadLine();
                    }
                    Console.WriteLine("Podaj nazwe kraju (India, China, United States ");
                    string Kraj = Console.ReadLine();
                    double pol1 = 0;
                    double pol2 = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        con = list[i].Country;
                        if (list[i].Date == rok2 && con.Value == Kraj)
                        {
                            pol2 = int.Parse(list[i].Value);

                        }
                        else if (list[i].Date == rok1 && con.Value == Kraj)
                        {
                            pol1 = int.Parse(list[i].Value);
                            double z = (pol2 / pol1) * 100;

                            Console.WriteLine("Populacja w " + Kraj + " wzrosła o: " + Math.Round((z - 100), 2) + " %");

                        }
                    }
                    break;

                case "6":
                    Console.WriteLine("Podaj rok od którego chcesz sprawdzić róznice: ");
                    string Rok1 = Console.ReadLine();
                    while (int.Parse(Rok1) < 1960)
                    {
                        Console.WriteLine("Rok powinien być wieszky od 1960");
                        Console.WriteLine("Podaj rok od którego chcesz sprawdzić róznice: ");
                        Rok1 = Console.ReadLine();
                    }
                    Console.WriteLine("Podaj rok do którgo chcesz sprawdzić róznice: ");
                    string Rok2 = Console.ReadLine();
                    while (int.Parse(Rok2) > 2020 || int.Parse(Rok2) < int.Parse(Rok1))
                    {
                        Console.WriteLine("Rok powinien być wieszky od poprzedniego lub mniejszy od 2019");
                        Console.WriteLine("Podaj rok do którego chcesz sprawdzić róznice: ");
                        rok2 = Console.ReadLine();
                    }
                    double Pol1 = 0;
                    double Pol2 = 0;
                    using (var sr = new StreamReader("db.json"))
                    {
                        var line = sr.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<Statistic>>(line);

                        for (int i = 0; i < list.Count; i++)
                        {
                            con = list[i].Country;
                            if (list[i].Date == Rok2)
                            {
                                pol2 = int.Parse(list[i].Value);

                            }
                            else if (list[i].Date == Rok1)
                            {
                                pol1 = int.Parse(list[i].Value);
                                double z = (Pol2 / Pol1) * 100;
                                Console.WriteLine("Populacja w " + con.Value + " wzrosła o: " + Math.Round((z - 100), 2) + " %");
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Do widzenia");
                    break;
            }
        }
    }
}
